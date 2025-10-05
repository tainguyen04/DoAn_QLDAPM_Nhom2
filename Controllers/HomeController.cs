using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLCHBanDienThoaiMoi.Data;
using QLCHBanDienThoaiMoi.Models;

namespace QLCHBanDienThoaiMoi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index(int page = 1,int pageSize = 10)
        {
            var sanPhams = _context.SanPham.Include(s => s.DanhMucSanPham).OrderByDescending(s => s.KhuyenMai);
            var totalItems = await sanPhams.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var pagedSanPhams = await sanPhams.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            ViewBag.TotalItems = totalItems;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            return View(pagedSanPhams);
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.DanhMucSanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }
    }

}
