//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using MvcOffice.Data;
//using MvcOffice.Models;

//namespace MvcOffice.Controllers
//{
//    public class KengicAspNetCoresController : Controller
//    {
//        private readonly MvcOfficeContext _context;

//        public KengicAspNetCoresController(MvcOfficeContext context)
//        {
//            _context = context;
//        }

//        // GET: KengicAspNetCores
//        public async Task<IActionResult> Index()
//        {
//              return View(await _context.KengicAspNetCore.ToListAsync());
//        }

//        // GET: KengicAspNetCores/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.KengicAspNetCore == null)
//            {
//                return NotFound();
//            }

//            var kengicAspNetCore = await _context.KengicAspNetCore
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (kengicAspNetCore == null)
//            {
//                return NotFound();
//            }

//            return View(kengicAspNetCore);
//        }

//        // GET: KengicAspNetCores/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: KengicAspNetCores/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,Name,description,detail,RowVersion")] KengicAspNetCore kengicAspNetCore)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(kengicAspNetCore);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(kengicAspNetCore);
//        }

//        // GET: KengicAspNetCores/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.KengicAspNetCore == null)
//            {
//                return NotFound();
//            }

//            var kengicAspNetCore = await _context.KengicAspNetCore.FindAsync(id);
//            if (kengicAspNetCore == null)
//            {
//                return NotFound();
//            }
//            return View(kengicAspNetCore);
//        }

//        // POST: KengicAspNetCores/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,description,detail,RowVersion")] KengicAspNetCore kengicAspNetCore)
//        {
//            if (id != kengicAspNetCore.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(kengicAspNetCore);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!KengicAspNetCoreExists(kengicAspNetCore.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(kengicAspNetCore);
//        }

//        // GET: KengicAspNetCores/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.KengicAspNetCore == null)
//            {
//                return NotFound();
//            }

//            var kengicAspNetCore = await _context.KengicAspNetCore
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (kengicAspNetCore == null)
//            {
//                return NotFound();
//            }

//            return View(kengicAspNetCore);
//        }

