using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANLYNHASACH.Models;
using PagedList;
namespace QUANLYNHASACH.Controllers
{
    public class HOADONController : Controller
    {
        NHASACHEntities2 db = new NHASACHEntities2();
        // GET: HOADON
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds =(from hoadon in db.tbHOADON select hoadon).OrderBy(x => x.SoHoaDon);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tbHOADON hoadon = db.tbHOADON.Find(id);
            return View(hoadon);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("SoHoaDon");
            tbHOADON hoadon = db.tbHOADON.Find(id);
            db.tbHOADON.Remove(hoadon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tbHOADON hoadon = db.tbHOADON.Find(id);
            return View(hoadon);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string id = f.Get("SoHoaDon");
            tbHOADON hoadon = db.tbHOADON.Find(id);
            hoadon.NgayLapHoaDon =DateTime.Parse(f.Get("NgayLapHoaDon"));
            hoadon.MaDaiLy =f.Get("MaDaiLy");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            var checkBox = (from db in db.tbHOADON select db).ToList();
            ViewBag.CheckBox = checkBox;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            tbHOADON hoadon  = new tbHOADON();
            string shd = f.Get("SoHoaDon");
            DateTime day = DateTime.Parse(f.Get("NgayLapHoaDon"));
            string mdl = f.Get("MaDaiLy");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            var hoadon= db.tbHOADON.Find(id);
            return View(hoadon);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string SoHoaDon = f.Get("SoHoaDon");
            var ms = db.tbHOADON.Find("SoHoaDon");
            return RedirectToAction("Details/" + SoHoaDon);
        }
    }
}

