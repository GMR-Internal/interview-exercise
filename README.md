# GMR App Team Exercise

The purpose of this repository is to be an example of a "real-world" API that our team would manage. It has three main
resources. Each of these resources has its own Service and Controller for basic CRUD operations.

- Employees
- Customers
- Projects

You can run this project locally using SQLite if you'd like, but it is not required.

## Running Locally

In a command prompt or terminal, execute the following commands:

```
cd Gmr.Interview.Example.Api

dotnet build

dotnet ef database update

dotnet run
```

You can access the Swagger Docs page at [https://localhost:5001/swagger](https://localhost:5001/swagger)

## Possible Discussion Questions:

- How would you go about adding a new property to the Customer entity and exposing it via the API?
- Explain how you would add the ability to filter projects by ProjectName
- How would you add a new endpoint to return only active projects
- If an employee was not being returned with the GET endpoint, how would you go about
  troubleshooting the issue?