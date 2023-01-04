namespace MvcOffice.Models
{
    public interface IDepartmentMembers
    {
        //封装数据库 
        IQueryable<DepartmentMembers> Departments { get; }
        //增
        void AddDepartments(DepartmentMembers det) { }
        //删
        void DeleteDepartments(DepartmentMembers det) { }
        //改
        void UpdateDepartments(int id, DepartmentMembers det);
        //查询
   IQueryable<DepartmentMembers> LookDepartments(int det);
       // DepartmentMembers DeleteDepartmentsId(int det);
    }
}
