﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilant.Models
{
    public class Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public String title { get; set; }
        public String url { get; set; }
        public String thumbnailUrl { get; set; }
    }
}