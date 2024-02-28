namespace Domain;


public class Books
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DatePublished { get; set; }
    public int PageQuantity { get; set; }
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? AuthorName { get; set; }
}
