# A Practitioners Approach to DevOps

## Introduction

This enablement programme is aimed at computer science lecturers & lab assistants who are actively involved in teaching programming courses and wish to be given hands-on experience of DevOps from an industry practitioners perspective. This is not intended to be an academic course.  It is however an opinionated collation of the most common DevOps tools & practices that all new software engineering graduates are expected to master soon after starting employment at most enterprises who operate medium to large technology teams.  This programme makes no assumptions about choice of programming language and can work equally well with python, Java or C# as development language of choice.

We will be building a simple multi-user **ToDo** application with a RESTful server as backend (& a separate database) and a ReactJS front end.  The practitioners approach to CI/CD pipeline will be to systematically build up our skills and experience with various aspects of the pipeline as we continue to expand our application on a week by week basis.  We will conclude the 11 week season with fully a functional application and a set of fully functional pipelines and reproducible CI/CD environments.

The intention is that this process could be replicated by the lecturers with their students.  This is a low cost & low barrier to entry for experiencing CI/CD & practical DevOps as may be required by Industry today.

## Methodology

The programme takes place over eleven weeks.  For fun we have called this `SEASON 01` and each week an episode eg `S01.E01`.  There will be two x 2hr Google Teams sessions with the lecturers each week and a compulsory 0.5 hr daily "stand-ups" on no-session days to monitor self-work progress.  The attendees are broken into teams of two or three, each with their own team git repo & team wiki which is published to daily.

## Facilitator(s)

```
Grant Miller & Bank-Builder
```



### Programme Prep
**Lecturers** are required to:
- disable hyperV in windows & enable VT-x virtualisation (or non-INTEL equivalent) extension in BIOS to install VirtualBox
- to run multiple VM's locally recommend 16GB RAM + SSD HDD
- install Virtual Box or Dual Boot Linux
- allocate 2 CPU's min + 8 GB RAM + 100++ GB HDD (elastic resizing)
- download ubuntu 20.04 Desktop LTS ISO & install
- install vscode
- configure VM bridge networking to host
- login to Ubuntu and play around

**Sys Admin**
- allocate 3 x VMs on shared network ie can see each other
- provide access to VM's full access
- install Ubuntu Server LTS with ONLY ssh + user: vagrant + pw: whatever
- turn external access off until we are ready
- these can be Azure/on-prem VM's (turn them off when not in use)


---

## S01.E01: Introduction + GitHub + cli

### Prep
- Techradar (focus on DevOps toolchain example)
- DevOps Toolchain chart (with a few gaps for us to fill in together)
- End Game picture (docker-compose with provision + harden + deploy + test + logs {graphana + promethius} )
- git & github
- linux shell
- vision board for a Team based ToDo app with CLI, Rest API & React Front End ...
- any language : python/Java/c#/whatever-rocks-your-boat


### Session
- Overiew :: PPT on DevOps + the tool chain we will be using
- Github :: git tips + PR's, + Wiki + 
- git
- linux command line in 30 minutes
```
sudo apt-get update -y && sudo apt upgrade -y
sudo apt-get install terminator
sudo apt get install git
git --help
# add ssh key + git settings
# useful git commands
cd ~
mkdir -p dev/wiki
cd ~/dev/wiki
git init
# touch and push
# java hello world todo application + simple unit tests
```
- setup one repo per three lecturers
- add branch rules + enforce PRs on wiki and hello-world repo


### Self Work
- read up on swagger & openapi specification
- update your wiki with learnings so far
- update wiki


---

## S01.E02 Docker & Docker-Compose
### Prep
- installing docker & docker-compose
- create Dockerfile
- build hello-world java app & add to container
- connect hello-world to database (mysql)
- create docker-compose

### Session
- Install & learn docker & docker-compose
- docker commands + docker volumes + docker images + docker logs
- FROM java container + install other dependencies (single step container incl build)
- Have working `varistycollege/hello-world:0.1` container
- create database in container with `__vc.user` table & populate with data
```
docker exec -it vcdb mysql --host 0.0.0.0 -u root -p
mysql> source /sql/mydatabase.sql
```
- read data in Hellow-World application
- add COMMAND VARS in docker-compose for Database User etc

### Self-Work
- change to postgres:latest database
- update wiki

---

## S01.E03 Flyway

### Prep
- call Flyway in separate container
- execute mydatabase-V0.etc.sql
- add a `CMD [startup.sh]` which runs Flyway
- add a db readiness check
- add a health check to containers
- create a build step for containers 
- create example ERD for ToDO application



### Session
- Introduction to Flyway and database migrations 
- Create Flyway migrations for Hello-World App
- Upgrade docker-compose to include .env vars for Flyway user
- rebuild containers (still all local)
- cleanup ToDo application + create an ERD for app
- apply flyway migrations

### Self-Work
- update database structure & initial data to near-final ERD
- update code with classes for data model + tests
- update wiki


---

## S01.E04: OpenAPI & Swagger & Postman

### Prep
- ensure autogeneration is working properly
- create generic ToDo Swagger
- create postman test & environment


