namespace MvcOffice.Models
{
    public class timeRepository : ItimeRepository
    {
        public DateTime Now { get { return DateTime.Now; } }
    }
}
