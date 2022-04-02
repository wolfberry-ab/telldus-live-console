
[![Discord](https://badgen.net/badge/icon/discord?icon=discord&label)](https://discord.gg/NDYAEgD8ej)
[![NuGet stable version](https://badgen.net/nuget/v/tdlive)](https://nuget.org/packages/tdlive)

# Telldus Live Console application

Telldus Live Console application is a cross-platform tool that can control your [Telldus Live](https://telldus.com/telldus-live/) smart home (controllers, devices, sensors, events, ...).

tdlive can be used in any platform that runs .NET Runtime (Windows, Linux & macOS). See [this README](Docker/README.md) how to run it from a Docker container.

It's based on Wolfberry.TelldusLive library which supports all Telldus Live public API's (~180 functions).

# Getting started

## Install .NET

.NET 5 or later is needed to install and run the tdlive tool. Follow Microsoft's guide to install it in your operating system: https://docs.microsoft.com/en-us/dotnet/core/install/


## Install tdlive tool

Install it globally on the computer so it is accessible from any folder:

```shell
dotnet tool install -g tdlive
```

Uninstall with:

```shell
dotnet tool uninstall -g tdlive
```

Make the dotnet tool(s) available by adding to the path:

macOS/Linux: `export PATH=$PATH:$HOME/.dotnet/tools`
Windows: `set PATH=$PATH:%USERPROFILE%\.dotnet\tools`

## tdlive command line examples

Login and store credentials:
```shell
dotnet tdlive login --publicKey *** --privateKey *** --token *** --tokenSecret ***
```
where *** is your keys received from your [Telldus Live API](https://api.telldus.com/) account.

Show sensor list options:
```shell
dotnet tdlive sensors list --help
```

List all sensors:
```shell
dotnet tdlive sensors list
```

Log out (remove stored credentials):
```shell
dotnet tdlive logout
```

# More information

More information and sample scripts/applications is available in the [Docs](Docs/README.md) folder.

# Security

No credentials are sent through any third-party server. It's only stored on your local machine.
