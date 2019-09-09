using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT2030DavidSmithLab2.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product/
        public String Index()
        {
            return "Product/Index is displayed";

        }

        // GET: /Product/Browse
        public String Browse()
        {
            return "Browse displayed.";

        }

        // GET: /Product/Details/105

        public String Details()
        {
            return "Details displayed for id=105";
        }

        // GET: /Product/Location?zip=44124

        public String Location()
        {
            return "Details displayed for zip=44124";
        }


    }
}