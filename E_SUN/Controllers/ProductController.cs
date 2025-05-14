using E_SUN.Models;
using E_SUN.Models.ViewModel;
using Humanizer.Inflections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace E_SUN.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            //string userId = HttpContext.Session.GetString("UserId") ?? "A1236456789";
            string userId= "A1236456789";
            E_SUN_BUYContext context = new E_SUN_BUYContext();
            var result = context.LikeListModels.FromSqlRaw("EXEC GetLikeList @UsrId = {0}", userId).ToList();

            return View(result);
        }
        public IActionResult Details(string id)
        {
            E_SUN_BUYContext context = new E_SUN_BUYContext();
            var result = context.LikeListDetailModels.FromSqlRaw("EXEC GetLikeListDetail @UsrId = {0}", id).ToList();

            return View(result);
        }
        
        public IActionResult Update(int id, int subno)
        {
            E_SUN_BUYContext context = new E_SUN_BUYContext();
            var user = context.LikeListDetails.FirstOrDefault(u => u.Sn == id && u.SubNo == subno);
            if (user == null)
            {
                return RedirectToAction("List");
            }            
            return View(user);

        }
        [HttpPost]
        public IActionResult Update(LikeListDetail listDetail)
        {
            E_SUN_BUYContext context = new E_SUN_BUYContext();
            var user = context.LikeListDetails.FirstOrDefault(u => u.Sn == listDetail.Sn && u.SubNo == listDetail.SubNo);
            if (user != null)
            {

                context.Database.ExecuteSqlRaw("EXEC UpdateLikeListDetail @SN = {0},@SubNo={1},@ProductNo={2},@ProductCount={3}", listDetail.Sn, listDetail.SubNo, listDetail.ProductNo.Value, listDetail.ProductCount);
            }
            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LikeListDetail listDetail)
        {
            //string userId = HttpContext.Session.GetString("UserId") ?? "A1236456789";
            string userId = "A1236456789";
            E_SUN_BUYContext context = new E_SUN_BUYContext();
            int nextListNo;
            var user = context.LikeLists.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                nextListNo = user.Sn;
            }
            else
            {
                using var command = context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SELECT NEXT VALUE FOR ListNo";

                context.Database.OpenConnection();
                var rtn = command.ExecuteScalar();
                nextListNo = Convert.ToInt32(rtn);
            }
            
            context.Database.ExecuteSqlRaw("EXEC InsertLikeListDetail @SN = {0},@SubNo={1},@ProductNo={2},@ProductCount={3},@User_ID={4}", nextListNo, listDetail.SubNo, listDetail.ProductNo.Value, listDetail.ProductCount, userId);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            E_SUN_BUYContext context = new E_SUN_BUYContext();
            var user = context.LikeLists.FirstOrDefault(u => u.Sn == id);
            if (user != null)
            {
                context.Database.ExecuteSqlRaw("EXEC DeleteLikeList @SN = {0}", id);
            }
            return RedirectToAction("List");
        }
    }
}
