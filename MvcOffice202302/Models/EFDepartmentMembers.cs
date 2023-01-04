using Microsoft.EntityFrameworkCore;
using MvcOffice.Data;
namespace MvcOffice.Models
{
    public class EFDepartmentMembers : IDepartmentMembers 
    {
        public MvcOfficeContext context;
        public  EFDepartmentMembers(MvcOfficeContext ctx)
        {
            context= ctx;
        }
        //遍历
        public IQueryable<DepartmentMembers> Departments => context.DepartmentMemberss;
        //增加
        public void  AddDepartments(DepartmentMembers det)
        {
             context.DepartmentMemberss.Add(det);
            context.SaveChanges();
        }
        //删除
        public void DeleteDepartments(DepartmentMembers det)
        {
            context.DepartmentMemberss.Remove(det);
            context.SaveChanges();

        }
      
        //更改 更新
        public void UpdateDepartments(int id,DepartmentMembers det)
        {
            var lokk = from aa in context.DepartmentMemberss
                       where aa.Id == det.Id
                       select aa;
           foreach(var aa in lokk)
            {
                aa.Name= det.Name;
                aa.Name=det.Name;
                aa.EmailAddress= det.EmailAddress;
                aa.DataTime= det.DataTime;
                aa.Password= det.Password;
            }
           context.SaveChanges();
            
        }
        //查询
        public void LlookDepartments(int det)
        {
           // context.DepartmentMemberss.Find(det.Name);
            var lokk = from aa in context.DepartmentMemberss
                       where aa.Id == det
                       select aa;
           
            var cc=lokk.ToListAsync();

        }
        public IQueryable<DepartmentMembers> LookDepartments(int det)
        {
            // context.DepartmentMemberss.Find(det.Name);
            var lokk = from aa in context.DepartmentMemberss
                       where aa.Id == det
                       select aa;
           
            return lokk;

        }

        //public void UpdateDepartments(int id, DepartmentMembers det)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
