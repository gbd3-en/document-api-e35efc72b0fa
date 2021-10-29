# My Document API

This API will allow CRUD (Create, Read, Update, Delete) actions against documents.


## API Contract

### All Requests

All requests will return a `X-MyApplication-Identifier` header for informational purposes


### Get all available documents

GET /documents/all

```bash
curl --location --request GET 'http://localhost:5000/documents/all'
```

Response:
```json
[
    {
        "id": "001",
        "accessLevel": "Public",
        "title": "500-updated",
        "description": "A first step for a document, a giant leap for document-kind.",
        "sequenceNumber": 500,
        "createdOnDate": "1969-07-20T00:00:00",
        "lastModified": "2021-10-13T00:00:00"
    }
]
```


### Fetch a document by id

GET /documents/single?id=001

```bash
curl --location --request GET 'http://localhost:5000/documents/single?id=001'
```

Response:
```json
{
    "id": "001",
    "accessLevel": "Public",
    "title": "500-updated",
    "description": "A first step for a document, a giant leap for document-kind.",
    "sequenceNumber": 500,
    "createdOnDate": "1969-07-20T00:00:00",
    "lastModified": "2021-10-13T00:00:00"
}
```


### Create a new document

POST /documents

```bash
curl --location --request POST 'http://localhost:5000/documents' \
--header 'Content-Type: application/json' \
--data-raw '{
    "description": "A brand new document.",
    "accessLevel": "Public"
}'
```

Response:
```json
{
    "id": "003",
    "accessLevel": "Public",
    "title": null,
    "description": "A brand new document.",
    "sequenceNumber": 100,
    "createdOnDate": "2021-10-29T15:34:46.453022-04:00",
    "lastModified": "2021-10-29T15:34:46.453029-04:00"
}
```

### Update an existing document

POST /documents

```bash
curl --location --request PUT 'http://localhost:5000/documents' \
--header 'Content-Type: application/json' \
--data-raw '{
    "id": "003",
    "accessLevel": "Public",
    "description": "This document has been revised."
}'
```

Response:
```json
{
    "id": "003",
    "accessLevel": "Public",
    "title": "101-updated",
    "description": "This document has been revised.",
    "sequenceNumber": 101,
    "createdOnDate": "0001-01-01T00:00:00",
    "lastModified": "2021-10-29T15:41:13.402547-04:00"
}
```
