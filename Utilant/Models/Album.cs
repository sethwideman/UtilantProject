using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilant.Models
{
    public class Album
    {
        public int userId { get; set; }
        public int id { get; set; }
        public String title { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<Photo> Photos { get; set; }

    }
}