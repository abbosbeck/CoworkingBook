using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookedTable
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime FromTime { get; set; }
        public int Period { get; set; }

        public virtual Table Table { get; set; }

    }
}
