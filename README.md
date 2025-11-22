# ASP.NET Core Basic Authentication Middleware

HTTP Basic Authentication middleware implementation for ASP.NET Core applications.

## Features
- **HTTP Basic Auth**: Username/password authentication
- **Base64 Encoding**: Credential encoding/decoding
- **Middleware Pattern**: ASP.NET Core pipeline integration
- **Request Interception**: Pre-controller authentication
- **Challenge Response**: Proper 401 responses

## Technology Stack
- ASP.NET Core
- .NET
- Middleware pattern
- HTTP headers

## Implementation
- Credentials: username = "kopi", password = "password"
- Authorization header parsing
- Base64 decode
- Credential validation

## Use Cases
- API authentication
- Development/testing auth
- Legacy system integration
- Simple auth requirements

## Note
Basic Auth sends credentials in Base64 (not encrypted). Use HTTPS in production.

## License
MIT License
