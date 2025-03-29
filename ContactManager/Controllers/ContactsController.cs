using ContactManager.Contracts.Requests;
using ContactManager.Helpers.Mappers;
using ContactManager.Helpers.Validations;
using ContactManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    /// <summary>
    /// Add contact
    /// </summary>
    /// <param name="request">contact details</param>
    [HttpPost]
    public async Task<IActionResult> AddContact([FromBody] AddContactRequest request)
    {
        var validator = new AddContactValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            return BadRequest(validationResult);

        var contact = request.ToModel();

        await _contactService.AddAsync(contact);

        return Ok("Contact added successfully");
    }
}
