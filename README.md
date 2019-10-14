# MasteringToDoList
To Do List: is a .Net core 3 Web api and WPF application 


### Structure of Project
Repository include layers divided by **4 project**;
* Core
    * Entities    
    * Interfaces
    * Specifications
    * Exceptions
* Application    
    * Interfaces    
    * Services
    * Dtos
    * Mapper
    * Exceptions
* Infrastructure
    * Data
    * Repository
    * Services
    * Migrations
    * Logging
    * Exceptions
* WPF
    * Command
    * helpers
    * Models
    * ViewModels
    * Views
    * Services
    
### Core Layer
Development of Domain Logic with abstraction. Interfaces drives business requirements with light implementation. The Core project is the **center of the Clean Architecture** design, and all other project dependencies should point toward it. 

#### Entities
Includes Entity Framework Core Entities which creates sql table with **Entity Framework Core Code First Aproach**. Some Aggregate folders holds entity and aggregates.
You can see example of **code-first** Entity definition as below;
![Recordit GIF](https://cdn1.imggmi.com/uploads/2019/10/14/4427eda74c9c99190ee53d5335e517d6-full.gif)


```csharp
    public class Entity:IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid CreatedUser { get; set; }

        public Guid? UpdatedUser { get; set; }

        public DateTime? DeletedDate { get; set; }

        public Enums.Enums.DataStatus DataStatus { get; set; }
    }
```

```csharp
    public class ApplicationUser : IdentityUser
    {
        public override string Email { get; set; }

        public override string UserName { get; set; }
    }
```
```csharp
    public class ToDoList:Entity
    {
        public string Name { get; set; }
        public ApplicationUser User { get; set; }

        public List<ToDoItem> Items { get; set; }
    }
```

```csharp
    public class ToDoItem:Entity
    {
        public string Description { get; set; }

        public Status Status { get; set; }
        public DateTime DeadLine { get; set; }
        public ToDoList ToDoList { get; set; }
    }
```
```csharp
    public enum Status
    {
        Draft=0,
        InProgress=1,
        Complete=2
    }
```

#### Specifications
This folder is implementation of **[specification pattern](https://en.0wikipedia.org/wiki/Specification_pattern)**. Creates custom scripts with using **ISpecification** interface. Using BaseSpecification managing Criteria, Includes, OrderBy, Paging.
This specs runs when EF commands working with passing spec. This specs implemented SpecificationEvaluator.cs and creates query to ToDolistRepository.cs in ApplySpecification method.This helps create custom queries.

### Infrastructure Layer
Implementation of Core interfaces in this project with **Entity Framework Core** and other dependencies.
Most of your application's dependence on external resources should be implemented in classes defined in the Infrastructure project. These classes must implement the interfaces defined in Core. If you have a very large project with many dependencies, it may make sense to have more than one Infrastructure project (eg Infrastructure.Data), but in most projects one Infrastructure project that contains folders works well.
This could be includes, for example, **e-mail providers, file access, web api clients**, etc. For now this repository only dependend sample data access and basic domain actions, by this way there will be no direct links to your Core or UI projects.

#### Data
Includes **Entity Framework Core Context** and tables in this folder. When new entity created, it should add to context and configure in context.
The Infrastructure project depends on Microsoft.**EntityFrameworkCore.SqlServer** and EF.Core related nuget packages, you can check nuget packages of Infrastructure layer. If you want to change your data access layer, it can easily be replaced with a lighter-weight ORM like Dapper. 

#### Migrations
EF add-migration classes.
#### Repository
EF Repository and Specification implementation. This class responsible to create queries, includes, where conditions etc..
#### Services
Custom services implementation, like email, cron jobs etc.

### Application Layer
Development of **Domain Logic with implementation**. Interfaces drives business requirements and implementations in this layer.
Application layer defines that user required actions in app services classes as below way;


In this layer we can add validation , authorization, logging, exception handling etc. -- cross cutting activities should be handled in here.


### Test Layer
For each layer, there is a test project which includes intended layer dependencies and mock classes. So that means Core-Application-Infrastructure and Web layer has their own test layer. By this way this test projects also divided by **unit, functional and integration tests** defined by in which layer it is implemented. 
Test projects using **xunit and Mock libraries**.  xunit, because that's what ASP.NET Core uses internally to test the product. Moq, because perform to create fake objects clearly and its very modular.


## Technologies
* .NET Core 3
* ASP.NET Core 3
* Entity Framework Core 3 
* .NET Core Native DI
* AutoMapper
* WPF
* MVVM

## Architecture
* Clean Architecture
* Full architecture with responsibility separation of concerns
* SOLID and Clean Code
* Domain Driven Design (Layers and Domain Model Pattern)
* Unit of Work
* Repository and Generic Repository
* Specification Pattern
