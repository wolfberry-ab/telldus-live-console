# Getting started in ubuntu

Install .NET 5 runtime in Ubuntu 20.04 x86_64:

```
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-5.0
```

Install tdlive: 
```
dotnet tool install -g tdlive
```