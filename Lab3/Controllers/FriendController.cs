using Lab3.Models;
using System;
using System.Collections.Generic;
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
        // GET: Friend
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All()
        {
            return View(lista);
        }

        public ActionResult Add()
        {
            FriendModel prijatel = new FriendModel();
            return View(prijatel);
        }

        public ActionResult AddNewFriend(FriendModel prijatel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", prijatel);
            }
            lista.Add(prijatel);
            return View("All", lista);
        }

        public ActionResult Edit(int id)
        {
            var prijatel = lista.Single(m => m.id == id);
            return View(prijatel);
        }

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

        public ActionResult DeleteFriend(int id)
        {
            FriendModel pomoshen = lista.Single(m => m.id == id);
            lista.Remove(pomoshen);
            return View("All", lista);
        }
    }
}