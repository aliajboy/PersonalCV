using System.ComponentModel.DataAnnotations;

namespace PersonalCV.Domain.Models;
public class ContactMessage
{
    [Key]
    public int Id { get; set; }
    [MaxLength(150)]
    public required string Name { get; set; }
    [EmailAddress]
    [MaxLength(150)]
    public required string Email { get; set; }
    [Phone]
    [MaxLength(13)]
    public string? Phone { get; set; }
    [MaxLength(250)]
    public required string Subject { get; set; }
    public required string Message { get; set; }
}
