const fs = require('fs');

// Read the merged API specification
const apiSpec = JSON.parse(fs.readFileSync('../sbt-api-docs/merged-api-specification.json', 'utf8'));

// Function to resolve schema references and get field details
function resolveSchema(schemaRef, visitedRefs = new Set()) {
    if (!schemaRef || !schemaRef.startsWith('#/') || visitedRefs.has(schemaRef)) {
        return null;
    }
    
    visitedRefs.add(schemaRef);
    const path = schemaRef.replace('#/components/schemas/', '');
    const schema = apiSpec.components.schemas[path];
    
    if (!schema) return null;
    
    return {
        name: path,
        type: schema.type,
        required: schema.required || [],
        properties: schema.properties || {},
        description: schema.description
    };
}

// Function to extract parameters from endpoint
function extractParameters(endpoint) {
    const pathParams = [];
    const queryParams = [];
    
    if (endpoint.parameters) {
        endpoint.parameters.forEach(param => {
            const paramInfo = {
                name: param.name,
                type: param.schema?.type || 'string',
                required: param.required || false,
                description: param.description || '',
                example: param.example
            };
            
            if (param.in === 'path') {
                pathParams.push(paramInfo);
            } else if (param.in === 'query') {
                queryParams.push(paramInfo);
            }
        });
    }
    
    return { pathParams, queryParams };
}

// Function to extract request/response models
function extractModels(endpoint) {
    const requestModels = [];
    const responseModels = [];
    
    // Extract request models
    if (endpoint.requestBody?.content?.['application/json']?.schema?.$ref) {
        const modelName = endpoint.requestBody.content['application/json'].schema.$ref.replace('#/components/schemas/', '');
        requestModels.push(modelName);
    }
    
    // Extract response models (get unique ones)
    if (endpoint.responses) {
        const uniqueModels = new Set();
        Object.keys(endpoint.responses).forEach(statusCode => {
            const response = endpoint.responses[statusCode];
            if (response.content?.['application/json']?.schema?.$ref) {
                const modelName = response.content['application/json'].schema.$ref.replace('#/components/schemas/', '');
                uniqueModels.add(modelName);
            }
        });
        responseModels.push(...Array.from(uniqueModels));
    }
    
    return { requestModels, responseModels };
}

// Generate the tracker
function generateTracker() {
    const endpoints = [];
    
    // Extract all endpoints from API spec
    Object.keys(apiSpec.paths).forEach(path => {
        const pathItem = apiSpec.paths[path];
        
        Object.keys(pathItem).forEach(method => {
            if (['get', 'post', 'put', 'delete', 'patch'].includes(method)) {
                const endpoint = pathItem[method];
                
                const { pathParams, queryParams } = extractParameters(endpoint);
                const { requestModels, responseModels } = extractModels(endpoint);
                
                endpoints.push({
                    method: method.toUpperCase(),
                    path: path,
                    summary: endpoint.summary || '',
                    description: endpoint.description || '',
                    pathParams,
                    queryParams,
                    requestModels,
                    responseModels,
                    operationId: endpoint.operationId || ''
                });
            }
        });
    });
    
    // Sort endpoints by method and path
    endpoints.sort((a, b) => {
        const methodOrder = ['DELETE', 'GET', 'PATCH', 'POST', 'PUT'];
        if (a.method !== b.method) {
            return methodOrder.indexOf(a.method) - methodOrder.indexOf(b.method);
        }
        return a.path.localeCompare(b.path);
    });
    
    return { endpoints, totalCount: endpoints.length };
}

