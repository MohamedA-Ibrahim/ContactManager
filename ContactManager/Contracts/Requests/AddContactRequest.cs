namespace ContactManager.Contracts.Requests;

public class AddContactRequest
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Notes { get; set; }
}

