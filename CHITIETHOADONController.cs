using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANLYNHASACH.Models;
using PagedList;

namespace QUANLYNHASACH.Controllers
{
    public class CHITIETHOADONController : Controller
    {
        NHASACHEntities2 db = new NHASACHEntities2();
        // GET: CHITIETHOADON
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from ct in db.tbCHITIETHOADON select ct).OrderBy(x => x.SoHoaDon);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tbCHITIETHOADON ct = db.tbCHITIETHOADON.Find(id);
            return View(ct);
         
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("SoHoaDon");
           
            tbCHITIETHOADON ct = db.tbCHITIETHOADON.Find(id);
            db.tbCHITIETHOADON.Remove(ct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tbCHITIETHOADON ct = db.tbCHITIETHOADON.Find(id);
            return View(ct);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string id =f.Get("SoHoaDon");
            tbCHITIETHOADON ct =db.tbCHITIETHOADON.Find(id);
            ct.MaSach =f.Get("MaSach");
            ct.SoLuong =int.Parse(f.Get("SoLuong"));
            ct.GhiChu =f.Get("GhiChu");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            var checkBox = (from db in db.tbCHITIETHOADON select db).ToList();
            ViewBag.CheckBox = checkBox;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            tbCHITIETHOADON ct = new tbCHITIETHOADON();
            string shd =f.Get("SoHoaDon");
            string ms =f.Get("MaSach");
            int sl =int.Parse(f.Get("SoLuong"));
            string gc =f.Get("GhiChu");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            var ct =db.tbCHITIETHOADON.Find(id);
            return View(ct);
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
            var ms = db.tbCHITIETHOADON.Find("SoHoaDon");
            return RedirectToAction("Details/" + SoHoaDon);
        }
    }
}
