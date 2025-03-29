using ContactManager.Contracts.Requests;
using ContactManager.Contracts.Responses;
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
    /// Get contact by id
    /// </summary>
    /// <param name="id">Contact Id</param>
    /// <param name="cancellation"></param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ContactResponse), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellation)
    {
        var contact = await _contactService.GetByIdAsync(id, cancellation);
        if (contact == null)
            return NotFound();

        var response = contact.ToResponse();

        return Ok(response);
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

        var addedContact = await _contactService.AddAsync(request);

        return CreatedAtAction(nameof(GetById), new { addedContact.Id }, addedContact);
    }
}
