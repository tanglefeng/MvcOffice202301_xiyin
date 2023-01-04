using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcOffice.Models;

namespace MvcOffice.Data
{
    public class MvcOfficeContext : DbContext
    {
        public MvcOfficeContext (DbContextOptions<MvcOfficeContext> options)
            : base(options)
        {
        }

        public DbSet<MvcOffice.Models.Uniquedoor> Uniquedoor { get; set; } = default!;

        public DbSet<MvcOffice.Models.PictureSum> PictureSum { get; set; } = default!;

        public DbSet<MvcOffice.Models.KengicAspNetCore> KengicAspNetCore { get; set; } = default!;

        public DbSet<MvcOffice.Models.KengicAspnetcorePictureSum> KengicAspnetcorePictureSum { get; set; } = default!;
        public DbSet<MvcOffice.Models.Product> Products { get; set; } = default!;
        public DbSet<MvcOffice.Models.DepartmentMembers> DepartmentMemberss { get; set; } = default!;
        public DbSet<MvcOffice.Models.RolePermission> RolePermissions { get; set; } = default!;
        public DbSet<MvcOffice.Models.TimeSetAlarm> TimeSetAlarm { get; set; }

    }
}
