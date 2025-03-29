using ContactManager.Data.Models;

namespace ContactManager.Services.Interfaces;

public interface IContactService
{
    Task<Guid> AddAsync(Contact contact);
}
