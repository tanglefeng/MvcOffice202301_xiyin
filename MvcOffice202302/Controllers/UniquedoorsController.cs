using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOffice.Data;
using MvcOffice.Models;

namespace MvcOffice.Controllers
{
    public class UniquedoorsController : Controller
    {
        private readonly MvcOfficeContext _context;

        public UniquedoorsController(MvcOfficeContext context)
        {
            _context = context;
        }
        //增加共有的页数 
        public int? PageTotal { get; set; }
        [BindProperty]
        public  Uniquedoor UniquedoorPage { get; set; } = default!;
        //Bind的意义在于 他是static 是可以存储的 即使在一个方法中改变 他会存储 如果不是 那么就不会存储 只在用的方法中存储 可以理解为形参
        //public static Uniquedoor UniquedoorPage { get; set; } = default!;
        // GET: Uniquedoors
        public async Task<IActionResult> Index(string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DescriptionSortParm"] = sortOrder == "Description" ? "Description_desc" : "Description";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var uniquedoor = from s in _context.Uniquedoor
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                uniquedoor = uniquedoor.Where(s => s.Name.Contains(searchString));

            }
            switch (sortOrder)
            {
                //case "name_desc":
                //    students = students.OrderByDescending(s => s.Name);
                //    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                //default:
                //    students = students.OrderBy(s => s.LastName);
                //    break;
                case "name_desc":
                    uniquedoor = uniquedoor.OrderByDescending(s => s.Name);
                    break;
                case "Description":
                    uniquedoor = uniquedoor.OrderBy(s => s.description);
                    break;
                case "Description_desc":
                    uniquedoor = uniquedoor.OrderBy(s => s.description);
                    break;
                default:
                    uniquedoor= uniquedoor.OrderBy(s => s.Name);
                    break;
            }

            //return View(await _context.Uniquedoor.ToListAsync());
            int pageSize = 10;
            //var pageSize = Configuration.
            PageTotal = uniquedoor.Count()% pageSize;
            
            if (PageTotal == 0) { PageTotal = uniquedoor.Count() / pageSize;
                ViewData["PageTotal"] = uniquedoor.Count() /pageSize;
            }
            else { PageTotal = (uniquedoor.Count() / pageSize) + 1;
                ViewData["PageTotal"] = uniquedoor.Count() / pageSize+1;
            }

            //Uniquedoors = await PaginatedList<uniquedoor>.CreateAsync(
            //    uniquedoorName.AsNoTracking(), pageIndex ?? 1, pageSize);
            return View(await PaginatedList<Uniquedoor>.CreateAsync(uniquedoor.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Uniquedoors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Uniquedoor == null)
            {
                return NotFound();
            }

            var uniquedoor = await _context.Uniquedoor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uniquedoor == null)
            {
                return NotFound();
            }

            return View(uniquedoor);
        }

        // GET: Uniquedoors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uniquedoors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //增加timestap后 别忘了bind一下
        public async Task<IActionResult> Create([Bind("ID,Name,description,detail,RowVersion")] Uniquedoor uniquedoor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uniquedoor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uniquedoor);
        }

        // GET: Uniquedoors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Uniquedoor == null)
            {
                return NotFound();
            }

            var uniquedoor = await _context.Uniquedoor.FindAsync(id);
            if (uniquedoor == null)
            {
                return NotFound();
            }
            UniquedoorPage = uniquedoor;
            return View(uniquedoor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] RowVersion)
            // public async Task<IActionResult> Edit(int? id,string Version)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uniqueToUpdate = await _context.Uniquedoor.FirstOrDefaultAsync(m => m.ID == id);

            if (uniqueToUpdate == null)
            {
                Uniquedoor deletedDepartment = new Uniquedoor();
                await TryUpdateModelAsync(deletedDepartment);
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The department was deleted by another user.");
               // ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", deletedDepartment.InstructorID);
                return View(deletedDepartment);
            }
           _context.Entry(uniqueToUpdate).Property("RowVersion").OriginalValue = RowVersion;
            //_context.Entry(uniqueToUpdate).Property("RowVersion").OriginalValue = UniquedoorPage.RowVersion;

            if (await TryUpdateModelAsync<Uniquedoor>(
                uniqueToUpdate,
                "",
                s => s.Name, s => s.description, s => s.detail))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Uniquedoor)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The department was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Uniquedoor)databaseEntry.ToObject();

                        if (databaseValues.Name != clientValues.Name)
                        {
                            ModelState.AddModelError("Name", $"Current value: {databaseValues.Name}");
                        }
                        if (databaseValues.description != clientValues.description)
                        {
                            ModelState.AddModelError("description", $"Current value: {databaseValues.description}");
                        }
                        if (databaseValues.detail != clientValues.detail)
                        {
                            ModelState.AddModelError("detail", $"Current value: {databaseValues.detail}");
                        }
                        //if (databaseValues.InstructorID != clientValues.InstructorID)
                        //{
                        //    Instructor databaseInstructor = await _context.Instructors.FirstOrDefaultAsync(i => i.ID == databaseValues.InstructorID);
                        //    ModelState.AddModelError("InstructorID", $"Current value: {databaseInstructor?.FullName}");
                        //}

                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you got the original value. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to edit this record, click "
                                + "the Save button again. Otherwise click the Back to List hyperlink.");
                        uniqueToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
          //  ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", departmentToUpdate.InstructorID);
            return View(uniqueToUpdate);
        }

        // POST: Uniquedoors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Name,description,detail")] Uniquedoor uniquedoor)
        //{
        //    if (id != uniquedoor.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(uniquedoor);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UniquedoorExists(uniquedoor.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(uniquedoor);
        //}

        // GET: Uniquedoors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Uniquedoor == null)
            {
                return NotFound();
            }

            var uniquedoor = await _context.Uniquedoor
                .FirstOrDefaultAsync(m => m.ID == id);
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
            if (_context.Uniquedoor == null)
            {
                return Problem("Entity set 'MvcOfficeContext.Uniquedoor'  is null.");
            }
            var uniquedoor = await _context.Uniquedoor.FindAsync(id);
            if (uniquedoor != null)
            {
                _context.Uniquedoor.Remove(uniquedoor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniquedoorExists(int id)
        {
          return _context.Uniquedoor.Any(e => e.ID == id);
        }
    }
}
