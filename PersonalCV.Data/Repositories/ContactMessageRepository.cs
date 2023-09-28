using Dapper;
using Microsoft.Data.SqlClient;
using PersonalCV.Data.Interfaces;
using PersonalCV.Domain.Models;

namespace PersonalCV.Data.Repositories;
public class ContactMessageRepository : IContactMessage
{
    private readonly string? connString;

    public ContactMessageRepository(string connectionString)
    {
        connString = connectionString;
    }

    public async Task<int> Add(ContactMessage contactMessage)
    {
        string sql = "INSERT INTO ContactMessage ([Name],[Email],[Phone],[Subject],[Message]) OUTPUT INSERTED.ID VALUES (@Name,@Email,@Phone,@Subject,@Message)";
        int id;

        using (SqlConnection connection = new SqlConnection(connString))
        {
            id = await connection.QuerySingleAsync<int>(sql, new {
                Name = contactMessage.Name,
                Email = contactMessage.Email,
                Phone = contactMessage.Phone,
                Subject = contactMessage.Subject,
                Message= contactMessage.Message
            });
        }

        return id;
    }

    public async Task Delete(int id)
    {
        string sql = "DELETE FROM ContactMessage WHERE id = @Id";

        using (SqlConnection connection = new SqlConnection(connString))
        {
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }

    public async Task Edit(ContactMessage contactMessage)
    {
        string sql = "UPDATE ContactMessage SET [Name] = @Name,[Email] = @Email,[Phone] = @Phone,[Subject] = @Subject,[Message] = @Message WHERE Id = @Id";

        using (SqlConnection connection = new SqlConnection(connString))
        {
            await connection.ExecuteAsync(sql, contactMessage);
        }
    }

    public async Task<List<ContactMessage>> GetAll()
    {
        string sql = "select * from ContactMessage";

        IEnumerable<ContactMessage> contactMessages;

        using (SqlConnection connection = new SqlConnection(connString))
        {
            contactMessages = await connection.QueryAsync<ContactMessage>(sql);
        }

        return contactMessages.ToList();
    }

    public async Task<ContactMessage> GetByName(string name)
    {
        string sql = "SELECT * FROM ContactMessage where Name Like '%@Name%'";
        ContactMessage contactMessage;

        using (SqlConnection connection = new SqlConnection(connString))
        {
            contactMessage = await connection.QueryFirstOrDefaultAsync<ContactMessage>(sql, new { Name = name });
        }

        return contactMessage;
    }
}