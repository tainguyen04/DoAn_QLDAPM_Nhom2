using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLCHBanDienThoaiMoi.Data;
using QLCHBanDienThoaiMoi.Models;
using SlugGenerator;

namespace QLCHBanDienThoaiMoi.Controllers
{
    public class SanPhamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SanPhamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SanPham.Include(s => s.DanhMucSanPham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SanPhams/Details/5
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
        //Xử lý upload file
        public async Task< string> UploadFile(IFormFile file)
        {
            
            if (file == null || file.Length == 0)
                return "default.png";
            var allowed = new[] { ".jpg", ".png", ".jpeg" };
            //Lấy tên file trước dấu .
            var f = Path.GetFileNameWithoutExtension(file.FileName);
            //Chuẩn hóa tiếng việt thành không dấu
            f = f.GenerateSlug().Replace("-", "");
            //Lấy phần mở rộng sau dấu .
            var ext = Path.GetExtension(file.FileName).ToLower();

            if (!allowed.Contains(ext))
            {
                throw new Exception("Định dạng file không được phép!");
            }

            var fileName = $"{f}{ext}";
            var path = Path.Combine("wwwroot","images", fileName);

            if (System.IO.File.Exists(path))
            {
                throw new Exception("File đã tồn tại!");
            }
                
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
        // GET: SanPhams/Create
        public IActionResult Create()
        {
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucSanPham, "Id", "Id");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,[Bind("Id,TenSanPham,GiaNhap,GiaBan,SoLuongTon,DanhMucId,HangSanXuat,MoTa,HinhAnh,KhuyenMai")] SanPham sanPham)
        {
            
            if (ModelState.IsValid)
            {
                sanPham.HinhAnh = await UploadFile(file);
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
                ViewData["DanhMucId"] = new SelectList(_context.DanhMucSanPham, "Id", "TenDanhMuc", sanPham.DanhMucId);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham.FindAsync(id);
            var file = sanPham.HinhAnh;
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucSanPham, "Id", "TenDanhMuc", sanPham.DanhMucId);
            
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file,int id, [Bind("Id,TenSanPham,GiaNhap,GiaBan,SoLuongTon,DanhMucId,HangSanXuat,MoTa,HinhAnh,KhuyenMai")] SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (file != null && file.Length > 0)
                    {

                        if (!string.IsNullOrEmpty(sanPham.HinhAnh) && sanPham.HinhAnh != "default.png")
                        {
                            var oldPath = Path.Combine("wwwroot", "images", sanPham.HinhAnh);
                            if (System.IO.File.Exists(oldPath))
                                System.IO.File.Delete(oldPath);
                        }
                        sanPham.HinhAnh = await UploadFile(file);

                    }
                    else
                    {
                        sanPham.HinhAnh = sanPham.HinhAnh;
                    }
                        _context.Update(sanPham);
                        await _context.SaveChangesAsync();
                      
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucSanPham, "Id", "TenDanhMuc", sanPham.DanhMucId);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham != null)
            {
                if(!string.IsNullOrEmpty(sanPham.HinhAnh) && sanPham.HinhAnh != "default.png")
                {
                    var oldPath = Path.Combine("wwwroot", "images", sanPham.HinhAnh);
                    if(System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }
                _context.SanPham.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPham.Any(e => e.Id == id);
        }
    }
}
