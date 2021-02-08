# Docker Cheatsheet
This a quick introduction to docker and the common commands that you are most likely to need on a day-to-day basis.

## Docker
Docker is a containerization technology that provides a consistent mechanism for distributing applications. 


## Docker Lifecycle
A quick note on docker life cycle: a **Dockerfile** must be built into a docker **image**. When you run a docker image we refer to it as a docker **container**.

## Running a Docker image -> containers
The following commands are useful when you want to run a docker image (start a container).

| Command | Description | Example | Explanation |
| ------- | ------- | ------- | ------- |
| `docker run [OPTIONS] IMAGE [COMMAND] [ARG...]` | [Starts a container based on a docker image.](https://docs.docker.com/engine/reference/commandline/run/) | `docker container run --name web -p 5000:80 alpine:3.9` | Run a container from the Alpine version 3.9 image, name the running container “web” and expose port 5000 externally, mapped to port 80 inside the container. |
| `docker stop [OPTIONS] CONTAINER [CONTAINER...]` | [Stop a running container using SIGTERM.](https://docs.docker.com/engine/reference/commandline/stop/) | `docker container stop web` |  Stop the running container called `web` through SIGTERM |
| `docker ps [OPTIONS]` | [View the running docker containers](https://docs.docker.com/engine/reference/commandline/ps/) | `docker ps` | Show the running docker containers. | 
| `docker kill [OPTIONS] CONTAINER [CONTAINER...]` | [Stop a running container using SIGKILL](https://docs.docker.com/engine/reference/commandline/kill/) | `docker container kill web` | Kills the container named `web` using SIGKILL | 
| `docker network ls [OPTIONS]` | [List the docker networks](https://docs.docker.com/engine/reference/commandline/network_ls/) | `docker network ls` | List the networks |
| `docker image ls [OPTIONS] [REPOSITORY[:TAG]]` | [List the running containers (add --all to include stopped containers)](https://docs.docker.com/engine/reference/commandline/image_ls/) | `docker container ls` | List the running containers |
| `docker container rm [OPTIONS] CONTAINER [CONTAINER...]` | [Remove a container](https://docs.docker.com/engine/reference/commandline/container_rm/) | `docker container rm -f $(docker ps -aq)` | Delete all running and stopped containers |
| `docker container logs [OPTIONS] CONTAINER` | [Show the logs for a container](https://docs.docker.com/engine/reference/commandline/container_logs/) | `docker container logs --tail 100 web` | Print the last 100 lines of the `web` container’s logs |
| `docker system prune [OPTIONS]` | [Clear all unused docker resources](https://docs.docker.com/engine/reference/commandline/system_prune/) | `docker system prune` | Remove all unused containers, networks, images (both dangling and unreferenced), and optionally, volumes |


## Building Docker images
This section includes docker build commands as well as a few notes on dockerfile build syntax.

### Build Commands
| Command | Description | Example | Explanation |
| ------- | ------- | ------- | ------- |
| `docker build [OPTIONS] PATH \| URL \| -` | [Build an image from a Dockerfile](https://docs.docker.com/engine/reference/commandline/build/) | `docker build -t myimage:1.0 .` | Build an image from the Dockerfile in the current directory and tag the image |
| `docker image ls [OPTIONS] [REPOSITORY[:TAG]]` | [list the docker images available locally](https://docs.docker.com/engine/reference/commandline/image_ls/) | `docker image ls` | List all images that are locally stored with the Docker Engine |
| `docker image rm [OPTIONS] IMAGE [IMAGE...]` | [Remove an image from the local store](https://docs.docker.com/engine/reference/commandline/image_rm/) | `docker image rm alpine:3.4` | Delete an image from the local image store |


### Dockerfile Commands
[Dockerfile commands](https://docs.docker.com/engine/reference/builder/#format) are used when creating a docker build file. Here are some of the most common commands:
| Command | Description | Example | Explanation |
| ------- | ------- | ------- | ------- |
| `FROM [--platform=<platform>] <image> [AS <name>]` | [Base image that will be used as the start environment](https://docs.docker.com/engine/reference/builder/#from) | `FROM alpine:3.9 as build` | Uses the alpine 3.9 docker image as the base for our docker file. We name this image `build`. |
| `RUN <command>` | [Runs a command when building the image](https://docs.docker.com/engine/reference/builder/#run) | `RUN /bin/bash -c 'source $HOME/.bashrc; echo $HOME'` | Use bash to load the environment variables for the current user and print the `$HOME` environment variable (path). |
| `EXPOSE <port> [<port>/<protocol>...]` | [This explicitly exposes a port on TCP or UDP](https://docs.docker.com/engine/reference/builder/#expose) | `EXPOSE 80/tcp` | Exposes port 80 using TCP. Note that TCP is the default if the protocol is not specified. |
| `ENV <key>=<value> ...` | [Sets an environment variable](https://docs.docker.com/engine/reference/builder/#env) | `ENV MY_NAME="John Doe"` | Set an environment variable called `MY_NAME` equal to a value `"John Doe"`.
| `ADD [--chown=<user>:<group>] <src>... <dest>` | [Add files from your host machine to the docker image. Also allows a remote URL as source.](https://docs.docker.com/engine/reference/builder/#add) | `ADD test.txt /absoluteDir/` | Add a file called `test.txt` to the docker image in the absolute path `/absoluteDir/`|
| `COPY [--chown=<user>:<group>] <src>... <dest>` | [Copies files from the local file system into the docker image. This command is generally considered to be more consistent for adding files to docker images](https://docs.docker.com/engine/reference/builder/#copy) | `COPY hom* /mydir/` | Copies all files matching the wildcard pattern `hom*` into the absolute directory path `/mydir`| 
| `ENTRYPOINT ["executable", "param1", "param2"]` | [The entrypoint is what is called when you run the docker image as a container.](https://docs.docker.com/engine/reference/builder/#entrypoint) | `ENTRYPOINT ["top", "-b"]` | This will run the Ubuntu command `top` with the `-b` argument. |
| `WORKDIR /path/to/workdir` | [This sets the working directory in the docker image that is being built.](https://docs.docker.com/engine/reference/builder/#workdir) | `WORKDIR /mydir` | Set the working directory to the absolute path `/mydir/` |

## Sharing Docker images
Docker images are the binary artifacts that we can share for reuse. These commands are most commonly used for sharing images:
| Command | Description | Example | Explanation |
| ------- | ------- | ------- | ------- |
| `docker pull [OPTIONS] NAME[:TAG\|@DIGEST]` | [Retrieves an image from a remote docker registry, layer by layer](https://docs.docker.com/engine/reference/commandline/pull/) | `docker pull alpine:3.9` | Pull an image from a registry |
| `docker tag SOURCE_IMAGE[:TAG] TARGET_IMAGE[:TAG]` | [Tag a docker image](https://docs.docker.com/engine/reference/commandline/tag/) | `docker tag myimage:1.0 myrepo/ myimage:2.0` | Retag a local image with a new image name
and tag |
| `docker push [OPTIONS] NAME[:TAG]` | [Publish a docker image from your local to a remote docker registry](https://docs.docker.com/engine/reference/commandline/push/) | `docker push myrepo/myimage:2.0` | Push an image to a registry |
 

## Docker-Compose
[Docker-compose]() allows us to orchestrate multiple docker containers together as an environment. We use a [yaml file to define a docker-compose environment](https://docs.docker.com/compose/compose-file/compose-file-v3/).

| Command | Description | 
| ------- | ------- | 
| `docker-compose start` | Start a docker-compose environment. |
| `docker-compose ps` | Show the docker-compose containers that are running in the docker-compose environment.  |
| `docker-compose down --remove-orphans` | Stop the docker-compose environment and remove all orphans (clean stop) |

### References
[Official docs](https://docs.docker.com/engine/reference/commandline/docker/)

[A useful handbook for docker](https://www.freecodecamp.org/news/the-docker-handbook/)

[The official docker cheatsheet](https://www.docker.com/sites/default/files/d8/2019-09/docker-cheat-sheet.pdf)

[Docker-compose cheatsheet](https://devhints.io/docker-compose)

------
[Readme](../README.md) | [Session 2](s01e02.md)

---
[MIT Licensed](LICENSE) and prepared for Varsity College by [Cyber-Mint (Pty) Ltd](https://www.cyber-mint.com)<br>
TeamFu &trade; is trademark of Cyber-Mint (Pty) Ltd.<br>
&copy; Copyright 2020, Cyber-Mint (Pty) Ltd.  
