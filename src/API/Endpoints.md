# API Endpoints
Each endpoint (with the exception being the CreateToken) requires a JWT Bearer token in order to be an authorised request.

# Table of Contents
1. [Authorisation](#authorisation)
    1. [Create Token](#createtoken)
2. [Read Requests](#readrequests)
    1. [Get Accounts](#getaccounts)
    2. [Get Account By Id](#getaccountbyid)

## Authorisation
The JWT token can be created by calling the **CreateToken** endpoint and passing 4 parameters to the body.

The details for the name, public key and action can be found in the AppManagement db.\
**Note (There are different identifiers for Read and Write actions.)**

## Create Token <a name="createtoken"></a>
### Example Body - For read access
```diff
POST - ApiTemplate/CreateToken
```

```json
{
  "name": "APITemplate",
  "secretKeyHash": "!TestSecretKeyForApplication1-ApiT3mP",
  "publicKey": "IlcOVAIgA7JxREYdmencdYeff59MlWFcOXLd0OVHhOCcdfjfpPiH4kHInwyeCXLs8mABn6a48KNz7iyRbcjV0fz4zK2obggSpQhgcAYlkvVOAXt4eLB0omaqzFVVRJwZ",
  "action": "775318C9-8F30-4293-A70B-EF57F305D035"
}
```
### Example Response

✅ **200 Okay**
```diff
{
  eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.nXr32i0IbYSD7V3EKhyA1eA3_Lz28POavdBiPP0xKg8
}
```

## Read Requests <a name="readrequests"></a> 
The following are a list of requests that require read permission/get requests.

## Get Accounts <a name="getaccounts"></a>
### Example Headers
```diff
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.nXr32i0IbYSD7V3EKhyA1eA3_Lz28POavdBiPP0xKg8
```

### Example Body
```diff
GET - ApiTemplate/GetAccounts
```
### Example Response
```json
{
  
}
```


## Get Account By Id <a name="getaccountbyid"></a>
