#!/usr/bin/env node

const fs = require('fs');
const path = require('path');

// Load the merged API specification
const apiSpec = JSON.parse(fs.readFileSync('../sbt-api-docs/merged-api-specification.json', 'utf8'));

// Parse the client implementation
const clientPath = '../SolutionsByText.NET/SolutionsByTextClient.cs';
const clientContent = fs.readFileSync(clientPath, 'utf8');

// Parse the JSON context
const jsonContextPath = '../SolutionsByText.NET/SolutionsByTextJsonContext.cs';
const jsonContextContent = fs.readFileSync(jsonContextPath, 'utf8');

// Results tracking
const results = {
    endpoints: [],
    totalEndpoints: 0,
    implemented: 0,
    notImplemented: 0,
    issues: []
};

// Extract all endpoints from API spec
function extractEndpoints() {
    const endpoints = [];
    
    for (const [path, methods] of Object.entries(apiSpec.paths)) {
        for (const [method, details] of Object.entries(methods)) {
            if (['get', 'post', 'put', 'patch', 'delete'].includes(method)) {
                endpoints.push({
                    method: method.toUpperCase(),
                    path: path,
                    operationId: details.operationId,
                    summary: details.summary,
                    requestBody: details.requestBody,
                    responses: details.responses,
                    parameters: details.parameters || []
                });
            }
        }
    }
    
    return endpoints;
}

// Map API endpoints to SDK method names (manual mapping since no operation IDs exist)
function getExpectedMethodName(endpoint) {
    const { method, path, summary } = endpoint;
    
    // Manual mapping based on actual SDK implementation
    const endpointToMethod = {
        'GET /groups/{groupId}/subscribers/status': 'GetGroupSubscriberStatusAsync',
        'POST /groups/{groupId}/subscribers': 'AddGroupSubscriberAsync',
        'POST /groups/{groupId}/subscribers/{msisdn}/verification': 'ConfirmSubscriberAsync',
        'GET /groups/{groupId}/subscribers?pageNumber={pageNumber}&pageSize={pageSize}': 'GetAllSubscribersGroupAsync',
        'POST /groups/{groupId}/subscribers/{msisdn}/reactivation-request': 'ReactivateSubscriberAsync',
        'DELETE /groups/{groupId}/subscribers/{msisdn}/': 'DeleteSubscriberAsync',
        'POST /groups/{groupId}/subscribers/{msisdn}/subscription-cancellation': 'CancelSubscriptionAsync',
        'GET /accounts/deactevents': 'GetDeactivationEventsAsync',
        'POST /groups/{groupId}/shortUrls': 'CreateSmartURLAsync',
        'PATCH /groups/{groupId}/shortUrls/{shortUrl}': 'UpdateSmartURLAsync',
        'GET /groups/{groupId}/keywords': 'GetKeywordsAsync',
        'GET /groups/{groupId}/phonenumbers/{msisdn}/events?countryCode=US': 'GetNumberDeactivationEventsAsync',
        'GET /groups/{groupId}/shorturls': 'GetAllSmartUrlsAsync',
        'GET /groups/{groupId}/templates': 'GetTemplatesAsync',
        'GET /groups/{groupId}/templates/{templateId}': 'GetTemplateAsync',
        'GET /brands/{brandId}/shorturl-clicks': 'GetSmartUrlClickReportAsync',
        'GET /brands/{brandId}/shorturl-click-details': 'GetSmartUrlDetailedClickReportAsync',
        'GET /brands/{brandId}/subscribers/status': 'GetBrandSubscriberStatusAsync',
        'POST /brands/{brandId}/subscribers': 'AddBrandSubscriberAsync',
        'POST /v2/brands/{brandId}/subscribers': 'AddBrandSubscriberV2Async',
        'POST /brands/{brandId}/subscribers/{msisdn}/verification': 'ConfirmBrandSubscriberAsync',
        'GET /reports/usage/brand-breakdown': 'GetUsageBrandBreakdownAsync',
        'PUT /groups/{{groupId}}/subscribers': 'UpdateSubscriberDataAsync',
        'POST /groups/{groupId}/messages': 'SendMessageAsync',
        'POST /groups/{groupId}/template-messages': 'SendTemplateMessageAsync',
        'POST /groups/{groupId}/schedule-messages': 'ScheduleMessageAsync',
        'POST /groups/{groupId}/schedule-template-messages': 'ScheduleTemplateMessageAsync',
        'GET /groups/{groupId}/media-messages/{messageId}/file/{fileId}': 'RetrieveMMSAsync',
        'DELETE /groups/{groupId}/media-messages/{messageId}/file/{fileId}': 'DeleteMMSAsync',
        'GET /groups/{groupId}/outbound-messages': 'GetOutboundMessagesAsync',
        'GET /groups/{groupId}/inbound-messages': 'GetInboundMessagesAsync',
        'POST /groups/{groupId}/odm/message': 'SendODMMessageAsync',
        'POST /groups/{groupId}/odm/{msisdn}/verification': 'VerifyODMAsync',
        'GET /brand-vbt-outbound-messages': 'GetBrandVbtOutboundMessageAsync',
        'GET /brand-vbt-inbound-messages': 'GetBrandVbtInboundMessageAsync',
        'GET /phonenumbers-data': 'GetPhoneNumberDataAsync'
    };
    
    const endpointKey = `${method} ${path}`;
    return endpointToMethod[endpointKey] || null;
}

