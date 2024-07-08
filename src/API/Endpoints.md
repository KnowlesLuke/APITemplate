# API Endpoints
Each endpoint (with the exception being the CreateToken) requires a JWT Bearer token in order to be an authorised request.

# Table of Contents
1. [Authorisation](#authorisation)
    1. [Create Token](#createtoken)
2. [Read Requests](#readrequests)
    1. [Get Accounts](#getaccounts)
    2. [Get Account By Id](#getaccountbyid)
    3. [Search Accounts](#searchaccounts)
3. [Write Requests](#writerequests)
    1. [Create Account](#createaccount)

## Authorisation
The JWT token can be created by calling the **CreateToken** endpoint and passing 4 parameters to the body.

The details for the name, public key and action can be found in the AppManagement db.\
**Note (There are different identifiers for Read and Write actions.)**

## Create Token <a name="createtoken"></a>
### Example Request - For read access
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

✅ **200 Okay** - _Returns JWT Token (for use in auth)_
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

### Example Request
```diff
GET - ApiTemplate/GetAccounts
```
### Example Response

✅ **200 Okay**
```json
[
  {
    "id": 17,
    "forename": "ABC",
    "surname": "string",
    "displayName": "ABC string",
    "username": "string",
    "email": "string",
    "token": "00000000-0000-0000-0000-000000000000",
    "roleId": 2,
    "created": "2024-05-14T15:18:37.1021",
    "modified": "2024-05-14T16:03:56.8270596"
  },
  {
    "id": 20,
    "forename": "fore1",
    "surname": "sur1",
    "displayName": "fore1 sur1",
    "username": "usr1",
    "email": "email@email.com",
    "token": "de4bbd50-12ec-443c-b19d-0a571d4206af",
    "roleId": 2,
    "created": "2024-06-18T11:25:03.0008777",
    "modified": null
  }
]
```


## Get Account By Id <a name="getaccountbyid"></a>
### Example Headers
```diff
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.nXr32i0IbYSD7V3EKhyA1eA3_Lz28POavdBiPP0xKg8
```

### Example Request
```diff
GET - ApiTemplate/GetAccountById/17
```

### Example Response

✅ **200 Okay**
```json
{
  "id": 17,
  "forename": "ABC",
  "surname": "string",
  "displayName": "ABC string",
  "username": "string",
  "email": "string",
  "token": "00000000-0000-0000-0000-000000000000",
  "roleId": 2,
  "created": "2024-05-14T15:18:37.1021",
  "modified": "2024-05-14T16:03:56.8270596"
}
```

## Search Accounts <a name="searchaccounts"></a>
### Example Headers
```diff
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.nXr32i0IbYSD7V3EKhyA1eA3_Lz28POavdBiPP0xKg8
```

### Example Request
```diff
GET - ApiTemplate/SearchAccounts/john
```

### Example Response

✅ **200 Okay**
```json
{
  "id": 23,
  "forename": "John",
  "surname": "Doe",
  "displayName": "John Doe",
  "username": "john.doe",
  "email": "john@doe.com",
  "token": "de4bbd50-12ec-443c-b19d-0a571d4206af",
  "roleId": 1,
  "created": "2024-05-15T15:18:37.1021",
  "modified": "2024-05-15T16:03:56.8270596"
}
```


## Write Requests <a name="writerequests"></a> 
The following are a list of requests that require write permission.


## Create Account <a name="createaccount"></a>
### Example Headers

```diff
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjcxMjYiLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjcxMjYiLCJleHAiOjE3MjA0NTAwNTUsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJBUElUZW1wbGF0ZSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiSWxjT1ZBSWdBN0p4UkVZZG1lbmNkWWVmZjU5TWxXRmNPWExkME9WSGhPQ2NkZmpmcFBpSDRrSElud3llQ1hMczhtQUJuNmE0OEtOejdpeVJiY2pWMGZ6NHpLMm9iZ2dTcFFoZ2NBWWxrdlZPQVh0NGVMQjBvbWFxekZWVlJKd1oiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiIhVGVzdFNlY3JldEtleUZvckFwcGxpY2F0aW9uMS1BcGlUM21QIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiV3JpdGUifQ.1tW-3WTN-lo02ghXpfFn2jP8tHtzXfbZvOQMKZOt2Rs

```
### Example Body
```json
{
  "forename": "Joe",
  "surname": "Bloggs",
  "username": "TMBC.Joe.Bloggs",
  "email": "joe.bloggs@tmbc.com",
  "roleId": 2,
  "createdBy": "User 1"
}
```

### Example Request
```diff
POST - ApiTemplate/CreateAccount
```

### Example Response
✅ **200 Okay**
```json
{
  "id": 25,
  "forename": "Joe",
  "surname": "Bloggs",
  "displayName": "Joe Bloggs",
  "username": "TMBC.Joe.Bloggs",
  "email": "joe.bloggs@tmbc.com",
  "token": "9bd4fe3f-3aed-426d-8747-ebd0094eff95",
  "roleId": 2,
  "created": "2024-05-16T15:18:37.1021",
  "modified": null
}
```
