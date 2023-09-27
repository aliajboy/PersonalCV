using PersonalCV.Domain.Models;

namespace PersonalCV.Data.Interfaces;
public interface IContactMessage
{
    public Task<int> Add(ContactMessage contactMessage);

    public Task Delete(int id);

    public Task Edit(ContactMessage contactMessage);

    public Task<List<ContactMessage>> GetAll();

    public Task<ContactMessage> GetByName(string name);
}