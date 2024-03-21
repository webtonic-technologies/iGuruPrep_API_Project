using ControlPanel_API.DBContext;
using ControlPanel_API.DTOs;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlPanel_API.Repositories.Services
{
    public class MagazineService : IMagazineService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MagazineService(AppDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task AddNewMagazine(MagazineDTO magazineDTO)
        {
            var magazine = new Magazine
            {
                MagazineName = magazineDTO.MagazineName,
                ClassName = magazineDTO.ClassName,
                CourseName = magazineDTO.CourseName,
                DateAndTime = DateTime.Now
            };

            if (magazineDTO.File != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "Magazine");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                var fileName = Path.GetFileNameWithoutExtension(magazineDTO.File.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(magazineDTO.File.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await magazineDTO.File.CopyToAsync(fileStream);
                }
                magazine.PathURL = fileName;
            }

            _context.tblMagazine.Add(magazine);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMagazine(UpdateMagazineDTO magazineDTO)
        {
            var magazine = await _context.tblMagazine.FindAsync(magazineDTO.MagazineId);

            if (magazine == null)
                throw new Exception("Magazine not found");

            magazine.MagazineName = magazineDTO.MagazineName;
            magazine.ClassName = magazineDTO.ClassName;
            magazine.CourseName = magazineDTO.CourseName;

            _context.tblMagazine.Update(magazine);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MagazineDTO>> GetAllMagazines()
        {
            var magazines = await _context.tblMagazine.ToListAsync();
            return magazines.Select(m => new MagazineDTO
            {
                MagazineId = m.MagazineId,
                MagazineName = m.MagazineName,
                ClassName = m.ClassName,
                CourseName = m.CourseName
            });
        }

        public async Task<MagazineDTO> GetMagazineById(int id)
        {
            var magazine = await _context.tblMagazine.FindAsync(id);

            if (magazine == null)
                throw new Exception("Magazine not found");

            return new MagazineDTO
            {
                MagazineId = magazine.MagazineId,
                MagazineName = magazine.MagazineName,
                ClassName = magazine.ClassName,
                CourseName = magazine.CourseName
            };
        }

        public async Task DeleteMagazine(int id)
        {
            var magazine = await _context.tblMagazine.FindAsync(id);

            if (magazine == null)
                throw new Exception("Magazine not found");

            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "Magazine", magazine.PathURL);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.tblMagazine.Remove(magazine);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMagazineFile(MagazineDTO magazineDTO)
        {
            var magazine = await _context.tblMagazine.FindAsync(magazineDTO.MagazineId);

            if (magazine == null)
                throw new Exception("Magazine not found");

            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "Magazine", magazine.PathURL);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (magazineDTO.File != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "Magazine");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                var fileName = Path.GetFileNameWithoutExtension(magazineDTO.File.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(magazineDTO.File.FileName);
                var newFilePath = Path.Combine(uploads, fileName);
                using (var fileStream = new FileStream(newFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await magazineDTO.File.CopyToAsync(fileStream);
                }
                magazine.PathURL = fileName;
            }

            _context.tblMagazine.Update(magazine);
            await _context.SaveChangesAsync();
        }
        public async Task<byte[]> GetMagazineFileById(int id)
        {
            var magazine = await _context.tblMagazine.FindAsync(id);

            if (magazine == null)
                throw new Exception("Magazine not found");

            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "Magazine", magazine.PathURL);

            if (!File.Exists(filePath))
                throw new Exception("File not found");

            return await File.ReadAllBytesAsync(filePath);
        }
    }
}