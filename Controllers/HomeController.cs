using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MvcApplication14.Controllers
{
    enum FileSize
    {
        SMALL,
        MEDIUM,
        LARGE,
        LARGEST
    }
    public class HomeController : Controller
    {
        public ActionResult Index()

        
        {
            DirectoryInfo directorys = new DirectoryInfo(HttpContext.Server.MapPath("/"));
            var files = directorys.GetFiles();

            var counts = files.GroupBy(f =>
            {
                return f.Length < 10485760 ? FileSize.SMALL :
                    f.Length < 52428800 ? FileSize.MEDIUM :
                    f.Length < 104857600 ? FileSize.LARGE :
                    FileSize.LARGEST;
            })
                  .ToDictionary(
                      group => group.Key,
                      group => group.Count()
                  );
              var directory = new Models.Directory();

            
            if (counts.ContainsKey(FileSize.SMALL))
                directory.SmallFilesCount = counts[FileSize.SMALL];
            if (counts.ContainsKey(FileSize.MEDIUM))
                directory.MediumFilesCount = counts[FileSize.MEDIUM];
            if (counts.ContainsKey(FileSize.LARGEST))
                directory.LargeFilesCount = counts[FileSize.LARGEST];

            

            return View(directory);

                    
        }
    }
}
