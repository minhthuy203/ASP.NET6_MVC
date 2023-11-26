using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Csharp.DatabaseContext;

namespace MVC_Csharp.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manager/[action]")]
    public class DbManagerController : Controller
    {
        private readonly MvcDBContext _mvcDbConnection;

        public DbManagerController(MvcDBContext mvcDBContext)
        {
            _mvcDbConnection = mvcDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteDB() { return View(); }

        [TempData]
        public string? MessageStatus { get; set; }

        [HttpPost]
        public async Task<ActionResult> DeleteDBAsync()
        {
            var success = await _mvcDbConnection.Database.EnsureDeletedAsync();
            MessageStatus = success ? "Xóa thành công" : "Xóa db thất bại";
            return RedirectToAction("Index");
        } 
        [HttpPost]
        public async Task<ActionResult> UpdateDBAsync()
        {
            await _mvcDbConnection.Database.MigrateAsync();
            MessageStatus = "Cập nhật thành công";
            return RedirectToAction("Index");
        }
    }


}