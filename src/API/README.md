# API Layer

The API layer is the front facing application that is the interface to the outer world. This project receives the requests that are sent via controllers.

The interfaces are injected into the controllers via Dependency Injection for abstraction.

To view the detail of the endpoints for this project please view the Endpoints.md (also in this directory)

## Accounts
  - GET
    - SearchAccounts/{searchTerm}
  - POST
    - CreateAccount
  - PUT
    - UpdateAccount
  - DELETE
    - DeleteAccount/{accountId}
