using ContactManager.Contracts;
using ContactManager.Contracts.Filters;
using ContactManager.Contracts.Requests;
using ContactManager.Contracts.Responses;
using ContactManager.Data.Models;

namespace ContactManager.Services.Interfaces;

public interface IContactService
{
    Task<Contact> AddAsync(AddContactRequest request);
    Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PaginatedResult<ContactResponse>> GetAllAsync(GetAllContactsFilter filter, PaginationFilter paginationFilter, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Guid id, UpdateContactRequest request);
}
