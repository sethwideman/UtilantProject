using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilant.Models
{
    public class PhotosViewModel
    {
        public List<Photo> Photos { get; set; }
        public String UsersName { get; set; }
        public String Title { get; set; }
    }
}