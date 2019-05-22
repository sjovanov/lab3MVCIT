using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class FriendController : Controller
    {
        private static int starId;
        private static bool flag = true;
        private static List<FriendModel> lista = new List<FriendModel>();
        private FriendModelDbContext db = new FriendModelDbContext();
        // GET: Friend
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All()
        {
            return View(db.Prijateli.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FriendModel fr)
        {
            if (ModelState.IsValid)
            {
                db.Prijateli.Add(fr);
                db.SaveChanges();
                return RedirectToAction("All");
            }
            return View(fr);
        }

    /*    public ActionResult AddNewFriend(FriendModel prijatel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", prijatel);
            }
            lista.Add(prijatel);
            return View("All", lista);
        }*/

        public ActionResult Edit(int? id)
        {
            var prijatel = db.Prijateli.Find(id);
            return View(prijatel);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,ime,mestoNaZiveenje")] FriendModel friendModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friendModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("All");
            }
            return View(friendModel);
        }
        /*
        public ActionResult EditFriend(FriendModel prijatel, FormCollection fc)
        {
            if (!ModelState.IsValid && flag)// Ova e za da mozhe da se izmeni i pokraj toa shto bi se napravilo greshka da ne se vnese id ime ili mesto nekolku pati
            {
                flag = false;
                starId = Convert.ToInt32(fc["StarID"]);
            }
            else if(flag)
            {
                flag = false;
                starId = Convert.ToInt32(fc["StarID"]);
            }
            if (!ModelState.IsValid)
            {
                return View("Edit", prijatel);
            }
            FriendModel pomoshen = lista.Single(m => m.id == starId);
            pomoshen.id = prijatel.id;
            pomoshen.ime = prijatel.ime;
            pomoshen.mestoNaZiveenje = prijatel.mestoNaZiveenje;
            flag = true;
            return View("All", lista);
        }
        */
        public ActionResult DeleteFriend(int? id)
        {
            var prijatel = db.Prijateli.Find(id);
            db.Prijateli.Remove(prijatel);
            db.SaveChanges();
            return RedirectToAction("All");
        }
    }
}