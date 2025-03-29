using System.ComponentModel.DataAnnotations;

namespace ContactManager.Data.Models;

public class Contact
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(20)]
    public string Phone { get; set; } = null!;

    [MaxLength(100)]
    public string Address { get; set; } = null!;

    [MaxLength(500)]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }
}
