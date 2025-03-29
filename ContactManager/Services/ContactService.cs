using ContactManager.Contracts.Requests;
using ContactManager.Data;
using ContactManager.Data.Models;
using ContactManager.Helpers.Mappers;
using ContactManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Services;

public sealed class ContactService : IContactService
{
    private readonly AppDbContext _dbContext;

    public ContactService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Contacts.FirstOrDefaultAsync(c=> c.Id == id, cancellationToken);
    }
    public async Task<Contact> AddAsync(AddContactRequest request)
    {
        var contact = request.ToModel();

        await _dbContext.Contacts.AddAsync(contact);
        await _dbContext.SaveChangesAsync();

        return contact; 
    }
}
