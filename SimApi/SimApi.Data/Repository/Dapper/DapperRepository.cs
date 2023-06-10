using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimApi.Base;
using SimApi.Data.Context;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace SimApi.Data.Repository;

public class DapperRepository<Entity> : IDapperRepository<Entity> where Entity : BaseModel
{
    protected readonly SimDapperDbContext dbContext;
    private bool disposed;
    private IEnumerable<PropertyInfo> GetProperties => typeof(Entity).GetProperties();


    public DapperRepository(SimDapperDbContext dbContext)
    {
        this.dbContext = dbContext;


    }
    public void DeleteById(int id)
    {
        using (var connection = dbContext.CreateConnection())
        {
            var result = connection.Execute($"DELETE FROM {typeof(Entity).Name} WHERE Id=@Id", new { Id = id });


        }
    }

    public List<Entity> Filter(string sql)
    {
        throw new NotImplementedException();
    }

    public List<Entity> GetAll()
    {
        var tablename = this.UppercaseFirst(typeof(Entity).Name);
        using (var connection = dbContext.CreateConnection())
        {
            var result = connection.Query<Entity>($"SELECT * FROM dbo.{tablename}");
            return result.ToList();
        }

    }

    public Entity GetById(int id)
    {
        var tablename = this.FirstCharToLowerCase(typeof(Entity).Name);

        using (var connection = dbContext.CreateConnection())
        {
            var result = connection.QuerySingleOrDefault<Entity>($"SELECT * FROM dbo.{tablename} WHERE \"Id\"=@Id", new { Id = id });
            if (result == null)
                throw new KeyNotFoundException($"{typeof(Entity).Name} with id [{id}] could not be found.");

            return result;
        }
    }

    public void Insert(Entity entity)
    {
      /*  var sql = "INSERT INTO dbo.\"Account\" (\"CreatedAt\",\"CreatedBy\",\"CustomerId\",\"AccountNumber\",\"Name\",\"OpenDate\",\"IsValid\",\"Balance\")" +
            "VALUES (@CreatedAt,@CreatedBy,@CustomerId,@AccountNumber,@Name,@OpenDate,@IsValid,@Balance)"; */

        var insertQuery = GenerateInsertQuery();

        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            var result = connection.Execute(insertQuery, entity);
            connection.Close();
        }

    }

    public void Update(Entity entity)
    {

    }
    private string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }
    private string FirstCharToLowerCase(string str)
    {
        if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
            return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str[1..];

        return str;
    }

    private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
    {
        return (from prop in listOfProperties
                let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                select prop.Name).ToList();
    }
    private string GenerateInsertQuery()
    {
        var tablename = this.FirstCharToLowerCase(typeof(Entity).Name);
        var insertQuery = new StringBuilder($"INSERT INTO dbo.{tablename} ");

        insertQuery.Append("(");

        var properties = GenerateListOfProperties(GetProperties);
        properties.ForEach(prop => { insertQuery.Append($"{prop},"); });

        insertQuery
            .Remove(insertQuery.Length - 1, 1)
            .Append(") VALUES (");

        properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

        insertQuery
            .Remove(insertQuery.Length - 1, 1)
            .Append(")");

        return insertQuery.ToString();
    }
}
