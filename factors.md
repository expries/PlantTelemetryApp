
# Factors implemented

## 1. Codebase

The codebase is tracked in GitHub https://github.com/expries/PlantTelemetryApp

Multiple deploys are achieveable through GitHub Actions. The App is published the DockerHub as demo

## 2. Dependcies

External dependencies are separated into their own projects. 

E.g. the PlantTelemetryApp.DataAcess project contains the MS-SQL dependency.

Other datastore can easily be used instead.

## 3. Config

The configuration can be set using `appsettings.json` (for e.g. developing locally).

But the configuration values can be overwritten using environment variables.

In the `docker-compose.yml` the setting for the database connectionstring is overwritten 
using the environment variables `ConnectionStrings__Database`

## 5. Build, release, run

The build is performed in the GitHub Actions stage before publishing to DockerHub.

The DockerHub image is run separately on the target machine

## 6. Processes

The backend service is a stateless REST-API. It does not have any state as the state is 
stored in the MS-SQL database

## 7. Port binding

Services are exposed via port bindings which can be configured either in the `launchsettings.json`
(for e.g. local development) or can be set using the port bindings of docker. One such example is the 
ports-section for the service in the docker-compose.yml.

## 9. Disposability

The app implements graceful shutdown as any resources such as used ports are released by ASP.NET 
when exiting the program. For example when stopping the app using CTRL+C

## 10. Dev/prod parity

Would only be natural using the Docker image. But this example does not have multiple stages

## 11. Logs

App writes to stdout and has multiple output destinations that are maanged by NLog. The console is one 
output the logfile is another output.

## 12. Admin processes

There are no admin tasks in this app ¯\_(ツ)_/¯