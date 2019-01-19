using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilant.DAL;
using Utilant.Models;
using PagedList;

namespace Utilant.Controllers
{
    public class HomeController : Controller
    {
        // GET: Album
        public ActionResult Index(String titleSearch, String nameSearch, int? page)
        {
            Repository repository = new Repository();
            List<AlbumViewModel> tmp = repository.getAlbumsVM();

            ViewBag.TitleFilter = titleSearch;
            ViewBag.NameFilter = nameSearch;

            var albums = from s in tmp
                         select s;

            if (!String.IsNullOrEmpty(titleSearch) && !String.IsNullOrEmpty(nameSearch))
            {
                albums = albums.Where(s => s.Title.ToLower().Contains(titleSearch.ToLower()) && s.UsersName.ToLower().Contains(nameSearch.ToLower()));
            }
            else if (!String.IsNullOrEmpty(titleSearch))
            {
                albums = albums.Where(s => s.Title.ToLower().Contains(titleSearch.ToLower()));
            }
            else if (!String.IsNullOrEmpty(nameSearch))
            {
                albums = albums.Where(s => s.UsersName.ToLower().Contains(nameSearch.ToLower()));
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(albums.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Photos(int id)
        {
            Repository repo = new Repository();
            PhotosViewModel photos = repo.getPhotosVM(id);
            return View(photos);
        }

        public ActionResult Users(int id)
        {
            Repository repo = new Repository();
            User user = repo.getUser(id);
            return View(user);
        }

        public ActionResult Posts(int id)
        {
            Repository repo = new Repository();
            List<Post> posts = repo.getPosts(id);
            ViewBag.Name = repo.getUser(id).name;
            return View(posts);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}