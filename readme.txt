Make sure you EF Core CLI tools installed globally:

    dotnet tool install --global dotnet-ef

### During Development: (using the (dotnet ef) CLI):
1. adding the migration script:

       cd /path/to/Sports_Admin/Api

       dotnet ef migrations add AddYOUR_NEW_ENTITY_HERE --project ../Infra
 
2. database migrations:


       cd /path/to/Awqaf.Application

       dotnet ef database update -- --environment Development

### During Deployment: (using the (dotnet ef) CLI):
database migrations:


       cd /path/to/Awqaf.Application

       dotnet ef database update



