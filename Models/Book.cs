namespace BookstoreGraphQL.Models;

public class Book
{
   public int BookId { get; set; }
   public string? Isbn { get; set; }
   public string? Title { get; set; }
   public string? Description { get; set; }
   public ICollection<Author> Authors { get; } = [];
   public int CartItemId { get; set; }

   public void AddAuthor(Author author)
   {
      Authors.Add(author);
   }
}
