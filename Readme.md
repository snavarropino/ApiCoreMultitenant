# Asp.Net Core Api & Entity Framework Core Multitenant sample #

A sample implementation of an API that supports different database for different tenants.

Tenant is selected by a header received in every request: CompanyId

Usage:

- Clone
- Build
- Run

Once the Api is started, a couple of databases are automatically created on Sql Server LocalDb automatic instance

- EfCoreMultitenant-1-FirstStep
- EfCoreMultitenant-2-FirstStep

Each detabase has just ine table (Superheros) containing one row for Sergius superhero

Then you can send request to API that will insert a couple of rows in the Superheros 

         curl -X GET \
	        -H "CompanyId: 2" \
	        'http://localhost:5000/api/test/index'

As you can see we are sending a request for CompanyId=2 so rows are inserted in the database for this tenant (EfCoreMultitenant-2-FirstStep)