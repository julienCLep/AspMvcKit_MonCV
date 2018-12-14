using Skillz.Db;
using Skillz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skillz.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult Index()
        {
            List<Formation> maListExp = Dal.forma.FindAll();
            return View(maListExp);
        }
        public ActionResult Details(int id)
        {
            Formation f = Dal.forma.Find(id);
            if (f == null)
            {
                RedirectToAction("Index"); //return index
            }
            return View(f); //affiche dans la vue détail
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Formation format)
        {
            //Vérifie les condition/contraint de validation. EXEMPLE : [required],[stringLength(64)]
            if (TryValidateModel(format) && Dal.forma.Insert(format))
            {
                Dal.Save();
                return RedirectToAction("Index");
            }
            //sinon il reste sur la vue de cretion experience
            return View(format);
        }


        public ActionResult Edit(int id)
        {
            Formation f = Dal.forma.Find(id);
            return View(f);
        }
        [HttpPost]
        public ActionResult Edit(Formation format) //Même proceder que creation sauf qu'il s'agit d'une modification
        {
            if (TryValidateModel(format) && Dal.forma.Update(format))
            {
                Dal.Save();
                return RedirectToAction("Index");
            }
            return View(format);
        }

        public ActionResult Delete(int id)
        {
            if (Dal.forma.Delete(id))
            {
                Dal.Save();
            }
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult confirmDelete(int id)
        {
            if (Dal.forma.Delete(id))
            {
                Dal.Save();
            }
            return RedirectToAction("Index");
        }
    }
}
