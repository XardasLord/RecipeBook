# RecipeBook

RecipeBook is a project which is developing and has no rigidly requirements set. This is a web application allowing to manage recipes, ingredients and also add the ingredients from the recipe to the shopping list.

The project requirements are growing all the time and new features are adding one by one. **Application has very solid backend architecture and it is important to me to keep it solid till the end of the project**.

## Project structure
* **RecipeBook.Entities** - contains database entity classes.
* **RecipeBook.Database** - contains DbContexts and database migrations
* **RecipeBook.CommonUtilities** - this project will contain all cross-cutting concerns
* **RecipeBook.Security** - contains some security application settings and classes which encrypt passwords
* **RecipeBook.Business** - its aim is to cover the bussiness logic. The Business project has 3 subprojects:
  - **Business** - contains abstractions like interfaces for helpers and also contains class models for the view which are passing to the frontend user
  - **Implementation** -  contains implementations for handlers using the CQRS pattern.
  - **Tests.Unit** - this is a unit tests project. It tests handlers and helpers method using NUnit, Moq and FluentAssertions libraries
* **RecipeBook.Infrastructure** - project which is based on the architecture app goals like for example sending emails mechanism. As the Domain project, Infrastructure has also 3 subprojects:
  - **Infrastructure** - contains abstractions like interfaces for the more architecture app tasks.
  - **Implementation** -  contains implementations from the Domain interfaces.
  - **Tests** - contains the tests for the tasks from Infrastructure project (TODO implementation).
* **RecipeBook.Api** - this is the general API project. It has 2 subprojects:
  - **Api** - main .NET Core API. It contains controllers with endpoints to communicate with the frontend. This project also contains mappings from entity classes to the domain model classes which are send to the user.
  - **Tests** - contains tests for the API endpoints (TODO implementation).
* **RecipeBook.Angular** - the frontend application built with Angular 7 and Bootstrap v4.2.1.


## Technology used

* Angular 7
* .NET Core 2.2
* Entity Framework Core 2.1
* SQL Server
* Automapper
* NLog
* JWT for authorization
* MediatR (with QueryHandlers and CommandHandlers)
* Unit Tests: NUnit, Moq, FluentAssertions
* ...
* will be updated regularly... :)
