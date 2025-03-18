using IKEA.BLL.Models.Employee;
using IKEA.BLL.Services;
using IKEA.BLL.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class EmployeeController : Controller
    {
        #region Services
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IDepartmentServices _departmentServices;

        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment, ILogger<EmployeeController> logger, IDepartmentServices departmentServices)
        {
            _logger = logger;
           _departmentServices = departmentServices;
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
            
        }
        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Department"]=_departmentServices.GetALLDepartment();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeDto);
            }

            try
            {
                if (employeeDto.Salary == null) // Ensure salary is always assigned
                {
                    employeeDto.Salary = 0;
                }

                var result = _employeeService.CreateEmployee(employeeDto);

                if (result > 0)
                {
                    TempData["SuccessMessage"] = "Employee created successfully!";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Employee was not created. Please try again.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating an Employee.");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
            }

            return View(employeeDto);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null)
            {
                return NotFound();
            }

            return View(employee);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null)
            {
                return NotFound();
            }
            ViewData["Departments"] = _departmentServices.GetALLDepartment();
            return View(new UpdatedEmployeeDto()
            {
                Name = employee.Name,
                Address = employee.Address,
                Email = employee.Email,
                Age = employee.Age,
                Salary = employee.Salary ?? 0, // Ensure a default value for Salary
                HiringDate = employee.HiringDate,
                Phone = employee.Phone,
                IsActive = employee.ISActive,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
            });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, UpdatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeDto);
            }

            try
            {
                if (employeeDto.Salary == null) // Ensure Salary is not null
                {
                    employeeDto.Salary = 0;
                }

                var updated = _employeeService.updateEmployee(employeeDto) > 0;
                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "The Employee was not updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError(string.Empty, "An error occurred while updating the Employee.");
            }

            return View(employeeDto);
        }
        #endregion


        #region Delete
        #region Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null)
            {
                return NotFound();
            }

            return View(employee);
        }
        #endregion
        #region Post
        public IActionResult Delete(int id)
        {
            var message = string.Empty;

            try
            {
                var deleted = _employeeService.DeleteEmployee(id);
                if (deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                message = "Sorry,An Error Accuring While Deleting Employee";
            }
            catch (Exception ex)
            {

                _logger?.LogError(ex, ex.Message);
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "Sorry,An Error Accuring While Deleting Employee";


            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #endregion









    }
}
