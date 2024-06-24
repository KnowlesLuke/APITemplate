# API Layer

The API layer is the front facing application that is the interface to the outer world. This project receives the requests that are sent via controllers.

The interfaces are injected into the controllers via Dependency Injection. 

The overview of endpoints within the project can be found below, for detailed documentation of the endpoints please see Endpoints.md:

## Accounts
  - GET
    - SearchAccounts/{searchTerm}
  - POST
    - CreateAccount
  - PUT
    - UpdateAccount
  - DELETE
    - DeleteAccount/{accountId}

## Authorization
  - POST
    - CreateToken
