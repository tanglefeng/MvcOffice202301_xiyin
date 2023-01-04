using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOffice.Data;
using MvcOffice.Models;

namespace MvcOffice.Controllers
{
    public class PictureSumsController : Controller
    {
        private readonly MvcOfficeContext _context;

        public PictureSumsController(MvcOfficeContext context)
        {
            _context = context;
        }

        // GET: PictureSums
        public async Task<IActionResult> Index()
        {
              return View(await _context.PictureSum.ToListAsync());
        }

        // GET: PictureSums/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PictureSum == null)
            {
                return NotFound();
            }

            var pictureSum = await _context.PictureSum
                .FirstOrDefaultAsync(m => m.PictureSumId == id);
            if (pictureSum == null)
            {
                return NotFound();
            }

            return View(pictureSum);
        }

        // GET: PictureSums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PictureSums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PictureSumId,Name,srcaddress,description,detail,detail2")] PictureSum pictureSum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pictureSum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pictureSum);
        }

        // GET: PictureSums/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PictureSum == null)
            {
                return NotFound();
            }

            var pictureSum = await _context.PictureSum.FindAsync(id);
            if (pictureSum == null)
            {
                return NotFound();
            }
            return View(pictureSum);
        }

        // POST: PictureSums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PictureSumId,Name,srcaddress,description,detail,detail2")] PictureSum pictureSum)
        {
            if (id != pictureSum.PictureSumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pictureSum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureSumExists(pictureSum.PictureSumId))
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
            return View(pictureSum);
        }

        // GET: PictureSums/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PictureSum == null)
            {
                return NotFound();
            }

            var pictureSum = await _context.PictureSum
                .FirstOrDefaultAsync(m => m.PictureSumId == id);
            if (pictureSum == null)
            {
                return NotFound();
            }

            return View(pictureSum);
        }

        // POST: PictureSums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PictureSum == null)
            {
                return Problem("Entity set 'MvcOfficeContext.PictureSum'  is null.");
            }
            var pictureSum = await _context.PictureSum.FindAsync(id);
            if (pictureSum != null)
            {
                _context.PictureSum.Remove(pictureSum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PictureSumExists(string id)
        {
          return _context.PictureSum.Any(e => e.PictureSumId == id);
        }
        public string bb;
        // public List<string> picturebb;
        public  IActionResult PictureDisplay(string SearchString)
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
        //public async Task<IActionResult> PictureDisplay22(string SearchString)
        //{
        //    return View(bb);
        //}
    }
}
