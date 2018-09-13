using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ImageDataAccess;


namespace FlickrImagesService.Controllers
{
    public class LocationController : ApiController
    {

        public IEnumerable<tblImageDetail> Get()
        {
            // ingerit from the ImageModel created 
            using (APIImagesEntities entities = new APIImagesEntities())
            {
                return entities.tblImageDetails.ToList();
            }
        }


        public tblImageDetail Get(string imageLocation)
        {
            // inherit from the ImageModel created 
            using (APIImagesEntities entities = new APIImagesEntities())
            {
                return entities.tblImageDetails.FirstOrDefault(imgLoc => imgLoc.ImageLocation == imageLocation);
            }
        }

    }
}
