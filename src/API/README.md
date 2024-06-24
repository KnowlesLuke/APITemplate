# API Layer

The API layer is the front facing application that is the interface to the outer world. This project receives the requests that are sent via controllers.

The list of endpoints within the project can be found below:

## Accounts
  - GET
    - GetAccounts
    - GetAccountById/{accountId}
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
