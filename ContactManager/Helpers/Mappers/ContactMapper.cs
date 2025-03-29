using ContactManager.Contracts.Requests;
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
}
