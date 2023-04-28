# SuperHeroAPI

##To resolve: LHttpRequest at 'x' from origin 'y' has been blocked by CORS policy: No 'Access-Control-Allow-Origin' header is present on the requested resource.
  Add Microsoft.AspNetCore.Cors NuGet package to your API project and then adding CORS middleware to the program.cs file.
    1. dotnet add package Microsoft.AspNetCore.Cors
    2. Add the "AddCors" method to your builder.services, specify the origins, methods, etc.
    3. Add an app.use statement referencing your named policy BETWEEN UseRouting and UseAuthorization
    reference -> https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-7.0
    

## Add entity framework core using code first approach
    quick guide reference -> https://learn.microsoft.com/en-us/azure/azure-sql/database/azure-sql-dotnet-entity-framework-core-quickstart?view=azuresql&tabs=visual-studio%2Cservice-connector
    1. Add nuget packages
        Install-Package Microsoft.EntityFrameworkCore
        Install-Package Microsoft.EntityFrameworkCore.SqlServer
        Install-Package Microsoft.EntityFrameworkCore.Design

    2. Add a ConnectionStrings section to the appsettings.Development.json

    3. Add code to the program.cs file to integrate
        You will need to declare the model & the DBContext as well
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connection));

    4. Run dotnet command to create initial migration
        dotnet ef migrations add Initial

    5. Run dotnet command to apply initial migration to the database itself
        dotnet ef database update


## Add Entity framework core using Database First approach - Scaffolding/ Reverse Engineering

    ** If you use Visual Studio, try out the EF Core Power Tools community extension -> https://github.com/ErikEJ/EFCorePowerTools/.
    These tools provide a graphical tool which builds on top of the EF Core command line tools and offers additional workflow and customization options.

    1. Create the database object first
        CREATE TABLE SuperHero
        (
            Id INT PRIMARY KEY,
            Name NVARCHAR(MAX) NOT NULL,
            FirstName NVARCHAR(MAX) NOT NULL,
            LastName NVARCHAR(MAX) NOT NULL,
            Place NVARCHAR(MAX) NOT NULL
        );

    2. On your local terminal, login to the azure cli
         az login

    3. Run the scaffold command in the .net core CLI located at the root of the projects directory
        **note,
            if you already have a model file established before running this command, you will need to add "--force" to the end of the statement to overwrite the file
            If you have a particular target directory you would like the context or the entity classes, use the  --output-dir, and --context-dir commands

        Directly run command and inject the server URL
            dotnet ef dbcontext scaffold "Server=tcp:superherosqlserver.database.windows.net,1433;Initial Catalog=SuperHeroDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";" Microsoft.EntityFrameworkCore.SqlServer --force --context-dir Data --output-dir Models

        Read the connection string from configuration
            dotnet ef dbcontext scaffold "Name=ConnectionStrings:AZURE_SQL_SUPERHERODB" Microsoft.EntityFrameworkCore.SqlServer


    4. now the model files representing the tables have been created and the DBContext reflecting the database