//        // POST: KengicAspNetCores/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.KengicAspNetCore == null)
//            {
//                return Problem("Entity set 'MvcOfficeContext.KengicAspNetCore'  is null.");
//            }
//            var kengicAspNetCore = await _context.KengicAspNetCore.FindAsync(id);
//            if (kengicAspNetCore != null)
//            {
//                _context.KengicAspNetCore.Remove(kengicAspNetCore);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool KengicAspNetCoreExists(int id)
//        {
//          return _context.KengicAspNetCore.Any(e => e.ID == id);
//        }
//    }
//}
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
    public class KengicAspNetCoresController : Controller
    {
        private readonly MvcOfficeContext _context;

        public KengicAspNetCoresController(MvcOfficeContext context)
        {
            _context = context;
        }
        //增加共有的页数 
        public int? PageTotal { get; set; }
        [BindProperty]
        public KengicAspNetCore KengicAspNetCorePage { get; set; } = default!;
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

            var KengicAspNetCoress = from s in _context.KengicAspNetCore
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                KengicAspNetCoress = KengicAspNetCoress.Where(s => s.Name.Contains(searchString));

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
                    KengicAspNetCoress = KengicAspNetCoress.OrderByDescending(s => s.Name);
                    break;
                case "Description":
                    KengicAspNetCoress = KengicAspNetCoress.OrderBy(s => s.description);
                    break;
                case "Description_desc":
                    KengicAspNetCoress = KengicAspNetCoress.OrderBy(s => s.description);
                    break;
                default:
                    KengicAspNetCoress = KengicAspNetCoress.OrderBy(s => s.Name);
                    break;
            }

            //return View(await _context.Uniquedoor.ToListAsync());
            int pageSize = 10;
            //var pageSize = Configuration.
            PageTotal = KengicAspNetCoress.Count() % pageSize;

            if (PageTotal == 0)
            {
                PageTotal = KengicAspNetCoress.Count() / pageSize;
                ViewData["PageTotal"] = KengicAspNetCoress.Count() / pageSize;
            }
            else
            {
                PageTotal = (KengicAspNetCoress.Count() / pageSize) + 1;
                ViewData["PageTotal"] = KengicAspNetCoress.Count() / pageSize + 1;
            }

            //Uniquedoors = await PaginatedList<uniquedoor>.CreateAsync(
            //    uniquedoorName.AsNoTracking(), pageIndex ?? 1, pageSize);
            return View(await PaginatedList<KengicAspNetCore>.CreateAsync(KengicAspNetCoress.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Uniquedoors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KengicAspNetCore == null)
            {
                return NotFound();
            }

            var KengicAspNetCoress = await _context.KengicAspNetCore
                .FirstOrDefaultAsync(m => m.ID == id);
            if (KengicAspNetCoress == null)
            {
                return NotFound();
            }

            return View(KengicAspNetCoress);
        }

        // GET: Uniquedoors/Create
        public IActionResult Create()
        {
            return View();
        }
        public string KengicAspnetcorePictureSumId { get; set; }
        public string Name { get; set; }
        public string srcaddress { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public string detail2 { get; set; }
        // POST: Uniquedoors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //增加timestap后 别忘了bind一下
        public async Task<IActionResult> Create([Bind("ID,Name,description,detail,RowVersion")] KengicAspNetCore KengicAspNetCoress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(KengicAspNetCoress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(KengicAspNetCoress);
        }

        // GET: Uniquedoors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KengicAspNetCore == null)
            {
                return NotFound();
            }

            var KengicAspNetCoress = await _context.KengicAspNetCore.FindAsync(id);
            if (KengicAspNetCoress == null)
            {
                return NotFound();
            }
            KengicAspNetCorePage = KengicAspNetCoress;
            return View(KengicAspNetCoress);
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

            var KengicAspNetCoreToUpdate = await _context.KengicAspNetCore.FirstOrDefaultAsync(m => m.ID == id);

            if (KengicAspNetCoreToUpdate == null)
            {
                Uniquedoor deletedDepartment = new Uniquedoor();
                await TryUpdateModelAsync(deletedDepartment);
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The department was deleted by another user.");
                // ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", deletedDepartment.InstructorID);
                return View(deletedDepartment);
            }
            _context.Entry(KengicAspNetCoreToUpdate).Property("RowVersion").OriginalValue = RowVersion;
            //_context.Entry(uniqueToUpdate).Property("RowVersion").OriginalValue = UniquedoorPage.RowVersion;

            if (await TryUpdateModelAsync<KengicAspNetCore>(
               KengicAspNetCoreToUpdate,
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
                    var clientValues = (KengicAspNetCore)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The department was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (KengicAspNetCore)databaseEntry.ToObject();

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
                        KengicAspNetCoreToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            //  ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", departmentToUpdate.InstructorID);
            return View(KengicAspNetCoreToUpdate);
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
            if (id == null || _context.KengicAspNetCore == null)
            {
                return NotFound();
            }

            var KengicAspNetCoress = await _context.KengicAspNetCore
                .FirstOrDefaultAsync(m => m.ID == id);
            if (KengicAspNetCoress == null)
            {
                return NotFound();
            }

            return View(KengicAspNetCoress);
        }

        // POST: Uniquedoors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Uniquedoor == null)
            {
                return Problem("Entity set 'MvcOfficeContext.KengicAspNetCore'  is null.");
            }
            var KengicAspNetCoress = await _context.KengicAspNetCore.FindAsync(id);
            if (KengicAspNetCoress != null)
            {
                _context.KengicAspNetCore.Remove(KengicAspNetCoress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KengicAspNetCoressExists(int id)
        {
            return _context.KengicAspNetCore.Any(e => e.ID == id);
        }
        public IActionResult KengicAspNetCorePictureDisplay(string SearchString)
        {
            //bb = SearchString;
            //////增加以；作为分隔符
            ////if (!SearchString.Contains(';'))
            ////{
            ////    picturebb[0] = SearchString;
            //ViewData["qq"] = SearchString;
            ////}
            ////else
            ////{
            //// var aa=SearchString.Split(';');
            ////}
            //return View((object)bb);
            //参见https://www.cnblogs.com/wfy680/p/12324199.html
            ViewBag.SearchString = SearchString;
            return View();
            //return View(ViewData["qq"]);
            //return View(bb);


        }
    }
}
