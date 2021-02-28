# OpenAPI & Swagger & Postman Cheatsheet
[OpenAPI is a specification standard for RESTful API's](https://swagger.io/specification/), [Swagger is a toolset for creating/maintaining OpenAPI documents](https://swagger.io/tools/) and [Postman is a tool for testing RESTful API's](https://learning.postman.com/docs/getting-started/introduction/). 
Creating a RESTful API specification can be done in either JSON or YAML, but we prefer YAML because it supports comments and has less typing (no `{..}`).
The creation of a RESTful API allows us to adopt an [API first](https://swagger.io/resources/articles/adopting-an-api-first-approach/) approach that allows us to work on the definition of the interface between backend and frontend. This YAML document that we produce can be used for [generating backend stubs as well as generating client libraries](https://github.com/OpenAPITools/openapi-generator#overview). This code generation allows developers to focus on the implementation, rather than being code-monkeys. Boilerplate code is generated and the developers can focus on the good stuff.

## OpenAPI
It is useful to have the [current specification](https://swagger.io/specification/) open as a reference when building an API document. 

It is possible to use [Visual Studio Code plugin](https://marketplace.visualstudio.com/items?itemName=SmartBearSoftware.vscode-swaggerhub) for building OpenAPI Specification documents. 
If you prefer a browser experience using docker:
```
docker pull swaggerapi/swagger-editor:latest
docker run -d -p 8081:8080 swaggerapi/swagger-editor:latest
```
[...then you can open your locally hosted swagger api editor](http://localhost:8081)

[If you prefer a public website (just remember that you are sharing your designs with the swagger team)](https://editor.swagger.io)

## Tools

# References
[API first development](https://www.postman.com/use-cases/api-first-development/)
[VS Code plugin - Free security scanner for OpenAPI specifications](https://42crunch.com/tutorial-openapi-swagger-extension-vs-code/)


------
[Readme](../README.md) | [Session 4](s01e04.md)

---
[MIT Licensed](LICENSE) and prepared for Varsity College by [Cyber-Mint (Pty) Ltd](https://www.cyber-mint.com)<br>
TeamFu &trade; is trademark of Cyber-Mint (Pty) Ltd.<br>
&copy; Copyright 2020, Cyber-Mint (Pty) Ltd.  
