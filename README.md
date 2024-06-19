![.NET Core](https://github.com/KnowlesLuke/APITemplate/actions/workflows/dotnet.yml/badge.svg)

# API Template Project

### This is the template used as a base for creating new API's.
## Directory Structure

/src - The source folder is the codebase for the application. It is further split into 4 projects. Click on each project to see the detail of what each contains.\
/tests - The tests folder contains all of the unit, integration & in future the functional tests for the application.

## Project Overview
This project uses a loose version of clean architecture, cutting some corners to save layers of abstraction which are seen as overkill for our applications.

- It uses .NET 8 throughout each project which is the latest version (at time of writing)
- It uses EFCore to handle database interaction. Ef Core can also be used in contingency with using Stored Procedures.
  - It uses localdb for local development and the dev server for publishing to development.
- It uses XUnit as a testing framework to perform unit and integration tests.
- Swagger is integrated and used for testing locally on your machine.
- It uses JWT to authorize requests.
  - The JWT tokens can be generated via the AuthorizationController -> CreateToken Endpoint.
  - Auth is split between read and write for security reasons (View the AppManagement database to see the details of each project).
- Each time a merge or push to the master branch is made, a GitHub action will run and ensure that the project builds and all tests pass.

## How to begin
To use this template as a starting point, click the green _Use This Template_ button at the top right of the repository. This will clone the repo into a new repository and allow you to work on a new project without having to push any changes back to the existing repo.\

Should you find an issue in the template, please log it in the Issues tab.
