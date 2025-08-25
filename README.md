# API_Design_GraphQL
API Design - GraphQL API

<img width="524" height="220" alt="image" src="https://github.com/user-attachments/assets/8bf3d863-cd63-4ec7-a4df-fe5437841995" />
<img width="340" height="248" alt="image" src="https://github.com/user-attachments/assets/d2931588-d3bb-4847-b677-b54e9eca0058" />



<img width="2376" height="707" alt="image" src="https://github.com/user-attachments/assets/1cf7e139-7ce5-445f-8307-ba3ce699012f" />




Please open:
```https://localhost:7100/ui/altair```




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


# References
https://blog.devgenius.io/building-graphql-apis-in-net-8-0-a-step-by-step-guide-c9152a94769c
https://medium.com/@ozgurtaylann/exploring-graphql-with-asp-net-core-a-practical-guide-to-efficient-api-design-fc5caac9da53
https://dev.to/berviantoleo/getting-started-graphql-in-net-6-part-1-4ic2
