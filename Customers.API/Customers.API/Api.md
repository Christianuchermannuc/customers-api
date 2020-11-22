# Get all Customers



```http
GET /api/customers/
```


## Success Response

**Code** : `200 OK`

Return list of customers

```json

[
    {
        id:"9c4a578b-832b-4a42-8084-b41763a24741",
        name:"Test","type":"Sole proprietorship",
        year:2000,
        numberOfOwners:1,
        shareCapital:50000
    },
    {
        id:"9c4a578b-832b-4a42-8084-b41433a24741",
        name:"BKK","type":"Sole proprietorship",
        year:2010,
        numberOfOwners:6,
        shareCapital:500005
    }
]
    

```

# Add customer

Add a new customer

```http
POST /api/customers
```

**Input values**




**Body**

```json
    {        
        name:"Test","type":"Sole proprietorship",
        year:2000,
        numberOfOwners:1,
        shareCapital:50000
    }
```

## Success Response

**Code** : `200 OK`

Return new customer with id

```json
{
    id:"9c4a578b-832b-4a42-8084-b41763a24741",
    name:"Test","type":"Sole proprietorship",
    year:2000,
    numberOfOwners:1,
    shareCapital:50000
}
```

## Error Response

**Condition** : Data is not valid.

**Code** : `400 BAD REQUEST`

**Content** :

Error message description

# Delete customer

Delete a customer from Cosmos database

```http
DELETE /api/Customers/{id:string} 
```

**Input values**


| Parameter          |               |
| :-------------- | :------------ |
| `id` | Customers id|



## Success Response

**Code** : `200 OK`

User is deleted

## Error Response

**Condition** : Internal error occurred.

**Code** : `400 BAD REQUEST`

