using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlickrImagesService
{
    public class ImageDetails
    {
        public string id { get; set; }
        public string ImageName { get; set; }
        public string ImageLocation { get; set; }
        public string ImageData { get; set; }
        public string ImageDescription { get; set; }
        public System.DateTime ImageDate { get; set; }
    }
}