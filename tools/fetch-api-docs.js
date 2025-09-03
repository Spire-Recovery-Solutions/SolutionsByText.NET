#!/usr/bin/env node

/**
 * Dynamic script to fetch the complete OpenAPI specification from Solutions By Text
 * Uses browser automation (Puppeteer) to discover all JSON files and downloads them
 * NO hardcoded file lists - discovers everything dynamically from the live documentation site
 */

const fs = require('fs').promises;
const path = require('path');
const https = require('https');

const outputDir = path.join(__dirname, '..', 'sbt-api-docs');

// Download a file via HTTPS
async function downloadFile(url) {
    return new Promise((resolve, reject) => {
        https.get(url, (response) => {
            let data = '';
            
            response.on('data', (chunk) => {
                data += chunk;
            });
            
            response.on('end', () => {
                try {
                    const json = JSON.parse(data);
                    resolve(json);
                } catch (error) {
                    reject(new Error(`Failed to parse JSON from ${url}: ${error.message}`));
                }
            });
        }).on('error', reject);
    });
}

// Discover all JSON files using browser automation
async function discoverJsonFiles() {
    console.log('🔍 Discovering API documentation structure...\n');
    
    let puppeteer;
    try {
        puppeteer = require('puppeteer');
    } catch (error) {
        console.log('Puppeteer not installed. Installing now...');
        const { execSync } = require('child_process');
        try {
            execSync('npm install puppeteer', { stdio: 'inherit' });
            puppeteer = require('puppeteer');
        } catch (installError) {
            console.error('Failed to install Puppeteer. Please run: npm install puppeteer');
            throw new Error('Puppeteer installation failed. This tool requires Puppeteer to dynamically discover API documentation files.');
        }
    }

    console.log('Launching browser...');
    const browser = await puppeteer.launch({
        headless: 'new',
        args: ['--no-sandbox', '--disable-setuid-sandbox']
    });

    try {
        const page = await browser.newPage();
        const jsonFiles = [];
        
        // Intercept network requests to capture JSON file URLs
        page.on('response', response => {
            const url = response.url();
            if (url.endsWith('.json') && url.includes('developers.solutionsbytext.com')) {
                const relativePath = url.replace('https://developers.solutionsbytext.com/docs/t2c2.0/', '');
                if (!jsonFiles.includes(relativePath)) {
                    jsonFiles.push(relativePath);
                }
            }
        });

        console.log('Loading Solutions By Text API documentation...');
        await page.goto('https://developers.solutionsbytext.com/docs/t2c2.0/', {
            waitUntil: 'networkidle2',
            timeout: 60000
        });

        // Wait for all files to load
        await new Promise(resolve => setTimeout(resolve, 5000));
        
        // Also try to extract the assembled spec if available
        console.log('Attempting to extract assembled specification...');
        const assembledSpec = await page.evaluate(() => {
            // Try multiple possible locations
            if (window.t2cDocs) return window.t2cDocs;
            if (window.Redoc && window.Redoc.spec) return window.Redoc.spec;
            
            // Look for any global containing the spec
            for (const key in window) {
                if (key.toLowerCase().includes('spec') || 
                    key.toLowerCase().includes('openapi')) {
                    const value = window[key];
                    if (value && typeof value === 'object' && value.openapi) {
                        return value;
                    }
                }
            }
            return null;
        });

        await browser.close();

        if (assembledSpec) {
            console.log('✅ Found assembled specification in browser context!');
            return { assembledSpec, jsonFiles };
        }

        console.log(`📁 Discovered ${jsonFiles.length} JSON files`);
        return { assembledSpec: null, jsonFiles };

    } catch (error) {
        await browser.close();
        console.error('Browser automation failed:', error.message);
        throw new Error('Dynamic file discovery failed. Puppeteer is required to discover all JSON files from the API documentation site.');
    }
}


