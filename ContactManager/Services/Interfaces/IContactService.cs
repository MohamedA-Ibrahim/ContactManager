using ContactManager.Contracts.Requests;
using ContactManager.Data.Models;

namespace ContactManager.Services.Interfaces;

public interface IContactService
{
    Task<Contact> AddAsync(AddContactRequest request);
    Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
