# Code Signing Certificate

## Overview

PKHeX is signed with a self-signed code signing certificate to provide:
- Digital signature verification
- Tamper detection
- Publisher identification
- Reduced Windows SmartScreen warnings

## Certificate Details

- **Subject**: CN=PKHeX by NexusRisen, O=PKHeX Development, C=US
- **Key Length**: 4096-bit RSA
- **Valid For**: 5 years from creation
- **Algorithm**: SHA256
- **Usage**: Code Signing only

## Installation (For Users)

To trust the PKHeX code signature on your system:

1. Download `PKHeX_CodeSign_Public.cer` from the repository
2. Double-click the certificate file
3. Click "Install Certificate"
4. Select "Current User"
5. Choose "Place all certificates in the following store"
6. Select "Trusted Root Certification Authorities"
7. Click "Next" and "Finish"
8. Confirm the security warning

**Note**: This is a self-signed certificate. Windows will still show a warning the first time you run PKHeX, but subsequent runs will be smoother.

## For Developers

The certificate is stored in two files:
- `PKHeX_CodeSign_New.pfx` - Private key (password protected, not in repository)
- `PKHeX_CodeSign_Public.cer` - Public certificate (can be distributed)

### Building Signed Releases

The build process automatically signs the executable during `dotnet publish`:

```bash
dotnet publish PKHeX.WinForms/PKHeX.WinForms.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

The certificate password is `PKHeXSign2025`.

## Why Self-Signed?

Professional code signing certificates from Certificate Authorities (CA) cost $300-500/year and require business verification. For open-source projects, self-signed certificates provide:
- Free signing capability
- Tamper detection
- Basic publisher verification
- Reduced (but not eliminated) SmartScreen warnings

## Limitations

Self-signed certificates:
- Still trigger Windows SmartScreen warnings on first run
- Are not automatically trusted by Windows
- Require manual installation for full trust
- Don't provide the same level of validation as CA-signed certificates

For production use, consider purchasing an Extended Validation (EV) code signing certificate.
