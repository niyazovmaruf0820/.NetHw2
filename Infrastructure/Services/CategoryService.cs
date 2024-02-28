using Domain.Models;
using Npgsql;
using Dapper;
namespace Infrastructure.Services;

public class CategoryService
{
    private string _connectionString = "Host=localhost;Port=5432;Database=.NetHw1;User id=postgres;Password=20080820";
    public List<Categories> GetCategories()
    {
        using var connect = new NpgsqlConnection(_connectionString);
        return connect.Query<Categories>("select * form Categories").ToList(); 
    }
    public void AddCategory(Categories category)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("insert into Categories(Name)values(@name)",category);
    }
    public void UpdateCategory(Categories category)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("update Categories set Name = @Name where Id = @id",category);
    }
    public void DeleteCategory(int id)
    {
        using var connect = new NpgsqlConnection(_connectionString);
        connect.Execute("delete from Categories where Id = @id",new {Id = id}); 
    }
}
