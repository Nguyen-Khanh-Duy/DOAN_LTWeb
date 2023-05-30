using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using QUANLYNHASACH.Models;
using PagedList;
using System.Web.UI;

namespace QUANLYNHASACH.Controllers
{
    public class SACHController : Controller
    {
        NHASACHEntities2 db = new NHASACHEntities2();
        // GET: SACH
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds =( from sach in db.tbSACHs select sach).OrderBy(x => x.MaSach);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tbSACH sach = db.tbSACHs.Find(id);
           
                
            return View(sach);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id =f.Get("MaSach");
            tbSACH sach =db.tbSACHs.Find(id);
            db.tbSACHs.Remove(sach);
            db.SaveChanges(); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tbSACH sach = db.tbSACHs.Find(id);
            return View(sach);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string id =f.Get("MaSach");
            tbSACH sach = db.tbSACHs.Find(id);
            sach.TenSach =f.Get("TenSach");
            sach.TenTacGia =f.Get("TenTacGia");
            sach.GiaBia =int.Parse(f.Get("GiaBia"));
            sach.GiaBanChoDaiLy =int.Parse(f.Get("GiaBanChoDaiLy"));
            sach.MaNhaXuatBan =f.Get("MaNhaXuatBan");
            sach.SoTrang =int.Parse(f.Get("SoTrang"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            var checkBox = (from db in db.tbSACHs select db).ToList();
            ViewBag.CheckBox =checkBox;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            tbSACH sach =new tbSACH();
            string ms =f.Get("MaSach");
            string ts =f.Get("TenSach");
            string ttg =f.Get("TenTacGia");
            int gb = int.Parse(f.Get("GiaBia")); 
            int gbcdl =int.Parse(f.Get("GiaBanChoDaiLy"));
            string mnxb =f.Get("MaNhaXuatBan");
            int st =int.Parse(f.Get("SoTrang"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            var sach = db.tbSACHs.Find(id);
            return View(sach);
        }
        [HttpGet]
        public ActionResult Find()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string MaSach =f.Get("MaSach");
            var ms = db.tbSACHs.Find("MaSach");
            return RedirectToAction("Details/"+MaSach);
        }
        
        
    }
}

    





