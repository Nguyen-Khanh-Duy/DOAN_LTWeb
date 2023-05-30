using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANLYNHASACH.Models;
using PagedList;
namespace QUANLYNHASACH.Controllers
{
    public class NHAXUATBANController : Controller
    {
        NHASACHEntities2 db = new NHASACHEntities2();
        // GET: NHAXUATBAN
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from nxb in db.tbNHAXUATBAN select nxb).OrderBy(x => x.MaNhaXuatBan);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tbNHAXUATBAN nxb = db.tbNHAXUATBAN.Find(id);
            return View(nxb);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("MaNhaXuatBan");
            tbNHAXUATBAN nxb =db.tbNHAXUATBAN.Find(id);
            db.tbNHAXUATBAN.Remove(nxb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tbNHAXUATBAN nxb = db.tbNHAXUATBAN.Find(id);
            return View(nxb);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string id =f.Get("MaNhaXuatBan");
            tbNHAXUATBAN nxb = db.tbNHAXUATBAN.Find(id);
            nxb.TenNhaXuatBan =f.Get("TenNhaXuatBan");
            nxb.DiaChi =f.Get("DiaChi");
            nxb.SoDienThoai =f.Get("SoDienThoai");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            var checkBox = (from db in db.tbNHAXUATBAN select db).ToList();
            ViewBag.CheckBox = checkBox;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            tbNHAXUATBAN nxb = new tbNHAXUATBAN();
            string mnxb =f.Get("MaNhaXuatBan");
            string tnxb =f.Get("TenNhaXuatBan");
            string dc =f.Get("DiaChi");
            string sdt =f.Get("SoDienThoai");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            var nxb = db.tbNHAXUATBAN.Find(id);
            return View(nxb);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string MaNhaXuatBan = f.Get("MaNhaXuatBan");
            var ms = db.tbNHAXUATBAN.Find("MaNhaXuatBan");
            return RedirectToAction("Details/" + MaNhaXuatBan);
        }
    }
}
