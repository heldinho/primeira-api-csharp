using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Model;
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
            Console.WriteLine(filePath);

            // var employee = new Employee(employeeView.name, employeeView.age, filePath);
            // _employeeRepository.Add(employee);

            return ok();
        }

        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.GetById(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);
            return File(dataBytes, "image/png");
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
