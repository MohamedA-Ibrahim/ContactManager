using System.ComponentModel.DataAnnotations;

namespace ContactManager.Contracts.Responses;

public class ContactResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } 
    public required string Phone { get; set; } 
    public required string Address { get; set; }
    public required string? Notes { get; set; }
}