// Download all JSON files and merge them
async function downloadAndMerge(jsonFiles) {
    console.log(`\n📥 Downloading ${jsonFiles.length} API documentation files...\n`);
    
    const baseUrl = 'https://developers.solutionsbytext.com/docs/t2c2.0/';
    const downloadedFiles = {};
    let successCount = 0;
    let failureCount = 0;
    
    // Create directory structure
    const dirs = [...new Set(jsonFiles.map(f => path.dirname(f)))];
    for (const dir of dirs) {
        await fs.mkdir(path.join(outputDir, dir), { recursive: true });
    }
    
    // Download each file
    for (const file of jsonFiles) {
        const url = baseUrl + file;
        const outputPath = path.join(outputDir, file);
        
        process.stdout.write(`Downloading ${file}... `);
        
        try {
            const content = await downloadFile(url);
            await fs.writeFile(outputPath, JSON.stringify(content, null, 2));
            downloadedFiles[file] = content;
            console.log('✅');
            successCount++;
        } catch (error) {
            console.log(`❌ (${error.message})`);
            failureCount++;
        }
    }
    
    console.log('\n📊 Download Summary:');
    console.log(`✅ Successfully downloaded: ${successCount} files`);
    console.log(`❌ Failed to download: ${failureCount} files`);
    
    return downloadedFiles;
}

// Merge all components into a single OpenAPI specification
async function mergeSpecification(downloadedFiles) {
    console.log('\n🔨 Merging API specification...');
    
    const spec = {
        openapi: '3.1.0',
        info: {},
        tags: [],
        paths: {},
        webhooks: {},
        components: {
            schemas: {},
            securitySchemes: {}
        }
    };
    
    // Process each downloaded file based on its path
    for (const [filepath, content] of Object.entries(downloadedFiles)) {
        if (filepath.includes('/info/')) {
            spec.info = content;
        } else if (filepath.includes('/tags/')) {
            spec.tags = content;
        } else if (filepath.includes('/webhooks/')) {
            spec.webhooks = content;
        } else if (filepath.includes('/paths/')) {
            Object.assign(spec.paths, content);
        } else if (filepath.includes('/securitySchemes/')) {
            spec.components.securitySchemes = content;
        } else if (filepath.includes('/schemas/')) {
            Object.assign(spec.components.schemas, content);
        }
    }
    
    return spec;
}

// Main function
async function fetchAPIDocumentation() {
    console.log('🚀 Solutions By Text API Documentation Fetcher\n');
    console.log('This tool combines browser automation for discovery with direct downloads for reliability.\n');
    
    try {
        // Step 1: Discover files (with Puppeteer if available)
        const { assembledSpec, jsonFiles } = await discoverJsonFiles();
        
        // Step 2: If we got an assembled spec from the browser, use it directly
        if (assembledSpec) {
            const outputPath = path.join(outputDir, 'merged-api-specification.json');
            await fs.mkdir(outputDir, { recursive: true });
            await fs.writeFile(outputPath, JSON.stringify(assembledSpec, null, 2));
            
            console.log(`\n✅ Saved complete specification from browser context to: ${outputPath}`);
            printSummary(assembledSpec);
            return;
        }
        
        // Step 3: Otherwise, download and merge individual files
        const downloadedFiles = await downloadAndMerge(jsonFiles);
        
        // Step 4: Merge into complete specification
        const mergedSpec = await mergeSpecification(downloadedFiles);
        
        // Step 5: Save merged specification
        const outputPath = path.join(outputDir, 'merged-api-specification.json');
        await fs.writeFile(outputPath, JSON.stringify(mergedSpec, null, 2));
        
        console.log(`\n✅ Merged specification saved to: ${outputPath}`);
        
        // Step 6: Save the discovered file list for future reference
        const fileListPath = path.join(outputDir, 'discovered-files.json');
        await fs.writeFile(fileListPath, JSON.stringify(jsonFiles, null, 2));
        console.log(`📁 File list saved to: ${fileListPath}`);
        
        printSummary(mergedSpec);
        
    } catch (error) {
        console.error('\n❌ Error:', error);
        process.exit(1);
    }
}

// Print specification summary
function printSummary(spec) {
    console.log('\n📊 API Specification Summary:');
    console.log(`- Title: ${spec.info?.title || 'N/A'}`);
    console.log(`- Version: ${spec.info?.version || 'N/A'}`);
    console.log(`- OpenAPI Version: ${spec.openapi || 'N/A'}`);
    
    if (spec.paths) {
        console.log(`- Total Endpoints: ${Object.keys(spec.paths).length}`);
    }
    
    if (spec.components?.schemas) {
        console.log(`- Total Schemas: ${Object.keys(spec.components.schemas).length}`);
    }
    
    if (spec.webhooks) {
        console.log(`- Total Webhooks: ${Object.keys(spec.webhooks).length}`);
    }
}

// Run the script
fetchAPIDocumentation().catch(console.error);