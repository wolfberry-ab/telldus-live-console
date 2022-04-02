CONFIG_FILENAME=tdlive.json
HOST_CONFIG=$(HOME)/$(CONFIG_FILENAME)
HOST_CONFIG=$(shell pwd)/$(CONFIG_FILENAME)

# Build
# Create the tdlive-cli Docker image
build:
	docker build -t wolfberryab/tdlive-cli  .

# Login
# Create an empty valid JSON file that can be mounted
# Mount it to the container's home directory
login:
	echo "{}" > $(HOST_CONFIG)
	docker run --rm -it \
	-v $(HOST_CONFIG):/root/$(CONFIG_FILENAME) \
	wolfberryab/tdlive-cli \
	tdlive login --publicKey $(PUB_KEY) --privateKey $(PRV_KEY) --token $(TOKEN) --tokenSecret $(TOKEN_SECRET)

# List devices
# Mount the config file with login credentials and
# perform the tdlive command
listdevices:
	echo $(CURR_DIR)
	docker run --rm -it \
	-v $(HOST_CONFIG):/root/$(CONFIG_FILENAME) \
	wolfberryab/tdlive-cli \
	tdlive devices list
