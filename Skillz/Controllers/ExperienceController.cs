using Skillz.Db;
using Skillz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skillz.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
            public ActionResult Index()
            {
                List<Experience> maListExp = Dal.Experiences.FindAll();
                return View(maListExp);
            }
            public ActionResult Details(int id)
            {
                Experience e = Dal.Experiences.Find(id);
                if (e == null)
                {
                    RedirectToAction("Index"); //return index
                }
                return View(e); //affiche dans la vue détail
            }


            public ActionResult Create()
            {
                return View();
            }
        [HttpPost]
        public ActionResult Create(Experience exp)
        {
            //Vérifie les condition/contraint de validation. EXEMPLE : [required],[stringLength(64)]
            if (TryValidateModel(exp) && Dal.Experiences.Insert(exp)) 
            {
                Dal.Save();
                return RedirectToAction("Index");
            }
            //sinon il reste sur la vue de cretion experience
            return View(exp);
        }


        public ActionResult Edit(int id)
        {
            Experience e = Dal.Experiences.Find(id);
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Experience exp) //Même proceder que creation sauf qu'il s'agit d'une modification
        {
            if (TryValidateModel(exp) && Dal.Experiences.Update(exp))
            {
                Dal.Save();
                return RedirectToAction("Index");
            }
            return View(exp);
        }

        public ActionResult Delete(int id)
        {
            if (Dal.Experiences.Delete(id))
            {
                Dal.Save();
            }
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult confirmDelete(int id)
        {
            if (Dal.Experiences.Delete(id))
            {
                Dal.Save();
            }
            return RedirectToAction("Index");
        }
    }
}

