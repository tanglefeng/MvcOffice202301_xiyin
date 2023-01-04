using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOffice.Data;
using MvcOffice.Models;

namespace MvcOffice.Controllers
{
    public class KengicAspnetcorePictureSumsController : Controller
    {
        private readonly MvcOfficeContext _context;

        public KengicAspnetcorePictureSumsController(MvcOfficeContext context)
        {
            _context = context;
        }

        // GET: KengicAspnetcorePictureSums
        //public async Task<IActionResult> Index()
        //{
        //      return View(await _context.KengicAspnetcorePictureSum.ToListAsync());

        //}
        public int? PageTotal { get; set; }
        [BindProperty]
        public KengicAspnetcorePictureSum KengicAspNetCorePicturePage { get; set; } = default!;
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

            var KengicAspNetCoress = from s in _context.KengicAspnetcorePictureSum
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
            return View(await PaginatedList<KengicAspnetcorePictureSum>.CreateAsync(KengicAspNetCoress.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: KengicAspnetcorePictureSums/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KengicAspnetcorePictureSum == null)
            {
                return NotFound();
            }

            var kengicAspnetcorePictureSum = await _context.KengicAspnetcorePictureSum
                .FirstOrDefaultAsync(m => m.KengicAspnetcorePictureSumId == id);
            if (kengicAspnetcorePictureSum == null)
            {
                return NotFound();
            }

            return View(kengicAspnetcorePictureSum);
        }

        // GET: KengicAspnetcorePictureSums/Create
        public IActionResult Create()
        {
            return View();
        }
//增加对ModelState的判断以及显示
public void ModelStateJudge(ModelStateDictionary ModelState)
        {
            int bindnumber = 6;
            if(ModelState.Count!=bindnumber)
            {
                ModelState.AddModelError(string.Empty, "数量不对");
            }



        }
        // POST: KengicAspnetcorePictureSums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KengicAspnetcorePictureSumId,Name,srcaddress,description,detail,detail2")] KengicAspnetcorePictureSum kengicAspnetcorePictureSum)
        {
            
            if (ModelState.IsValid)
            {
               
                _context.Add(kengicAspnetcorePictureSum);
                await _context.SaveChangesAsync();
                //增加报错信息
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.Count != 6)
            {
                ModelState.AddModelError(string.Empty, "数量不对,去代码中查询bind绑定的类 确保绑定的均为一类 比如本类的KengicAspnetcorePictureSum");
            }
            //if(ModelState.ErrorCount!=0)
            //{
            //    foreach( var tt in ModelState.Keys)
            //    {
            //       // ModelState.AddModelError(tt.ToString(), "数量不对");
            //        ModelState.AddModelError(tt.ToString(), tt.ToString());
            //    }
            //}
            //ModelState.AddModelError(string.Empty, "数量不对");
            return View(kengicAspnetcorePictureSum);
        }

        // GET: KengicAspnetcorePictureSums/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KengicAspnetcorePictureSum == null)
            {
                return NotFound();
            }

            var kengicAspnetcorePictureSum = await _context.KengicAspnetcorePictureSum.FindAsync(id);
            if (kengicAspnetcorePictureSum == null)
            {
                return NotFound();
            }
            return View(kengicAspnetcorePictureSum);
        }

        // POST: KengicAspnetcorePictureSums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("KengicAspnetcorePictureSumId,Name,srcaddress,description,detail,detail2")] KengicAspnetcorePictureSum kengicAspnetcorePictureSum)
        {
            if (id != kengicAspnetcorePictureSum.KengicAspnetcorePictureSumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kengicAspnetcorePictureSum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KengicAspnetcorePictureSumExists(kengicAspnetcorePictureSum.KengicAspnetcorePictureSumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kengicAspnetcorePictureSum);
        }

        // GET: KengicAspnetcorePictureSums/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KengicAspnetcorePictureSum == null)
            {
                return NotFound();
            }

            var kengicAspnetcorePictureSum = await _context.KengicAspnetcorePictureSum
                .FirstOrDefaultAsync(m => m.KengicAspnetcorePictureSumId == id);
            if (kengicAspnetcorePictureSum == null)
            {
                return NotFound();
            }

            return View(kengicAspnetcorePictureSum);
        }

        // POST: KengicAspnetcorePictureSums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KengicAspnetcorePictureSum == null)
            {
                return Problem("Entity set 'MvcOfficeContext.KengicAspnetcorePictureSum'  is null.");
            }
            var kengicAspnetcorePictureSum = await _context.KengicAspnetcorePictureSum.FindAsync(id);
            if (kengicAspnetcorePictureSum != null)
            {
                _context.KengicAspnetcorePictureSum.Remove(kengicAspnetcorePictureSum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KengicAspnetcorePictureSumExists(string id)
        {
          return _context.KengicAspnetcorePictureSum.Any(e => e.KengicAspnetcorePictureSumId == id);
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
