using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Model;
using PrimeiraApi.Model.Dto;
using PrimeiraApi.ViewModel;

namespace PrimeiraApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.photo.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.photo.CopyTo(fileStream);

            // var employee = new Employee(employeeView.name, employeeView.age, filePath);
            // _employeeRepository.Add(employee);

            return ok();
        }

        [HttpGet]
        [Route("all")]
        public IActionResult Get()
        {
            var employee = _employeeRepository.GetAll();
            return Ok(employee);
        }

        private IActionResult ok()
        {
            throw new NotImplementedException();
        }
    }
}
