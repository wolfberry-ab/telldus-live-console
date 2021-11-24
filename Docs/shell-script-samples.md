# Shell script samples

List sensors (outputs JSON format to stdout), or print "The command failed".

```bash
#!/bin/bash
export PATH=$PATH:/usr/local/share/dotnet/dotnet

dotnet tdlive.dll sensors list

if [ $? -neq 0 ]
then
  echo "The command failed" >&2
  exit 1
fi
```