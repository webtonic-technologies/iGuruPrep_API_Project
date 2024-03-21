using ControlPanel_API.DBContext;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;

namespace ControlPanel_API.Repositories.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee emp)
        {
            try
            {
                Employee employee = new Employee
                {
                    EmployeeCode = emp.EmployeeCode,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    PhoneNumber = emp.PhoneNumber,
                    Email = emp.Email,
                    DateOfBirth = emp.DateOfBirth,
                    PinCode = emp.PinCode,
                    State = emp.State,
                    District = emp.District,
                    City = emp.City,
                    Role = emp.Role,
                    Designation = emp.Designation,
                    Subjects = emp.Subjects,

                };

                //_context.Employee.Add(employee);
                _context.SaveChanges();

                return await Task.FromResult(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> GetEmployeList(string role, string designation)
        {
            List<Employee> list = new List<Employee>();
            try
            {
                if (string.IsNullOrEmpty(role) && string.IsNullOrEmpty(designation))
                {
                    //list = _context.Employee.ToList();
                }
                else
                {
                    /* list = _context.Employee.Where(x => (string.IsNullOrEmpty(role) || x.Role == role)
                                                         && (string.IsNullOrEmpty(designation) || x.Designation == designation))
                                              .Distinct()
                                              .ToList();*/
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
