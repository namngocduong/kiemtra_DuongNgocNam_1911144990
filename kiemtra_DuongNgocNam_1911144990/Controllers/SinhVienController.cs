using kiemtra_DuongNgocNam_1911144990.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kiemtra_DuongNgocNam_1911144990.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        MydataDataContext data = new MydataDataContext();
        public ActionResult ListSV()
        {
            var all_sv = from ss in data.SinhViens select ss;
            return View(all_sv);
        }
        public ActionResult Detail(string id)
        {
            var D_sv = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sv);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_MaSV = collection["MaSV"];
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_MaNganh = collection["MaNganh"];

            if (string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = E_MaSV.ToString();
                s.HoTen = E_HoTen.ToString();
                s.GioiTinh = E_GioiTinh.ToString();
                s.NgaySinh = E_NgaySinh;
                s.Hinh = E_Hinh.ToString();
                s.MaNganh = E_MaNganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            return this.Create();
        }
        public ActionResult Delete(string id)
        {
            var D_SV = data.SinhViens.First(m => m.MaSV == id);
            return View(D_SV);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_SV = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_SV);
            data.SubmitChanges();
            return RedirectToAction("ListSV");
        }
        public ActionResult Edit(string id)
        {
            var E_category = data.SinhViens.First(m => m.MaSV == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_SV = data.SinhViens.First(m => m.MaSV == id);
            var E_MaSV = collection["MaSV"];
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_MaNganh = collection["MaNganh"];
            if (string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Don't empty!";

            }
            else
            {
                E_SV.MaSV = E_MaSV;
                E_SV.HoTen = E_HoTen;
                E_SV.GioiTinh = E_GioiTinh;
                E_SV.NgaySinh = E_NgaySinh;
                E_SV.Hinh = E_Hinh;
                E_SV.MaNganh = E_MaNganh;

                UpdateModel(E_SV);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }

            return this.Edit(id);


        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}