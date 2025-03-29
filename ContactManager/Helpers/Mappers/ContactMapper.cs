using ContactManager.Contracts.Requests;
using ContactManager.Contracts.Responses;
using ContactManager.Data.Models;

namespace ContactManager.Helpers.Mappers;

public static class ContactMapper
{
    public static Contact ToModel(this AddContactRequest request)
    {
        return new Contact
        {
            Name = request.Name,
            Address = request.Address,
            Notes = request.Notes,
            Phone = request.Phone
        };
    }

    public static ContactResponse ToResponse(this Contact contact)
    {
        return new ContactResponse
        {
            Id = contact.Id,
            Name = contact.Name,
            Address = contact.Address,
            Notes = contact.Notes,
            Phone = contact.Phone
        };
    }
}
