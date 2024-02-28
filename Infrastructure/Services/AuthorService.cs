namespace Infrastructure.Services;
using Domain.Models;
using Npgsql;
using Dapper;
public class AuthorService
{
    private string _connectionString = "Host=localhost;Port=5432;Database=.NetHw1;User id=postgres;Password=20080820";
    public List<Authors> GetAuthors()
    {
        using var connect = new NpgsqlConnection(_connectionString);
        return connect.Query<Authors>("select * from Authors").ToList();
    }
    public void AddAuthor(Authors author)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("insert into Authors(FullName)values(@fullName)",author);
    }
    public void UpdateAuthor(Authors author)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("update Authors set FullName = @fullName where Id = @id",author);
    }
    public void DeleteAuhtor(int id)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("delete from Authors where Id = @id",new {Id = id});
    }
    public void AddAuthorToBookbyhisId(int id1,int id2)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("insert into BookAuthors(BookId,AuthorId)values(@bookId,@authorId)",new {bookId = id1,authorId = id2});
    }
}
