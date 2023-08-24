using BlazorLearning.Shared.ViewModel;

namespace BlazorLearning.Data.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeViewModel>> GetEmployeeDetails();
        Task<EmployeeViewModel> AddEmployee(EmployeeViewModel employee);
        Task<EmployeeViewModel> UpdateEmployeeDetails(EmployeeViewModel employee);
        Task<EmployeeViewModel> GetEmployeeData(int id);
        Task DeleteEmployee(int id);
    }
}
