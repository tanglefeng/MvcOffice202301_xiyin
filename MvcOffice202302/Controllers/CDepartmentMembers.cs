using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MvcOffice.Data;
using MvcOffice.Models;
using System.Runtime.Intrinsics.Arm;

namespace MvcOffice.Controllers
{
    public class CDepartmentMembers : Controller
    {
        public MvcOfficeContext ctx;
        private readonly MvcOfficeContext _context;
        private IDepartmentMembers departmentmember;
        public CDepartmentMembers(MvcOfficeContext context, IDepartmentMembers departmentmember)
        {
            ctx = context;
            this.departmentmember = departmentmember;
         
        }
        public async Task<IActionResult> Index()
        {               
            return View(await departmentmember.Departments.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( DepartmentMembers departmentMembers)
        {
            departmentmember.AddDepartments(departmentMembers);            
            //await departmentmember.sav();
           
            return RedirectToAction(nameof(Index));
           
        }
        
        //删除操作
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || departmentmember == null)
            {
                return NotFound();
            }

            var uniquedoor = departmentmember.LookDepartments(id).FirstOrDefault();
              
            if (uniquedoor == null)
            {
                return NotFound();
            }

            return View(uniquedoor);
        }

        // POST: Uniquedoors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (departmentmember == null)
            {
                return Problem("Entity set 'MvcOfficeContext.Uniquedoor'  is null.");
            }
            //var uniquedoor = await _context.Uniquedoor.FindAsync(id);
            var uniquedoor =  departmentmember.LookDepartments(id).FirstOrDefault();
            if (uniquedoor != null)
            {
                //foreach (var aa in uniquedoor)
                //{ departmentmember.DeleteDepartments(aa); }
                departmentmember.DeleteDepartments(uniquedoor);
            }

           // await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniquedoorExists(int id)
        {
            return _context.Uniquedoor.Any(e => e.ID == id);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || departmentmember == null)
            {
                return NotFound();
            }

            var departmentmemberid =  departmentmember.LookDepartments(id).FirstOrDefault();
            if (departmentmemberid == null)
            {
                return NotFound();
            }
            return View(departmentmemberid);
        }

        // POST: KengicAspnetcorePictureSums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,DepartmentMembers kengicAspnetcorePictureSum)
        {
            if (id != kengicAspnetcorePictureSum.Id)
            {
                return NotFound();
            }
            departmentmember.UpdateDepartments(id,kengicAspnetcorePictureSum);

                    //_context.Update(kengicAspnetcorePictureSum);
                    //await _context.SaveChangesAsync();
            
               
                return RedirectToAction(nameof(Index));
          
            //return View(kengicAspnetcorePictureSum);
        }
    }
}
