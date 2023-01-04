using System.ComponentModel.DataAnnotations;

namespace MvcOffice.Models
{
    public class RolePermission
    {
        [Key]
        public int RoleId { get; set; } 
        public string? RoleName { get; set; }
        public string? RolePassword { get; set; }
        public string? Rolesubordinate { get; set; }
    }
}
