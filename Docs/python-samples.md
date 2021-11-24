# Python samples
## List sensors

Save the text as e.g. `list-sensors.py`and then call it by typing `python list-sensors.py` from a Terminal.
```python
#!/usr/bin/python3
import subprocess
import json

proc = subprocess.Popen(['tdlive', 'sensors', 'list'], stdout=subprocess.PIPE)
output = proc.stdout.read()

# Convert from JSON to Dictionary
obj = json.loads(output)
name = obj["Sensors"][0]["Name"]

# Assume there is a sensor and print its name
print("My first sensors name is: %s" %(name))
```