# tdlive in Docker

tdlive can be executed from a Docker container (eliminates the setup of .NET runtime and installation of tools).

## Getting started

tdlive stores the account credentials in a file called `td-live-config.json` located in the current user's home directory. E.g. C:\Users\bob\td-live-config.json (Windows) or /root/td-live-config.json (Linux).

The td-live-config.json file is created on login and cleared on logout. The file needs to be mounted and available in the Docker container.

### Example using a Makefile
Replace the *** with the secrets received from your Telldus Live account.

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
        -v /c/Users/bob/repos/telldus-live-console/Docker/td-live-config.json:/root/td-live-config.json \
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