# Infrastructure Layer

This layer handles the configuration of Entity Framework, Emails etc.

Infrastructure classes implement interfaces found in the Application Project. It is the direct link between the database and the application.
The repositories folder contains the calls to the database for the application. The configurations and DbContextSetup are used for the configuration of EF.
The Migrations folder holds a list of database changes/migrations for the localdb.
