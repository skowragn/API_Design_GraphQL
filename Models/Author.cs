namespace BookstoreGraphQL.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string? FullName { get; set; }
    public int BookId { get; set; }
}
