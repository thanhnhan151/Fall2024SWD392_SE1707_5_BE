using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

[Table("User")]
public class User : CommonEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ProfileImageUrl { get; set; } = "N/A";
    // Relationships

    public long RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;

    public ICollection<IORequest> IORequests { get; set; } = [];
    public ICollection<CheckRequest> CheckRequests { get; set; } = [];
}
