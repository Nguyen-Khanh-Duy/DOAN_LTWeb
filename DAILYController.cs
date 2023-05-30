using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANLYNHASACH.Models;
using PagedList;
namespace QUANLYNHASACH.Controllers
{
    public class DAILYController : Controller
    {
        NHASACHEntities2 db = new NHASACHEntities2();
        // GET: DAILY
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds =(from dl in db.tbDAILYs select dl).OrderBy(x => x.MaDaiLy);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tbDAILY daily = db.tbDAILYs.Find(id);
            return View(daily);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("MaDaiLy");
            tbDAILY daily = db.tbDAILYs.Find(id);
            db.tbDAILYs.Remove(daily);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tbDAILY daily= db.tbDAILYs.Find(id);
            return View(daily);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string id =f.Get("MaDaiLy");
            tbDAILY daily = db.tbDAILYs.Find(id);
            daily.TenDaiLy =f.Get("TenDaiLy");
            daily.TenChuDaiLy =f.Get("TenChuDaiLy");
            daily.DiaChi =f.Get("DiaChi");
            daily.SoDienThoai =f.Get("SoDienThoai");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            var checkBox = (from db in db.tbDAILYs select db).ToList();
            ViewBag.CheckBox = checkBox;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            tbDAILY daily = new tbDAILY();
            string mdl = f.Get("MaDaiLy");
            string tdl = f.Get("TenDaiLy");
            string tcdl = f.Get("TenChuDaiLy");
            string sdt = f.Get("SoDienThoai");
            string dc = f.Get("DiaChi");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            var daily = db.tbDAILYs.Find(id);
            return View(daily);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string MaDaiLy = f.Get("MaDaiLy");
            var ms = db.tbDAILYs.Find("MaDaiLy");
            return RedirectToAction("Details/" + MaDaiLy);
        }
    }

}
