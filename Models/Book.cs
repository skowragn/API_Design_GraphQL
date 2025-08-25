namespace BookstoreGraphQL.Models;

public record Book
{
   public int BookId { get; set; }
   public string? Isbn { get; set; }
   public string? Title { get; set; }
   public string? Description { get; set; }
   public ICollection<Author> Authors { get; set; } = [];

    public void AddAuthor(Author author)
    {
        Authors.Add(author);
    }
}
