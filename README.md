# API_Design_GraphQL
API Design - GraphQL API

```POST https://localhost:7100/graphql``` 

```query {

books {
  bookId
  isbn
   title
   description
 }
}
```

<img width="2297" height="1229" alt="image" src="https://github.com/user-attachments/assets/f991fee5-d3d7-4f24-bd1f-6c175a56431b" />

```POST https://localhost:7100/graphql ```
```query {
 books {
  bookId
  isbn
   title
   description
   authors
   {
     authorId
     fullName
   }
    }
}
```

<img width="2532" height="1225" alt="image" src="https://github.com/user-attachments/assets/0e265754-59b0-4720-b443-1f577c740351" />
