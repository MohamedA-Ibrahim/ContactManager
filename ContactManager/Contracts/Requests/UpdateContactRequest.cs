namespace ContactManager.Contracts.Requests;

public class UpdateContactRequest
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Notes { get; set; }
}