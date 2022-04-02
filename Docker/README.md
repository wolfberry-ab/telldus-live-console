# tdlive-cli - tdlive running in Docker

tdlive can be executed as a command line tool from a Docker container eliminates the setup of .NET runtime and installation of tools.

The [tdlive-cli](https://hub.docker.com/repository/docker/wolfberryab/tdlive-cli) container image is hostad at Docker Hub.

## Getting started

tdlive stores the account credentials in a file called `tdlive.json` located in the current user's home directory. E.g. C:\Users\bob\tdlive.json (Windows) or /root/tdlive.json (Linux Docker).

The tdlive.json file is created on login and cleared on logout. The file needs to be mounted and available in the Docker container since it's not possible to persist data in the container itself.

### Example using a Makefile
Replace the *** with the secrets received from your [Telldus Live API](https://api.telldus.com/) account.

Example of setting secrets, logging in (and creating a config/credential file) and list the devices.

```shell
docker pull wolfberryab/tdlive-cli

export PUB_KEY=***
export PRV_KEY=***
export TOKEN=***
export TOKEN_SECRET=***

make login
make listdevices

```

Example output when listing devices:
```shell
$ make listdevices

docker run --rm -it \
        -v /c/Users/bob/repos/telldus-live-console/Docker/tdlive.json:/root/tdlive.json \
        tdlive-cli \
        tdlive devices list
{
  "Device": [
    {
      "Id": "9231151",
      "ClientDeviceId": "59",
      "Name": "My favorite group",
      "State": 0,
      "StateValue": null,
      "StateValues": [],
      ...
    },
    ...
  ]
}
```