// Check if an endpoint is implemented in the client
function checkClientImplementation(endpoint) {
    const expectedMethodName = getExpectedMethodName(endpoint);
    
    if (!expectedMethodName) {
        return { 
            implemented: false, 
            methodName: null,
            hasCorrectUrl: false,
            reason: 'No expected method mapping found'
        };
    }
    
    // Check if method exists in client (exact match)
    const methodPattern = new RegExp(`public async Task<.*?> ${expectedMethodName}\\s*\\(`, 'i');
    const hasMethod = methodPattern.test(clientContent);
    
    // Check for URL pattern in the method (simplified check)
    const pathPattern = endpoint.path
        .replace(/{([^}]+)}/g, '([^/]+)')  // Replace path parameters with regex
        .replace(/\//g, '\\/');           // Escape forward slashes
        
    const urlRegex = new RegExp(pathPattern, 'i');
    const hasCorrectUrl = urlRegex.test(clientContent);
    
    return {
        implemented: hasMethod,
        methodName: expectedMethodName,
        hasCorrectUrl: hasCorrectUrl,
        reason: hasMethod ? 'Method found' : 'Method not found in client'
    };
}

// Check if models are registered in JSON context
function checkJsonContext(modelName) {
    if (!modelName) return false;
    const pattern = new RegExp(`\\[JsonSerializable\\(typeof\\(${modelName}\\)`, 'i');
    return pattern.test(jsonContextContent);
}

// Main verification
function verifyImplementation() {
    const endpoints = extractEndpoints();
    results.totalEndpoints = endpoints.length;
    
    console.log(`\n🔍 API Implementation Verification Report`);
    console.log(`${'='.repeat(60)}`);
    console.log(`Total endpoints in API spec: ${endpoints.length}\n`);
    
    for (const endpoint of endpoints) {
        const impl = checkClientImplementation(endpoint);
        
        // Extract model names from API specification (from schema references)
        let requestModel = null;
        let responseModel = null;
        
        // Extract request model from requestBody
        if (endpoint.requestBody?.content?.['application/json']?.schema?.$ref) {
            requestModel = endpoint.requestBody.content['application/json'].schema.$ref.replace('#/components/schemas/', '');
        }
        
        // Extract response model from 200 response
        if (endpoint.responses?.['200']?.content?.['application/json']?.schema?.$ref) {
            responseModel = endpoint.responses['200'].content['application/json'].schema.$ref.replace('#/components/schemas/', '');
        }
        
        const requestInContext = checkJsonContext(requestModel);
        const responseInContext = checkJsonContext(responseModel);
        const apiResponseInContext = checkJsonContext(`ApiResponse<${responseModel}>`);
        
        const status = {
            endpoint: `${endpoint.method} ${endpoint.path}`,
            operationId: endpoint.operationId || 'N/A',
            methodName: impl.methodName,
            implemented: impl.implemented,
            urlCorrect: impl.hasCorrectUrl,
            requestModel: requestModel,
            responseModel: responseModel,
            requestInContext: requestInContext,
            responseInContext: responseInContext,
            apiResponseInContext: apiResponseInContext
        };
        
        results.endpoints.push(status);
        
        if (impl.implemented) {
            results.implemented++;
            console.log(`✅ ${status.endpoint}`);
            if (!impl.hasCorrectUrl) {
                console.log(`   ⚠️  URL pattern may not match API spec`);
                results.issues.push(`URL mismatch for ${status.endpoint}`);
            }
            if (!apiResponseInContext && responseModel) {
                console.log(`   ⚠️  ApiResponse<${responseModel}> not in JSON context`);
                results.issues.push(`Missing JSON context for ApiResponse<${responseModel}>`);
            }
        } else {
            results.notImplemented++;
            console.log(`❌ ${status.endpoint}`);
            console.log(`   Missing method: ${impl.methodName || 'Unknown'}`);
        }
    }
    
    // Summary
    console.log(`\n${'='.repeat(60)}`);
    console.log(`📊 Summary:`);
    console.log(`  ✅ Implemented: ${results.implemented}/${results.totalEndpoints}`);
    console.log(`  ❌ Not Implemented: ${results.notImplemented}/${results.totalEndpoints}`);
    console.log(`  ⚠️  Issues Found: ${results.issues.length}`);
    
    if (results.issues.length > 0) {
        console.log(`\n⚠️  Issues:`);
        results.issues.forEach(issue => console.log(`  - ${issue}`));
    }
    
    // Save detailed results
    fs.writeFileSync('../api-verification-results.json', JSON.stringify(results, null, 2));
    console.log(`\n📁 Detailed results saved to api-verification-results.json`);
}

// Run verification
verifyImplementation();