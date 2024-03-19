using iGuruPrep;
using System.Text;
using UserManagement_API.DTOs;
using UserManagement_API.Models;
using UserManagement_API.Repositories.Interfaces;

namespace UserManagement_API.Repositories.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly DbContextClass _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public RegistrationService(DbContextClass dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<string> UserRegistration(RegistrationDtocs request)
        {
            try
            {
                var imageUrl = "";
                if (request.UserId == 0)
                {
                    if (request.Photo != null)
                    {
                        var folderName = Path.Combine(_hostingEnvironment.ContentRootPath, "ProjectImages");
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        var fileName = Path.GetFileNameWithoutExtension(request.Photo.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(request.Photo.FileName);
                        var filePath = Path.Combine(folderName, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            await request.Photo.CopyToAsync(fileStream);
                        }
                        imageUrl = fileName;

                    }
                    var newRegistration = new UserRegistration
                    {
                        Country = request.Country,
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        MiddleName = request.MiddleName,
                        ModifiedBy = request.ModifiedBy,
                        ModifiedOn = request.ModifiedOn,
                        Password = request.Password,
                        PhoneNumber = request.PhoneNumber,
                        Photo = imageUrl,
                        SchoolCode = request.SchoolCode,
                        State = request.State,
                        Status = true,
                        PersonType = request.PersonType,
                        RoleID = request.RoleID,
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1
                    };

                    _dbContext.tblUser.Add(newRegistration);
                    _dbContext.SaveChanges();

                    return "User Registered Successfully.";
                }
                else
                {
                    var data = _dbContext.tblUser.Where(x => x.UserId == request.UserId).FirstOrDefault();
                    if (data == null)
                    {
                        return "";
                    }
                    else
                    {
                        return "User Already Exists";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
