# SuperHeroAPI

##To resolve: LHttpRequest at 'x' from origin 'y' has been blocked by CORS policy: No 'Access-Control-Allow-Origin' header is present on the requested resource.
  Add Microsoft.AspNetCore.Cors NuGet package to your API project and then adding CORS middleware to the program.cs file.
    1. dotnet add package Microsoft.AspNetCore.Cors
    2. Add the "AddCors" method to your builder.services, specify the origins, methods, etc.
    3. Add an app.use statement referencing your named policy BETWEEN UseRouting and UseAuthorization
    reference -> https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-7.0
    
