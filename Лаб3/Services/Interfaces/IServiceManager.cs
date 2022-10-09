using Domain.Models;

namespace Services.Interfaces;

public interface IServiceManager
{
    IGenericService<Project> ProjectService { get; }
    IGenericService<Employee> EmployeeService { get; }
    IGenericService<Customer> CustomerService { get; }
}
