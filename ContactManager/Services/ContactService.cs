using ContactManager.Data;
using ContactManager.Data.Models;
using ContactManager.Services.Interfaces;

namespace ContactManager.Services;

public sealed class ContactService : IContactService
{
    private readonly AppDbContext _dbContext;

    public ContactService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> AddAsync(Contact contact)
    {
        await _dbContext.Contacts.AddAsync(contact);
        await _dbContext.SaveChangesAsync();

        return contact.Id;
    }
}
