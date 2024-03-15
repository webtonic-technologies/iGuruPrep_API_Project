using ControlPanel_API.Models;

namespace ControlPanel_API.Repositories.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> AddEmployee(Employee employee);
        List<Employee> GetEmployeList(string role, string designation);
    }
}
