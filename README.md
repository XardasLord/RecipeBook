# Shopping-List

Shopping-List is a project which is developing and has no rigidly requirements set. This is a web application allowing to manage recipes, ingredients and also add the ingredients from the recipe to the shopping list.

The project requirements are growing all the time and new features are adding one by one. Application has very solid backend architecture and it is important to me to keep it solid till the end of the project.

## Project structure
* **ShoppingList.Entities** - contains database entity classes.
* **ShoppingList.Database** - contains DbContexts and database migrations
* **ShoppingList.CommonUtilities** - this project will contain all cross-cutting concerns
* **ShoppingList.Domain** - its aim is to cover the bussiness logic. The Domain project has 3 subprojects:
  - **Domain** - contains abstractions like interfaces for services and queries and also contains class models for the view which are passing to the frontend user
  - **Implementation** -  contains implementations for services and queries from the Domain interfaces.
  - **Tests** - contains the domain unit tests.
* **ShoppingList.Infrastructure** - project which is based on the architecture app goals like for example sending emails mechanism. As the Domain project, Infrastructure has also 3 subprojects:
  - **Infrastructure** - contains abstractions like interfaces for the more architecture app tasks.
  - **Implementation** -  contains implementations from the Domain interfaces.
  - **Tests** - contains the tests for the tasks from Infrastructure project.
* **ShoppingList.Api** - this is the general API project. It has 2 subprojects:
  - **Api** - main .NET Core API. It contains controllers with endpoints to communicate with the frontend. This project also contains mappings from entity classes to the domain model classes which are send to the user.
  - **Tests** - contains tests for the API endpoints.
* **ShoppingList.Angular** - the frontend application built with Angular.


## Technology used

* Angular 7
* .NET Core 2.1
* Entity Framework Core
* SQL Server
* Automapper
* ...
* will be updated regularly... :)
