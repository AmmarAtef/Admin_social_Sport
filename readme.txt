Make sure you EF Core CLI tools installed globally:

    dotnet tool install --global dotnet-ef

### During Development: (using the (dotnet ef) CLI):
1. adding the migration script:

       cd /path/to/Awqaf.Application

       dotnet ef migrations add AddYOUR_NEW_ENTITY_HERE --project ../Awqaf.Infrastructure
       dotnet ef migrations add ManyApplicantTypeToSameApplicant --project ../Awqaf.Infrastructure
       dotnet ef migrations add MoreLookupsForAwjuhElSarf --project ../Awqaf.Infrastructure

       dotnet ef migrations add AddIssuanceCourtNewASarfSeeds --project ../Awqaf.Infrastructure
 
2. database migrations:


       cd /path/to/Awqaf.Application

       dotnet ef database update -- --environment malsati

### During Deployment: (using the (dotnet ef) CLI):
database migrations:


       cd /path/to/Awqaf.Application

       dotnet ef database update



