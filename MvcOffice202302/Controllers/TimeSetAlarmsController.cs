using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOffice.Data;
using MvcOffice.Models;
using NuGet.Protocol.Core.Types;
using static MvcOffice.Models.baokao
    ;
namespace MvcOffice.Controllers
{
    public class TimeSetAlarmsController : Controller
    {
        private readonly MvcOfficeContext _context;
        public baokao baokao = new baokao();
        public TimeSetAlarmsController(MvcOfficeContext context)
        {
            _context = context;
        }

        // GET: TimeSetAlarms
        public async Task<IActionResult> Index()
        {
            ViewBag.aokao = new SelectList(items: baokao.timesetss
               .Select(c => c.Text).Distinct());
            return View(await _context.TimeSetAlarm.ToListAsync());
        }

        // GET: TimeSetAlarms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeSetAlarm == null)
            {
                return NotFound();
            }

            var timeSetAlarm = await _context.TimeSetAlarm
                .FirstOrDefaultAsync(m => m.AlarmId == id);
            if (timeSetAlarm == null)
            {
                return NotFound();
            }

            return View(timeSetAlarm);
        }

        // GET: TimeSetAlarms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeSetAlarms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeSetAlarm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeSetAlarm);
        }
        //http://t.zoukankan.com/qingheshiguang-p-15801021.html
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NearWiteDay([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {
           
          
            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now, t.writtenExaminationTime) <= 3 && EF.Functions.DateDiffDay(DateTime.Now, t.writtenExaminationTime) >= 0));
            if (query6.Count() > 0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    //projectname += "名称:" + aab.AlarmName + "  ";
                    projectname += "名称:" + aab.AlarmName + "  " + "笔试时间截至为:" + aab.writtenExaminationTime + "," + "笔试时间开始为" + aab.writtenExaminationTime.AddDays(-3) + "\r\n"; ;
                }
               // return Content("长点心  " + projectname + "这块笔试到时间了");
                return Content("以下几个项目笔试时间到了" + "\r\n" + projectname);
            }
           
           // return View(timeSetAlarm);
            return Content("一切皆在计划中");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NearInterviewDay([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {


            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now, t.InterviewTime) <= 3 && EF.Functions.DateDiffDay(DateTime.Now, t.InterviewTime) >= 0));
            if (query6.Count() > 0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    projectname += "名称:" + aab.AlarmName + "  " + "面试时间截至为:" + aab.InterviewTime + "," + "面试时间开始为" + aab.InterviewTime.AddDays(-3) + "\r\n"; ;
                }
                //return Content("长点心  " + projectname + "这块面试到时间了");
                return Content("以下几个项目体检时间到了" + "\r\n" + projectname);
            }

            //return View(timeSetAlarm);
            return Content("一切皆在计划中");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NearhysicalExaminationDay([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {


            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now, t.hysicalExaminationTime) <= 3 && EF.Functions.DateDiffDay(DateTime.Now, t.hysicalExaminationTime) >= 0));
            if (query6.Count() > 0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    projectname += "名称:" + aab.AlarmName + "  " + "体检时间截至为:" + aab.hysicalExaminationTime + "," + "体检时间开始为" + aab.hysicalExaminationTime.AddDays(-3) + "\r\n";
                }
                  //  return Content("名称  " + projectname + "这块体检到时间了");
                return Content("以下几个项目体检时间到了" + "\r\n" + projectname);
            }

            //return View(timeSetAlarm);
            return Content("一切皆在计划中");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NearProposedAdmissionDay([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {


            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now, t.ProposedAdmissionTime) <= 3 && EF.Functions.DateDiffDay(DateTime.Now, t.ProposedAdmissionTime) >= 0));
            if (query6.Count() > 0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    projectname += "名称:" + aab.AlarmName + "  " + "拟录取时间截至为:" + aab.ProposedAdmissionTime + "," + "拟录取时间开始为" + aab.ProposedAdmissionTime.AddDays(-3) + "\r\n";
                }
               // return Content("名称  " + projectname + "这块拟录取到时间了");
                return Content("以下几个项目拟录取时间到了" + "\r\n" + projectname);
            }

           // return View(timeSetAlarm);
            return Content("一切皆在计划中");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NearReportingDay([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {


            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now, t.ReportingTime) <= 3 && EF.Functions.DateDiffDay(DateTime.Now, t.ReportingTime) > 0));
            if (query6.Count() > 0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    projectname += "名称:" + aab.AlarmName + "  " + "报道时间截至为:" + aab.ReportingTime + "," + "报道开始为" + aab.ReportingTime.AddDays(-3) + "\r\n";
                }
                //return Content("长点心  " + projectname + "这块报道到时间了");
                return Content("以下几个项目报道时间到了" + "\r\n" + projectname);
            }

            //return View(timeSetAlarm);
            return Content("一切皆在计划中");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NearDate([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {
         
            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now,t.baoming) <=4  && EF.Functions.DateDiffDay(DateTime.Now, t.baoming)>=0));
            if (query6.Count()>0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    projectname +="名称:" + aab.AlarmName+"  "+"报名时间截至为:"+aab.baoming+","+"报名时间开始为"+aab.baoming.AddDays(-3)+"\r\n";
                }
                return Content("以下几个项目报名时间到了"+"\r\n" + projectname );
            }        
            return Content("一切皆在计划中");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NearConfirmDay([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {
            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now, t.signupTime) <= 3 && EF.Functions.DateDiffDay(DateTime.Now, t.signupTime) >= 0));
            if (query6.Count() > 0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    projectname += "名称:" + aab.AlarmName + "  " + "确认时间截至为:" + aab.signupTime + "," + "确认时间开始为" + aab.signupTime.AddDays(-3) + "\r\n";
                }
                return Content("以下几个项目确认时间到了" + "\r\n" + projectname);
            }
            return Content("一切皆在计划中");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NearPayDay([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {
            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now, t.payTime) <= 3 && EF.Functions.DateDiffDay(DateTime.Now, t.payTime) >= 0));
            if (query6.Count() > 0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    projectname += "名称:" + aab.AlarmName + "  " + "缴费时间截至为:" + aab.payTime + "," + "缴费时间开始为" + aab.payTime.AddDays(-3) + "\r\n";
                }
                return Content("以下几个项目缴费时间到了" + "\r\n" + projectname);
            }
            return Content("一切皆在计划中");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NearPrintDay([Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {
            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now, t.printTime) <= 4 && EF.Functions.DateDiffDay(DateTime.Now, t.printTime) >= 0));
            if (query6.Count() > 0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    projectname += "名称:" + aab.AlarmName + "  " + "准考证打印时间截至为:" + aab.printTime + "," + "准考证打印时间时间开始为" + aab.printTime.AddDays(-4) + "\r\n";
                }
               // return Content(  projectname + "这块打印准考证到时间了");
                return Content("以下几个项目打印准考证时间到了" + "\r\n" + projectname);
            }
            return Content("一切皆在计划中");
        }
        // GET: TimeSetAlarms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TimeSetAlarm == null)
            {
                return NotFound();
            }

            var timeSetAlarm = await _context.TimeSetAlarm.FindAsync(id);
            if (timeSetAlarm == null)
            {
                return NotFound();
            }
            return View(timeSetAlarm);
        }

        // POST: TimeSetAlarms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlarmId,AlarmName,baoming,signupTime,payTime,printTime,writtenExaminationTime,InterviewTime,hysicalExaminationTime,ProposedAdmissionTime,ReportingTime")] TimeSetAlarm timeSetAlarm)
        {
            if (id != timeSetAlarm.AlarmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSetAlarm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSetAlarmExists(timeSetAlarm.AlarmId))
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
            return View(timeSetAlarm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Chooseselct(string aa)
        {


            var query5 = _context.TimeSetAlarm.Where(t => EF.Functions.DateDiffDay(t.signupTime, DateTime.Now) >= 3);
            var query6 = _context.TimeSetAlarm.Where(t => (EF.Functions.DateDiffDay(DateTime.Now, t.signupTime) <= 3 && EF.Functions.DateDiffDay(DateTime.Now, t.signupTime) > 0));
            if (query6.Count() > 0)
            {
                string projectname = "";
                foreach (var aab in query6)
                {
                    projectname += "名称:" + aab.AlarmName + "  ";
                }
                return Content("长点心  " + projectname + "这块报名到时间了");
            }
            //foreach (var aab in query6)
            //{
            //    return Content("长点心  "+aab.AlarmName+ "这块到时间了");
            //}
            // TimeSpan xx = timeSetAlarm.signupTime- DateTime.Now;
            //var aa = xx.TotalDays;
            //if(aa<3)
            //     {
            //     return Content("长点心  这块到时间了");
            // }
            //return View(timeSetAlarm);
            return Content("一切皆在计划中");
        }
        
        // GET: TimeSetAlarms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeSetAlarm == null)
            {
                return NotFound();
            }

            var timeSetAlarm = await _context.TimeSetAlarm
                .FirstOrDefaultAsync(m => m.AlarmId == id);
            if (timeSetAlarm == null)
            {
                return NotFound();
            }

            return View(timeSetAlarm);
        }

        // POST: TimeSetAlarms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TimeSetAlarm == null)
            {
                return Problem("Entity set 'MvcOfficeContext.TimeSetAlarm'  is null.");
            }
            var timeSetAlarm = await _context.TimeSetAlarm.FindAsync(id);
            if (timeSetAlarm != null)
            {
                _context.TimeSetAlarm.Remove(timeSetAlarm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSetAlarmExists(int id)
        {
          return _context.TimeSetAlarm.Any(e => e.AlarmId == id);
        }
    }
}
