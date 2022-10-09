using Services.Interfaces;
using AutoMapper;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Services;

namespace Services;
public class ServiceManager : IServiceManager
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Project> _projectRepository;
    private readonly IGenericRepository<Employee> _employeeRepository;
    private readonly IGenericRepository<Customer> _customerRepository;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper,
        IGenericRepository<Project> projectRepository, 
        IGenericRepository<Employee> employeeRepository, 
        IGenericRepository<Customer> customerRepository)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _projectRepository = projectRepository;
        _employeeRepository = employeeRepository;
        _customerRepository = customerRepository;
    }

    public IGenericService<Project> ProjectService => new GenericService<Project>(_repositoryManager, _mapper, _projectRepository);
    public IGenericService<Employee> EmployeeService => new GenericService<Employee>(_repositoryManager, _mapper, _employeeRepository);
    public IGenericService<Customer> CustomerService => new GenericService<Customer>(_repositoryManager, _mapper, _customerRepository);
}
