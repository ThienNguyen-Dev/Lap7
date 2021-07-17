using QuanLySach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLySach.Controllers
{
    public class SachController : ApiController
    {
        [HttpGet]
        public List<Sach> GetSachLists()
        {
            DbSachDataContext db = new DbSachDataContext();
            return db.Saches.ToList();
        }
        [HttpGet]
        public Sach GetSach_test(int id)
        {
            DbSachDataContext db = new DbSachDataContext();
            return db.Saches.FirstOrDefault(x => x.id == id);
        }
        [HttpPost]
        public bool InsertNewSach(string Title, string AuthorName, int Price, string Content)
        {
            try
            {
                DbSachDataContext db = new DbSachDataContext();
                Sach sach = new Sach();
                sach.Title = Title;
                sach.AuthorName = AuthorName;
                sach.Price = Price;
                sach.Content = Content;
                db.Saches.InsertOnSubmit(sach);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut]
        public bool UpdateSach(int id,string Title, string AuthorName, int Price, string Content)
        {
            try
            {
                DbSachDataContext db = new DbSachDataContext();
                //lấy food tồn tại ra
                Sach sach = db.Saches.FirstOrDefault(x => x.id == id);
                if (sach == null) return false;//không tồn tại false
                sach.Title = Title;
                sach.AuthorName = AuthorName;
                sach.Price = Price;
                sach.Content = Content;
                db.SubmitChanges();//xác nhận chỉnh sửa
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete]
        public bool DeleteSach(int id)
        {
            DbSachDataContext db = new DbSachDataContext();
            //lấy food tồn tại ra
            Sach sach = db.Saches.FirstOrDefault(x => x.id == id);
            if (sach == null) return false;
            db.Saches.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return true;
        }
    }
    
}