### Session
- yaml (tricks & gotcha's)
- editor.swagger.io
- install postman
- install openAPI tools - `https://openapi-generator.tech/docs/installation`
   ** java version first
- autogenerate openAPI (Java)
- add simple API to application & integration tests
- implement REST methods that were auto generated from swagger

### Self-Work
- complete endpoint implementation
- add functional postman tests for each endpoint
- test postman locally against docker of app
- update wiki


---

## S01.E05: Ansible + VMs (local + cloud) + Docker registry

### Prep

- get an Azure or on-prem VM or local ubuntu vm with user vagrant & password ..
- create playbook to do initial setup & hardening
- extend playbook to deploy ToDo application (docker-compose) to VM
- pull container from `https://johanbostrom.se/blog/list-of-free-private-docker-registry-and-repository` somewhere when deploying 
`https://www.baeldung.com/linux/docker-compose-private-repositories`
`https://jfrog.com/blog/how-to-set-up-a-private-remote-and-virtual-docker-registry/`
- provision + ansible configure & harden + deploy

### Session
- introduction to Ansible Playbooks
- some basic examples + the cli for docker login
- building a playbook to configure + harden our target machine
- using a docker registry other than hub.docker.com + add our Todo:latest to external registry
- create a playbook to deploy your docker registry
- create a play book to deploy our docker-compose & pull from our newly deployed docker registry

### Self-Work
- tag and push latest ToDo app to private docker registry
- update wiki


---

## S01.E06: Create CI/CD Orchestration + Jenkins + sonarqube Environment

### Prep
- install sonarqube container 
`https://techexpert.tips/sonarqube/sonarqube-docker-installation/`
`https://hub.docker.com/_/sonarqube/`
- jenkins in docker (with blue ocean)
- playbook to deploy jenkins docker to CI/CD VM (or run locally)
`https://www.jenkins.io/doc/book/installing/docker/`

```
# See Cyber-Mint Jenkins Wiki
docker run --name jenkins-blueocean --rm --detach --network jenkins --env DOCKER_HOST=tcp://docker:2376 --env DOCKER_CERT_PATH=/certs/client --env DOCKER_TLS_VERIFY=1   --publish 8080:8080 --publish 50000:50000 --volume jenkins-data:/var/jenkins_home --volume jenkins-docker-certs:/certs/client:ro myjenkins-blueocean:1.1
```

### Session
- playbook(s) to deploy CI/CD environment to CI/CD VM and run docker-compose
- volume map all data and settings 
- tear down and rebuild to test persistence


### Self-Work
- create a simple workflow that clones & builds your code
- update wiki


---

## S01.E07: CI/CD Orchestration + Integration Testing + Github Integration

### Prep
- create an event workflow that builds containers on PR to master
- create an event workflow that pushes docker to private registry on tagged build
- create a manual build workflow that runs builds, runs unit tests, runs sonarqube + runs postman integration tests with failure on blockers

### Session
- create a manual build workflow that runs builds, runs unit tests, runs sonarqube + runs postman integration tests with failure on blockers
- create an event workflow that builds source and builds containers on PR to master


### Self-Work
- create an event workflow that pushes docker to private registry on tagged build
- update wiki
- research pipeline notifications to slack/MS Teams/rocketchat etc & try add to your pipeline



---

## S01.E08: Everything as code

### Prep
- playbook to backup jenkins & sonarqube config to git repo or rsync to local machine
`https://medium.com/@_oleksii_/how-to-backup-and-restore-jenkins-complete-guide-62fc2f99b457`
- teardown and rebuild everything
- playbooks for everything
- add #pipeline channel to chosen IM (slack/Teams/RocketChat etc) 


### Session
- everything as code
- create a playbook to backup Jenkins & Sonarqube settings & data
- teardown and rebuild from source repo
- rebuild deploy VM, CI/CD VM
- add #pipeline notifications


### Self-Work
- update wiki
- tear-down and rebuild successfully

---

## S01.E09: Just let me develop!

### Prep
- add a javascript/typescript (ANgular/ReactJS) front end to project in separate repo
- build a separate container with front end application
- add this to docker-compose for local testing
- add this Front End to Jenkins build pipelines tagged & untagged

### Session
- add a javascript/typescript (ANgular/ReactJS) front end to project in seperate repo
- build a separate container with front end application
- add this to docker-compose for local testing
- add to untagged pipeline

### Self-Work
- add Front End UI (version 1) to tagged jenkins pipeline (npm build +  dockerise + sonarcloud + postman + push to registry)
- add UI docker to deploy job (playbook + jenkins job)
- register a cheap domain for your Todo app


---

## S01.E10: Pipeline & Deployment Security

### Prep
- configure guantlt with nmap tests
- add docker benchmark tests
- add nginx + self-signed certificates
- add nginx to docker-compose

### Session
- Security testing in pipeline
- Adding in reverse proxy (nginx) for http redirect & https
- Update firewall in playbook
- Introduce self-signed and letsencrypt (which require a domain name you control) certificates

### Self-Work
- get a letsencrypt cert fro your todo domain
- configure nginx to utilise this certificate & update deployment playbook & pipeline
- update wiki
- continue to improve your ToDo app for pipeline showdown in final session 


---

## S01.E11: End of Season 01

### Prep
- prepare a list of devops tech we did not cover
eg. kubernetes, the various pipelines like git, azure, aws, circleci, other cloud services eg jfrog etc
- secure application development
- docker security
- hint at what changes are coming ... eg `containerd` , etc ..


### Session
- Showdown between teams of their Applications & Pipelines
- Discussion of lessons learned
- A list of things yet unseen (all the DevOps stuff we did not cover in this Season 01)

### Self-Work
- learning never stops
- update your wiki



---
[MIT Licensed](.LICENSE) and prepared for Varsity College by [Cyber-Mint (Pty) Ltd](https://www.cyber-mint.com)<br>
&copy; Copyright 2020, Cyber-Mint (Pty) Ltd.  

