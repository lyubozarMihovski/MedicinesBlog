using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DemoBlog.Controllers
{
    [ValidateInput(false)]
    public class LogoController : ApiController
    {
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
               // string path = Path.Combine(
                                      // System.Web.HttpContext.Current.Server.MapPath("~/DemoBlog/Content"), pic);
                // file is uploaded
                file.SaveAs(pic);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return null;
        }
    }
}
