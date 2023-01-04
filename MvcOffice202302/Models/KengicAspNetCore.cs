using System.ComponentModel.DataAnnotations;

namespace MvcOffice.Models
{
    public class KengicAspNetCore
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public string detail { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
