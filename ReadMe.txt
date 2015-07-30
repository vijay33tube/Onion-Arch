Project Setup for Mvc Arch POC

First install SQL Server Express 2008 R2 with the Northwind database attached.

From VS Extensions Manager install:
- NuGet package manager
- TestDriven.Net (if Resharper not installed)

1. Solution Structure
	Domain folder
		Domain.Entities project
			- POCO classes
		Domain.Interfaces project
			- Repository interfaces
	Infrastructure folder
		Infrastrcture.DependencyResolution
			- Used to set up Ninject bindings for web project
		Infrastructure.Data project
			- Respository impl (ORM)
			- References interfaces, entities
		Infrastructure.Interfaces project
			- Config service interface
			- Logging service interface
		Infrastructure.Logging
			- NLog logger
	Services folder
		Services.Interfaces project
			- Product service interface
			- References respository interfaces
			- References domain entities
	Tests folder
		Tests project
			Repositories folder
				- Repository unit tests
				- Repository integration tests
			Services folder
				- Services unit tests
				- Services integration tests
	.Web.Ui
		- ASP.NET MVC App
		- References interfaces, entities, data interfaces

2. NuGet Packages
	- Create Libs folder in solution directory
	- Add a Nuget.config file with location of Libs folder

3. Unit Tests
	- Tests.Domain: Reference interfaces, entities
	- Add FakeCategoryRepository, FakeProductRepository
	- Add NUnit, Moq NuGet packages
	- Write tests for methods in each repository

4. Data Access - NHibernate
	- Install Fluent NHibernate NuGet package
	- Reference Domain.Entities, Domain.Interfaces
	- Add CategoryRepository, ProductRepository
	- Add CategoryMap, ProductMap classes

5. Integration Tests
	- Create RepositoryTests class that uses config services
	
6. Dependency Injection - Ninject.MVC3
	- Add repository impl classes to Infrastructure.Data project
	- Add Ninject.MVC3 NuGet package to Web.Ui project
	- Add references to interfaces, entitis, data
	- Open App_Start and edit RegisterServices method in NinjectMCV3.cs
	- Call Bind on kernel to associate repository interfaces with impl classes

7. MVC Project
	- Add ProductViewModel to ViewModels folder
		> Properties: Categories, SelectedCategory, Products
	- Add Product controller (empty)
	- Provide ctor that accepts IProductService
	- In Index action call GetCategories GetProducts and create HomeViewModel