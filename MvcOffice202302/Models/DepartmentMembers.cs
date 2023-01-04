using Microsoft.AspNetCore.Identity;

namespace MvcOffice.Models
{
    public class DepartmentMembers: IDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Phonrnumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string DataTime { get; set; }
        
    }
}
