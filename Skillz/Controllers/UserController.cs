using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skillz.Db;
using Skillz.Models;


namespace Skillz.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        //protected static List<Models.User> users = new List<Models.User>();
        //Dal dal = Dal.DatabaseContext;

        public ActionResult Index()
        {
            //Models.User u = new Models.User()
            //{
            //    Id = 1,
            //    Username = "tonton",
            //    Firstname = "Rudy",
            //    Email = "tonton.rudy@gmail.com",
            //    Password = "1234",
            //    Lastname = "theLegendeOfRudy"
            //};
            //users.Add(u);

            // return View(users);

            List<User> maListe = Dal.Users.FindAll();
            return View(maListe);
        }
            public ActionResult Details(int id)
            {
            // Models.User d = users.FirstOrDefault(item => id == item.Id);

            User d = Dal.Users.Find(id);
            if (d == null)
            {
                RedirectToAction("Index"); //return index
            }
                return View(d); //affiche dans la vue détail
            }

        public ActionResult Create()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            //user.Id = users.Count() + 1;
            //users.Add(user);

            //Dal.Users.Insert(user);

            if (TryValidateModel(user) && Dal.Users.Insert(user))
            {
             Dal.Save();
            return  RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            //User u = users.FirstOrDefault(item => id == item.Id);
            //if (u == null)
            //{
            //    RedirectToAction("Index");
            //}

            User u = Dal.Users.Find(id);
            return View(u);
           
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            //User u = users.FirstOrDefault(item => user.Id == item.Id);
            //if (u!=null)
            //{
            //   // u.Copy(user);
            //}
            if (TryValidateModel(user) && Dal.Users.Update(user))
            {
                Dal.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            //User u = Dal.Users.Find(id);
            //if (u==null)
            //{
            //    RedirectToAction("index");
            //}
           if( Dal.Users.Delete(id))
            {
                Dal.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
         public ActionResult confirmDelete(int id)
        {
            if( Dal.Users.Delete(id))
            {
                Dal.Save();
            }

                return RedirectToAction("Index");
        }
    }
}