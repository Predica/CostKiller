# CostKiller .NET Library

This library helps you use CostKiller API from .NET project

### Supported API methods

 - CK_API_BUDGET_SYMBOL_ADD
 - CK_API_BUDGET_PROJ_DELETE
 - CK_API_BUDGET_PROJ_ADD
 - CK_API_DOC_GET
 - CK_API_DOC_SEARCH
 - CK_API_ALLOCATIONS_SEARCH
 - CK_API_CONTRACTOR_SEARCH

### What's new
- 1.0 - Initial release
- 1.2 - Open-source release: Refactored code, added comments

## How to use

```csharp
    //Creating CostKiller object
    using Predica.CostkillerLib;
    ...
    var costkiller = new Costkiller(new ConfigStore("Address=http://prod.costkiller.pl/;ApiKey=XXXXXXX;CompanyId=XXX;"));
    var costkiller2 = new Costkiller("http://prod.costkiller.pl/", "XXXXXXX", 123);
    //Searching documents
    var documents = costkiller.SearchDocuments();
    //Adding budget lines
    // - FirstYour assign your object that implements IDataSource
    costkiller.DataSource = new MyDataSource(); 
    costkiller.AddBudgetLines("MyProject");
```

#### Future plans

 - 1.3 - NuGet Release
    - Refactor with SOLID principles
    - IoC
    - Unit Tests

#### License
BSD

#### Other
Maintained by Predica Sp z. o.o.
