using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilant.Models
{
    public class AlbumViewModel
    {
        public int albumId { get; set; }
        public int UsersId { get; set; }
        public String thumbnail { get; set; }
        public String Title { get; set; }
        public String UsersName { get; set; }
        public String UsersEmail { get; set; }
        public String UsersPhone { get; set; }
        public String UsersAddress { get; set; }
    }
}