namespace Infrastructure;

using Dapper;
using Npgsql;


using Domain;
public class BookService
{
    private string _connectionString = "Host=localhost;Port=5432;Database=.NetHw1;User id=postgres;Password=20080820";
    public List<Books> GetBooks()
    {
        using var connect = new NpgsqlConnection(_connectionString);
        return connect.Query<Books>("select b.Title,b.Description,b.DatePublished,b.PageQuantity,c.Name as CategoryName from Books as b join Categories as c on b.CategoryId = c.Id ").ToList(); 
    }
    public void AddBook(Books book)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("insert into Books(Title,Description,DatePublished,PageQuantity,CategoryId)values(@title,@description,@datepublished,@pagequantity,@categoryid)", book);
    }
    public void UpdateBook(Books book)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("update Books set Title = @title,Description = @description,DatePublished = @datepublished,PageQuantity = @pagequantity,CategoryId = @categoryid where Id = @id",book);
    }
    public void DeleteBook(int id)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("delete from Books where Id = @id",new {Id = id});
    }
    public Books GetBookById(int id)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        return connect.Query<Books>("select * from Books where Id = @id",new{Id=id}).FirstOrDefault()!;
    }
    public Books GetBookByTitle(string title)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        return connect.Query<Books>("select * from Books where Title = @title",new{title=title}).FirstOrDefault()!;
    }
    public List<Books> GetBooksByCategory(string category)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        return connect.Query<Books>("select * from Books as b join Categories as c on b.CategoryId = c.Id where c.Name = @Name",new{Name=category}).ToList();
    }
    public List<Books> GetAuthorOfBookByHisId(int id)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        return connect.Query<Books>("select a.FullName as AuthorName from BookAuthors as ba join Books as b on ba.BookId = b.Id join Authors as a on ba.AuthorId = a.Id where b.Id = @id",new{Id = id}).ToList()!;
    }
    public List<Books> GetBooksByHisAuthorsId(int id)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        return connect.Query<Books>("select b.Title from BookAuthors as ba join Books as b on ba.BookId = b.Id join Authors as a on ba.AuthorId = a.Id where a.Id = @id",new {Id = id}).ToList();
    }
}

