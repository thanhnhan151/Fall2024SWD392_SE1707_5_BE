using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

public partial class User : CommonEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Role { get; set; }//STAFF, MANAGER, ADMIN
    public string? ProfileImageUrl { get; set; }


    // Relationships
    public ICollection<IORequest> IORequests { get; set; } = [];
    public ICollection<CheckRequest> CheckRequests { get; set; } = [];
}
