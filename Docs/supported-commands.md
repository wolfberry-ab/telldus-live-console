# Supported Telldus Live commands

tdlive is using the Wolfberry.TelldusLive library which supports all public methods
in Telldus Live cloud API. The goal is to implement commands for all cloud methods.

# Device commands
| Command | Implemented? |
|---|---|
|Add |-|
|Bell |yes|
|SendCommand |yes (but not tested)|
|Dim |yes|
|Down |yes|
|Get History |-|
|Get Device Info |yes|
|Learn |yes|
|Remove |yes|
|Set Rgb |-|
|Ignore |-|
|Set Name |-|
|Set Model |-|
|Set Metadata |-|
|Set Protocol |-|
|Set Parameter |-|
|Stop |yes|
|Set Thermostat |-|
|TurnOn |yes|
|TurnOff |yes|
|Up |yes|
|List Devices |-|

# Sensor commands
| Command | Implemented? |
| --- | ---|
|List Sensors |yes|
|Get Sensor Info |yes|
|Ignore |-|
|Set Name |-|
|Get History |yes|
|Remove History |-|
|Remove Value |-|
|Reset Max/Min |-|
|Set Keep History |-|