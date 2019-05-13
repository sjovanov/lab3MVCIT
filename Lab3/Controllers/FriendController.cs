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
        static List<FriendModel> lista = new List<FriendModel>();
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

        public ActionResult EditFriend(FriendModel prijatel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", prijatel.id);
            }
            FriendModel pomoshen = lista.Single(m => m.id == prijatel.id);
            pomoshen.id = prijatel.id;
            pomoshen.ime = prijatel.ime;
            pomoshen.mestoNaZiveenje = prijatel.mestoNaZiveenje;
            return View("All", lista);
        }

        public ActionResult DeleteFriend(int id)
        {
            lista.RemoveAt(id);
            return View("All", lista);
        }
    }
}