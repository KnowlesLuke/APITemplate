# API Endpoints
Each endpoint (with the exception being the CreateToken) requires a JWT Bearer token in order to be an authorised request.

# Table of Contents
1. [Authorisation](#authorisation)
    1. [Create Token](#createtoken)
2. [Get Accounts](#getaccounts)
3. [Get Accountt By Id](#getaccountbyid)

## Authorisation
The JWT token can be created by calling the **CreateToken** endpoint and passing 4 parameters to the body.

The details for the name, public key and action can be found in the AppManagement db.\
**Note (There are different identifiers for Read and Write actions.)**

## Create Token <a name="createtoken"></a>
### Example Body
```diff
POST - ApiTemplate/CreateToken
```

```json
{
  "name": "string",
  "secretKeyHash": "string",
  "publicKey": "string",
  "action": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```
### Example Response

✅ **200 Okay**
```diff
{
  eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.nXr32i0IbYSD7V3EKhyA1eA3_Lz28POavdBiPP0xKg8
}
```

## Get Accounts <a name="getaccounts"></a>

## Get Account By Id <a name="getaccountbyid"></a>
