using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcOffice.Models
{
    public class baokao
    {
        public  string timeset { get; set; }
        public List<SelectListItem> timesetss { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="signupTime",Text="报名时间"},
              new SelectListItem{Value="writtenExaminationTime",Text="笔试时间"},
                new SelectListItem{Value="InterviewTime",Text="面试时间"},
                  new SelectListItem{Value="hysicalExaminationTime",Text="体检时间"},
                    new SelectListItem{Value="ProposedAdmissionTime",Text="拟录取时间"},
                      new SelectListItem{Value="ReportingTime",Text="报到时间"},
        };
    }
}
