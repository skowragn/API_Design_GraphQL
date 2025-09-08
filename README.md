# API_Design_GraphQL
API Design - GraphQL API

<img width="524" height="220" alt="image" src="https://github.com/user-attachments/assets/8bf3d863-cd63-4ec7-a4df-fe5437841995" />
<img width="340" height="248" alt="image" src="https://github.com/user-attachments/assets/d2931588-d3bb-4847-b677-b54e9eca0058" />



<img width="2376" height="707" alt="image" src="https://github.com/user-attachments/assets/1cf7e139-7ce5-445f-8307-ba3ce699012f" />




Please open:
```https://localhost:7100/ui/altair```

## Query

```POST https://localhost:7100/graphql``` 
```
query {

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

```
query {
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

```POST https://localhost:7100/graphql ```

```
query {
 book (bookId: 1) {
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

<img width="2480" height="928" alt="image" src="https://github.com/user-attachments/assets/d052846d-4f43-4a34-88e1-c1f37de04c26" />


```POST https://localhost:7100/graphql ```

```
query {
  cart(cartId: 1) {
    cartId
    userId
    items {
        cartItemId
        quantity
        price
        cartId
        book
        {
          bookId
          isbn
          title
          description
          authors {
              authorId
              fullName
              bookId
          }
        }
      }
     }
  }
```


<img width="2457" height="1057" alt="image" src="https://github.com/user-attachments/assets/5522d708-cd26-45f9-a898-be6110e21138" />


```POST https://localhost:7100/graphql ```

```
query {
  carts {
    cartId
    userId
    items {
        cartItemId
        quantity
        price
        cartId
        book
        {
          bookId
          isbn
          title
          description
          authors {
              authorId
              fullName
              bookId
          }
        }
      }
     }
  }
```

<img width="2491" height="1016" alt="image" src="https://github.com/user-attachments/assets/56c2b800-c469-461d-8ff2-177df298cc94" />




## Mutations
```POST https://localhost:7100/graphql ```

```
mutation {
  addAuthor(
    bookId: 1,
    author: {
      authorId: 6,
      fullName: "Joanna Chmielewska",
    }
  ) {
    bookId
    isbn
    title
    description
    authors {
        authorId
        fullName
        bookId
    }
  }
}
```

<img width="2286" height="1143" alt="image" src="https://github.com/user-attachments/assets/f37e4efa-69c9-48c0-ae4b-59a9398e8c56" />


#### Get book before adding a new author
```POST https://localhost:7100/graphql ```

```
query {
  book(
    bookId: 5,
  ) {
    bookId
    isbn
    title
    description
    authors {
        authorId
        fullName
        bookId
    }
  }
}
```
<img width="2470" height="714" alt="image" src="https://github.com/user-attachments/assets/307e0bd7-3107-48bd-866b-5c196b75f63e" />


#### Add author to book
```POST https://localhost:7100/graphql ```

```
mutation {
  addAuthor(
    bookId: 5,
    author: {
      authorId: 11,
      fullName: "Posw",
    }
  ) {
    bookId
    isbn
    title
    description
    authors {
        authorId
        fullName
        bookId
    }
  }
}
```

  <img width="2469" height="880" alt="image" src="https://github.com/user-attachments/assets/30e84806-8775-4a91-ba7f-ac5c781ceca7" />

  
#### Get book to check author had been added

```POST https://localhost:7100/graphql ```

```
query {
  book(
    bookId: 5,
  ) {
    bookId
    isbn
    title
    description
    authors {
        authorId
        fullName
        bookId
    }
  }
}
```

<img width="2486" height="883" alt="image" src="https://github.com/user-attachments/assets/37f8724e-6b28-4aa6-8d74-131f32ab0713" />


#### Delete author from book
```POST https://localhost:7100/graphql ```

```
mutation {
  deleteAuthor(
    bookId: 5,
    authorId: 11
     ) {
    bookId
    isbn
    title
    description
    authors {
        authorId
        fullName
        bookId
    }
  }
}
```
<img width="2482" height="776" alt="image" src="https://github.com/user-attachments/assets/869c6e56-9356-4c60-9589-f0a57765170c" />


#### Get book to check author had been added
```POST https://localhost:7100/graphql ```

```
query {
  book(
    bookId: 5,
  ) {
    bookId
    isbn
    title
    description
    authors {
        authorId
        fullName
        bookId
    }
  }
}
```
<img width="2470" height="714" alt="image" src="https://github.com/user-attachments/assets/03cfbf6e-3afb-422b-8508-c353cbc5b341" />


# References
https://blog.devgenius.io/building-graphql-apis-in-net-8-0-a-step-by-step-guide-c9152a94769c
https://medium.com/@ozgurtaylann/exploring-graphql-with-asp-net-core-a-practical-guide-to-efficient-api-design-fc5caac9da53
https://dev.to/berviantoleo/getting-started-graphql-in-net-6-part-1-4ic2
