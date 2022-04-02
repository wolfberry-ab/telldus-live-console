# Tests

## Getting started on macOS

Install PowerShell on macOS: `brew install --cask powershell`

Login once or update ~/.config/tdlive.json with required
credentials.

```
export AZ_DOWNLOAD_TOKEN="the-secret-token"
export PATH=~/.dotnet/tools:$PATH

pwsh test-release.ps1 <version>

dotnet tool uninstall -g tdlive
dotnet tool install -g --add-source ./ tdlive
tdlive sensors list
dotnet tool uninstall -g tdlive
```
