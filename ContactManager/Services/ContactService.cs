using ContactManager.Contracts;
using ContactManager.Contracts.Filters;
using ContactManager.Contracts.Requests;
using ContactManager.Contracts.Responses;
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


    public async Task<PaginatedResult<ContactResponse>> GetAllAsync(GetAllContactsFilter filter, PaginationFilter paginationFilter, CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.Contacts
            .CountAsync(cancellationToken);

        var query = _dbContext.Contacts.AsQueryable();
        query = AddFilter(query, filter);

        var contacts = await query
              .OrderBy(u => u.CreatedAt)
              .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
              .Take(paginationFilter.PageSize)
              .Select(c => new ContactResponse
              {
                  Id = c.Id,
                  Name = c.Name,
                  Phone = c.Phone,
                  Address = c.Address,
                  Notes = c.Notes
              })
              .ToListAsync(cancellationToken);

        return new PaginatedResult<ContactResponse>
        {
            Items = contacts,
            Page = paginationFilter.PageNumber,
            PageSize = paginationFilter.PageSize,
            TotalCount = totalCount,
        };
    }

    private static IQueryable<Contact> AddFilter(IQueryable<Contact> query, GetAllContactsFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Name))
            query = query.Where(c => c.Name.Contains(filter.Name));

        if (!string.IsNullOrEmpty(filter.Phone))
            query = query.Where(c => c.Phone.Contains(filter.Phone));

        if (!string.IsNullOrEmpty(filter.Address))
            query = query.Where(c => c.Address.Contains(filter.Address));

        return query;
    }

    public async Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Contacts.FirstOrDefaultAsync(c=> c.Id == id, cancellationToken);
    }

    public async Task<Contact> AddAsync(AddContactRequest request)
    {
        var contact = request.ToModel();
        
        contact.CreatedAt = DateTime.UtcNow;

        await _dbContext.Contacts.AddAsync(contact);
        await _dbContext.SaveChangesAsync();

        return contact; 
    }

}
