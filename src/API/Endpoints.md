# API Endpoints

Each endpoint (with the exception being the CreateToken) requires a JWT Bearer token in order to be an authorised request.

## Authorisation & JWT
The JWT token can be created by calling the **CreateToken** endpoint and passing 4 parameters to the body. The parameters are:

  - name
  - secretKeyHash
  - publicKey
  - action

