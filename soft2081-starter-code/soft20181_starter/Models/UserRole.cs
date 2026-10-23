using soft20181_starter.Models;

public class UserRole
{
    public int UserId { get; set; }
    public SignUpDetails User { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}
