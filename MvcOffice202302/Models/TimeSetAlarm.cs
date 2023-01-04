//using MessagePack;
using System.ComponentModel.DataAnnotations;
namespace MvcOffice.Models
{
    public class TimeSetAlarm
    {
        [Key]
        public int AlarmId { get; set; }
        public string AlarmName { get; set; }
        //报名时间
     
        public DateTime baoming { get; set; }
        //确认时间
        
        public DateTime signupTime { get; set; }
        //缴费时间
        public DateTime payTime { get; set; }
        //打印时间
        public DateTime printTime { get; set; }
        //笔试时间
        public DateTime writtenExaminationTime { get; set; }

        //面试时间
        public DateTime InterviewTime { get; set; }

        //体检时间
        public DateTime hysicalExaminationTime { get; set; }
        //录取时间
        public DateTime ProposedAdmissionTime { get; set; }
        //报道时间
        public DateTime ReportingTime {get;set ;}


    }
}