// Generate markdown content
function generateMarkdown() {
    const { endpoints, totalCount } = generateTracker();
    
    let markdown = `# API Verification Tracker

**Generated**: ${new Date().toISOString().split('T')[0]}  
**Total Endpoints**: ${totalCount}

## Verification Columns
- **URL**: Endpoint URL construction verified
- **Params**: Query/path parameters verified  
- **Request**: Request model exists and correct
- **Response**: Response model exists and correct
- **JSON**: Models registered in JSON context
- **Status**: Overall verification status

| # | Endpoint | Method | URL | Params | Request | Response | JSON | Status |
|---|----------|--------|-----|--------|---------|----------|------|--------|`;

    // Generate table rows
    endpoints.forEach((ep, index) => {
        const methodName = `${ep.method} \`${ep.path}\``;
        markdown += `\n| ${index + 1} | ${methodName} | TBD | ❓ | ❓ | ❓ | ❓ | ❓ | 🔄 |`;
    });

    markdown += `

## Legend
- ✅ = Verified correct
- ❌ = Issue found/needs fix  
- ❓ = Not yet verified
- 🔄 = In progress
- ✨ = Complete

## Verification Requirements for Each Endpoint

For EACH endpoint, verify ALL of the following:

1. **API Spec Check** - Check sbt-api-docs JSON files for endpoint definition
2. **SDK Method** - Verify method exists in SolutionsByTextClient.cs with correct signature
3. **URL Construction** - Verify endpoint URL matches API spec exactly
4. **Parameters** - Verify all path/query parameters are handled correctly
5. **Request Model** - Verify request model exists and ALL properties match API spec
   - Check base classes if model inherits
   - Verify JsonPropertyName attributes for POST/PUT/PATCH
   - Verify JsonIgnore for path parameters
6. **Response Model** - Verify response model exists and ALL properties match API spec
   - Check base classes (ApiResponse<T>, ErrorResponse, etc.)
   - Verify all nested models exist
7. **JSON Context** - Verify models are registered in SolutionsByTextJsonContext.cs
   - Check request model registration
   - Check response model registration
   - Check all nested model registrations

## Detailed Endpoint Information

`;

    // Generate method summary table
    const methodStats = {};
    endpoints.forEach(ep => {
        if (!methodStats[ep.method]) {
            methodStats[ep.method] = 0;
        }
        methodStats[ep.method]++;
    });

    markdown += `| Method | Count | Endpoints |\n`;
    markdown += `|--------|-------|----------|\n`;
    
    Object.keys(methodStats).forEach(method => {
        const count = methodStats[method];
        markdown += `| ${method} | ${count} | `;
        
        const methodEndpoints = endpoints
            .filter(ep => ep.method === method)
            .map(ep => `\`${ep.path}\``)
            .slice(0, 3); // Show first 3
            
        if (methodStats[method] > 3) {
            methodEndpoints.push(`... +${methodStats[method] - 3} more`);
        }
        
        markdown += `${methodEndpoints.join(', ')} |\n`;
    });
    
    markdown += `| **TOTAL** | **${totalCount}** | All API endpoints |\n\n`;

    // Generate detailed sections by method
    let currentMethod = '';
    endpoints.forEach((ep, index) => {
        if (ep.method !== currentMethod) {
            currentMethod = ep.method;
            const methodCount = methodStats[currentMethod];
            
            markdown += `---\n\n## ${currentMethod} Endpoints (${methodCount} total)\n\n`;
        }

        markdown += `### ${index + 1}. ${ep.method} \`${ep.path}\`\n\n`;
        markdown += `**Summary**: ${ep.summary}\n\n`;
        
        if (ep.description) {
            markdown += `**Description**: ${ep.description}\n\n`;
        }

        // Request Models
        if (ep.requestModels.length > 0) {
            markdown += `**API Request Models**:\n`;
            ep.requestModels.forEach(model => {
                markdown += `- \`${model}\`\n`;
            });
            markdown += '\n';
        } else {
            markdown += `**API Request Models**: None (${ep.method === 'GET' || ep.method === 'DELETE' ? 'expected for ' + ep.method : 'no body required'})\n\n`;
        }

        // Response Models  
        if (ep.responseModels.length > 0) {
            markdown += `**API Response Models**:\n`;
            ep.responseModels.forEach(model => {
                markdown += `- \`${model}\`\n`;
            });
            markdown += '\n';
        }

        // Path Parameters
        if (ep.pathParams.length > 0) {
            markdown += `**Path Parameters** (${ep.pathParams.length}):\n`;
            ep.pathParams.forEach(param => {
                const req = param.required ? ' *(required)*' : ' *(optional)*';
                markdown += `- \`${param.name}\` (${param.type})${req}`;
                if (param.description) {
                    markdown += ` - ${param.description}`;
                }
                markdown += '\n';
            });
            markdown += '\n';
        }

        // Query Parameters
        if (ep.queryParams.length > 0) {
            markdown += `**Query Parameters** (${ep.queryParams.length}):\n`;
            ep.queryParams.forEach(param => {
                const req = param.required ? ' *(required)*' : ' *(optional)*';
                markdown += `- \`${param.name}\` (${param.type})${req}`;
                if (param.description) {
                    markdown += ` - ${param.description}`;
                }
                markdown += '\n';
            });
            markdown += '\n';
        }

        // SDK Implementation Status (to be filled in manually)
        markdown += `**SDK Method**: *TBD*\n`;
        markdown += `**Request Model Path**: *TBD*\n`;
        markdown += `**Response Model Path**: *TBD*\n\n`;
        
        markdown += `**Verification Checklist**:\n`;
        markdown += `- [ ] API spec checked in sbt-api-docs JSON\n`;
        markdown += `- [ ] SDK method exists with correct signature\n`;
        markdown += `- [ ] URL construction matches API spec\n`;
        markdown += `- [ ] All parameters handled correctly\n`;
        markdown += `- [ ] Request model matches API spec (including base classes)\n`;
        markdown += `- [ ] Response model matches API spec (including base classes)\n`;
        markdown += `- [ ] Models registered in SolutionsByTextJsonContext\n\n`;
        
        markdown += `**Issues Found**: *None*\n\n`;
        markdown += `**Fixes Applied**: *None*\n\n`;
        
        markdown += `---\n\n`;
    });

    // Add critical shared models section
    markdown += `## Critical Shared Models (from API spec)\n\n`;
    
    const criticalModels = [
        'Address', 'ContactParam', 'ContactParamRequest', 'SubscriberRequest',
        'Relation', 'Properties', 'Variables', 'Verification', 'VbtTypes',
        'InteractionBroadcastMessageRequest', 'InteractionBroadcastTemplateMessageRequest',
        'ExternalApiResponseNew', 'ExternalErrorResponse'
    ];

    criticalModels.forEach(modelName => {
        const schema = apiSpec.components.schemas[modelName];
        if (schema) {
            markdown += `### ${modelName}\n\n`;
            
            if (schema.description) {
                markdown += `**Description**: ${schema.description}\n\n`;
            }
            
            markdown += `**Type**: ${schema.type || 'object'}\n\n`;
            
            if (schema.required && schema.required.length > 0) {
                markdown += `**Required Fields**: ${schema.required.map(f => `\`${f}\``).join(', ')}\n\n`;
            }
            
            if (schema.properties) {
                markdown += `**Properties**:\n`;
                Object.keys(schema.properties).forEach(propName => {
                    const prop = schema.properties[propName];
                    let propInfo = `- \`${propName}\`: ${prop.type || 'object'}`;
                    if (prop.nullable) propInfo += ' *(nullable)*';
                    if (prop.$ref) propInfo += ` → ${prop.$ref.replace('#/components/schemas/', '')}`;
                    if (prop.items && prop.items.$ref) propInfo += ` → Array<${prop.items.$ref.replace('#/components/schemas/', '')}>`;
                    if (prop.description) propInfo += ` - ${prop.description}`;
                    markdown += propInfo + '\n';
                });
                markdown += '\n';
            }
            
            markdown += `**SDK Implementation**: *To be verified*\n\n`;
            markdown += `---\n\n`;
        } else {
            markdown += `### ${modelName}\n\n`;
            markdown += `**Status**: ❌ Not found in API specification\n\n`;
            markdown += `---\n\n`;
        }
    });

    // Add summary
    markdown += `## Implementation Checklist\n\n`;
    markdown += `This tracker will be used to systematically verify each endpoint:\n\n`;
    markdown += `1. **Endpoint Mapping** - Verify each API endpoint has a corresponding SDK method\n`;
    markdown += `2. **Parameter Mapping** - Verify path and query parameters are correctly handled\n`;
    markdown += `3. **Request Model Verification** - Verify request models match API specifications exactly\n`;
    markdown += `4. **Response Model Verification** - Verify response models match API specifications exactly\n`;
    markdown += `5. **Field-Level Verification** - Verify all fields, types, and requirements match\n`;
    markdown += `6. **Serialization Verification** - Verify JSON serialization context includes all models\n\n`;

    markdown += `## Progress Tracking\n\n`;
    markdown += `- [ ] **Phase 1**: Map all ${totalCount} API endpoints to SDK methods\n`;
    markdown += `- [ ] **Phase 2**: Verify all request models (${new Set(endpoints.flatMap(ep => ep.requestModels)).size} unique models)\n`;  
    markdown += `- [ ] **Phase 3**: Verify all response models (${new Set(endpoints.flatMap(ep => ep.responseModels)).size} unique models)\n`;
    markdown += `- [ ] **Phase 4**: Field-level verification of critical shared models\n`;
    markdown += `- [ ] **Phase 5**: End-to-end testing and validation\n\n`;

    markdown += `---\n\n`;
    markdown += `*This tracker was auto-generated from the API specification on ${new Date().toISOString().split('T')[0]}*\n`;
    markdown += `*Use \`node generate-api-tracker.js\` to regenerate from latest API specification*\n`;

    return markdown;
}

// Generate and write the tracker
console.log('Generating API implementation tracker from specification...');
const trackerContent = generateMarkdown();

fs.writeFileSync('../API-Implementation-Tracker.md', trackerContent);
console.log('✅ API Implementation Tracker generated successfully!');

// Output summary stats
const { endpoints, totalCount } = generateTracker();

console.log(`\n📊 API Analysis Summary:`);
console.log(`- Total endpoints: ${totalCount}`);
console.log(`- Total API schemas: ${Object.keys(apiSpec.components.schemas).length}`);
console.log(`- Unique request models: ${new Set(endpoints.flatMap(ep => ep.requestModels)).size}`);
console.log(`- Unique response models: ${new Set(endpoints.flatMap(ep => ep.responseModels)).size}`);

// Show method breakdown
const methodStats = {};
endpoints.forEach(ep => {
    if (!methodStats[ep.method]) {
        methodStats[ep.method] = 0;
    }
    methodStats[ep.method]++;
});

console.log(`\n📋 Endpoints by HTTP Method:`);
Object.keys(methodStats).forEach(method => {
    console.log(`- ${method}: ${methodStats[method]} endpoints`);
});

console.log(`\nNext step: Systematically work through the tracker to verify SDK implementation.`);