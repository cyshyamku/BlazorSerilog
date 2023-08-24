using AutoMapper;
using BlazorLearning.Data.Data;
using BlazorLearning.Data.Models;
using BlazorLearning.Data.Repository.Interface;
using BlazorLearning.Shared.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BlazorLearning.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeRepository(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeViewModel> AddEmployee(EmployeeViewModel employee)
        {
            var empDetails = new Employee
            {
                Name = employee.Name,
                Address = employee.Address,
                MobileNumber = employee.MobileNumber,
                EmailId = employee.EmailId
            };
            var empResult = await _dbContext.Employees.AddAsync(empDetails);
            await _dbContext.SaveChangesAsync();
            employee.Id = empResult.Entity.Id;
            return employee;
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<EmployeeViewModel> GetEmployeeData(int id)
        {
            var empResult = await _dbContext.Employees.FindAsync(id);
            if (empResult != null)
            {
                var result = _mapper.Map<EmployeeViewModel>(empResult);
                return result;
            }
            return new EmployeeViewModel();
        }

        public async Task<List<EmployeeViewModel>> GetEmployeeDetails()
        {
            try
            {
                var result = await _dbContext.Employees.ToListAsync();
                return _mapper.Map<List<EmployeeViewModel>>(result);
            }
            catch (Exception ex)
            {
                return new List<EmployeeViewModel>();
            }
           
        }

        public async Task<EmployeeViewModel> UpdateEmployeeDetails(EmployeeViewModel employee)
        {
            var empEntity = _mapper.Map<Employee>(employee);
            _dbContext.Entry(empEntity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return new EmployeeViewModel();
        }
    }
}
