# Layers & Projects:

1. DataAbstraction: It contains interfaces IRepository.cs and IEntity.cs. 
I created for the dependency injection of our projects to be done on Abstractions and not Implementations.
The projects Domain.Models and Domain.Business depends on 'DataAbstraction' (abstraction) and not on 'Data' (implementation).
I did not include these interfaces in the same project 'Data' to separate the concerns.

2. Data: ApplicantRepository.cs
It implements IRepository<Applicant, int> interface and represents the data access layer.

3. Domain.Models: Applicant.cs
This project contains only the entities of our domain, and their corresponding Data Transfer Objects as well, and its validation using fluentValidation.

4. Domain.Business: ApplicantBusinessService.cs
This project contains only the BusinessService file of our domain. 
Each BusinessService file uses methods of the corresponding Repository to access data, and it has additional methods (OnAdding(), OnUpdating(), ...etc) which contains 
business rules if there are any.
I separated Domain project into two projects: Domain.Models and Domain.Business to separate the concerns.

5. Infrastructure: ApplicationDbContext.cs
This is the infrastructure layer, it contains our dbContext, and will contain migrations in the future.

6. API:
This project contains our RESTEndPoints, it uses the project Domain.Business.
ApplicantController depends on ApplicantBusinessService.cs.

7. MVC:
This project to have the views, MVC controller file uses API controller thru an ApiService.cs


# How To Use?
1. Clone the solution
2. Open the solution with Visual Studio 2019
3. Build and Run the solution, you will be introduced to a Swagger UI to start consuming the API RestEndPoints