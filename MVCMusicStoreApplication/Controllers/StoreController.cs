using MVCMusicStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        MVCMusicStoreApplicationDB db = new MVCMusicStoreApplicationDB();

        // GET: Store
        public ActionResult Index(int id)
        {
            

            return View(GetAlbums(id));
        }

        private List<Album> GetAlbums(int id)
        {
            return db.Albums
                .Where(a => a.GenreId == (id))
                .ToList();
        }

        // GET: Browse
        public ActionResult Browse()
        {
            
            return View(db.Genres.ToList());
        }

        // GET: Store
        public ActionResult Details(int id)
        {
            return View(GetDetails(id));
        }

        private List<Album> GetDetails(int id)
        {
            return db.Albums
                .Where(a => a.AlbumId == (id))
                .ToList();
        }

        // GET: ShoppingCart
        public ActionResult ShoppingCart()
        {
            return View();
        }

        // GET: ShoppingCart/AddToCart
        //public ActionResult AddToCart(int id)
        //{
           // return null;
        //}
    }
}