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
    public class RolePermissionsController : Controller
    {
        private readonly MvcOfficeContext _context;

        public RolePermissionsController(MvcOfficeContext context)
        {
            _context = context;
        }

        // GET: RolePermissions
        public async Task<IActionResult> Index()
        {
            //return View(await _context.RolePermissions.ToListAsync());
            return View();
        }

        // GET: RolePermissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RolePermissions == null)
            {
                return NotFound();
            }

            var rolePermission = await _context.RolePermissions
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (rolePermission == null)
            {
                return NotFound();
            }

            return View(rolePermission);
        }

        // GET: RolePermissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolePermissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,RolePassword,Rolesubordinate")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolePermission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolePermission);
        }

        // GET: RolePermissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RolePermissions == null)
            {
                return NotFound();
            }

            var rolePermission = await _context.RolePermissions.FindAsync(id);
            if (rolePermission == null)
            {
                return NotFound();
            }
            return View(rolePermission);
        }

        // POST: RolePermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName,RolePassword,Rolesubordinate")] RolePermission rolePermission)
        {
            if (id != rolePermission.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolePermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolePermissionExists(rolePermission.RoleId))
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
            return View(rolePermission);
        }

        // GET: RolePermissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RolePermissions == null)
            {
                return NotFound();
            }

            var rolePermission = await _context.RolePermissions
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (rolePermission == null)
            {
                return NotFound();
            }

            return View(rolePermission);
        }

        // POST: RolePermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RolePermissions == null)
            {
                return Problem("Entity set 'MvcOfficeContext.RolePermissions'  is null.");
            }
            var rolePermission = await _context.RolePermissions.FindAsync(id);
            if (rolePermission != null)
            {
                _context.RolePermissions.Remove(rolePermission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolePermissionExists(int id)
        {
          return _context.RolePermissions.Any(e => e.RoleId == id);
        }
       
        
        //多个参数时  采用的为model binding  实例化此类 然后参数对应 对应知识点为view 向controller传参
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Loginvalidate([Bind("RoleName,RolePassword")] RolePermission rolePermission)
        {
    
            if (rolePermission.RoleName == "tanglefeng" && rolePermission.RolePassword =="kejie1234")
            {
                // return RedirectToAction(nameof(Index));
                return RedirectToRoute(new { Controller = "Home", Action = "Privacy" });
            }
            if (rolePermission.RoleName == "suiyanan" && rolePermission.RolePassword == "suiyanan")
            {
                // return RedirectToAction(nameof(Index));
                return RedirectToRoute(new { Controller = "TimeSetAlarms", Action = "Index" });
            }
            
            //如果是管理员权限 则进入Home的Index
            //如果不是管理员 则进入对应的controller与 actionname  字段根据Rolesubordinate
            var username1 = from aa in _context.RolePermissions where aa.RoleName==rolePermission.RoleName  select aa;
            var username = username1.FirstOrDefault();
            //var username1 = _context.RolePermissions.Find(rolePermission.RoleName);
            if (username == null) { ModelState.AddModelError(string.Empty, "此用户不存在 请联系管理员"); return Content("此用户不存在 请联系管理员"); }
            if (username.RolePassword != rolePermission.RolePassword) { ModelState.AddModelError(string.Empty,"密码错误 请重新输入密码"); return Content("密码错误 请重新输入密码"); }
            if(username.Rolesubordinate== "Uniquedoors"){ return RedirectToRoute(new { Controller = "Uniquedoors", Action = "Index" }); }
           
            return RedirectToRoute(new { Controller = "PictureSum",Action = "Index" });

        }
    }
}
