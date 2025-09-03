# Solutions By Text API Analysis Tools

This directory contains Node.js-based tools used for analyzing and validating the Solutions By Text API implementation.

## Prerequisites

Install dependencies:
```bash
npm install
```

## Tools

### 1. `fetch-api-docs.js`
**Purpose**: Dynamic tool that fetches the complete OpenAPI specification from Solutions By Text using pure browser automation discovery.

**Requirements**: Puppeteer (automatically installs if missing)

**Usage**:
```bash
node fetch-api-docs.js
```

**Output**: 
- `../sbt-api-docs/merged-api-specification.json` - Complete API specification
- `../sbt-api-docs/discovered-files.json` - List of all discovered JSON files
- `../sbt-api-docs/src/` - Individual JSON files in proper directory structure

**Features**:
- **Pure dynamic discovery** - NO hardcoded file lists
- Uses Puppeteer to intercept network requests and discover all JSON files
- Downloads all discovered files (currently 62+ files)
- Merges all components into complete OpenAPI 3.1.0 specification
- Provides summary: 35 endpoints, 323 schemas, 4 webhooks
- Fails gracefully if browser automation fails (no silent fallbacks)

---

### 2. `generate-api-tracker.js`
**Purpose**: Generates a comprehensive API implementation tracker by comparing the official API specification with the SDK implementation.

**Usage**:
```bash
node generate-api-tracker.js
```

**Output**: Creates `../API-Implementation-Tracker.md` with verification status for all endpoints.

**Dependencies**: Requires `../sbt-api-docs/merged-api-specification.json` to exist.

---

### 4. `verify-api-implementation.js`
**Purpose**: Verifies SDK implementation against the API specification and generates detailed verification results.

**Usage**:
```bash
node verify-api-implementation.js
```

**Output**: Creates `../api-verification-results.json` with detailed verification results.

**Dependencies**: 
- Requires `../sbt-api-docs/merged-api-specification.json`
- Analyzes `../SolutionsByText.NET/SolutionsByTextClient.cs`
- Analyzes `../SolutionsByText.NET/SolutionsByTextJsonContext.cs`

---

## Workflow

The typical workflow for using these tools:

1. **Fetch API Documentation**:
   ```bash
   node fetch-api-docs.js
   ```

2. **Analyze SDK Implementation**:
   ```bash
   node verify-api-implementation.js
   node generate-api-tracker.js
   ```

3. **Review Generated Reports**:
   - Check `../API-Implementation-Tracker.md` for endpoint coverage
   - Review `../api-verification-results.json` for detailed analysis

## Notes

- These tools were used during initial SDK development and API analysis
- They may be useful for future API updates or maintenance
- The Puppeteer dependency is required for web scraping the documentation site
- All tools are designed to run from this `tools/` directory