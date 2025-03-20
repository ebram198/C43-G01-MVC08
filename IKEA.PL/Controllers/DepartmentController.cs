using AutoMapper;
using IKEA.BLL.Models.Departments;
using IKEA.BLL.Services;
using IKEA.DAL.Models.Departments;
using IKEA.PL.Models.Departmrnt;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentServices departmentServices, ILogger<DepartmentController> logger, IWebHostEnvironment environment,IMapper mapper)
        {
            _departmentServices = departmentServices;
            _logger = logger;
            _environment = environment;
         _mapper = mapper;
        }

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            //View Dictionary:pass data From Controller [Action]
            //to view [from this view=> partial view , LayOut]
            //1-view data => Is A Dictionary Type Property (introduced in Asp.net Framework)
            //3.5=>It Helps Us To Transfar The Data From Controller [Action] To view
            ViewData["message"] = "Hello View Data";

            //2-View Bag : is A dynamic Type Property [Introduced In .net Framework 4.0 based on dynaic Property]
            //It Helps Us To Transfer the Data From Control[Action] to view
            ViewBag.Message = "Hello ViewBag";
            var departments = _departmentServices.GetALLDepartment();

            return View(departments);
        }
        #endregion

        #region Create

        #region Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region Post
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatedDepartmentDTO department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            try
            {
                var result = _departmentServices.CreatedDepartment(department);
                //3-TempData: Is a Property Of Type Dictionary object 
                //Introduced In .net FrameWork 3.5: ued For Transering the Data 
                // Betwrenn 2 Request
                if (result>0)
                {
                    TempData["Message"] = "Department Is Created";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Message"] = "Department was not created";
                ModelState.AddModelError(string.Empty, "Department was not created.");
                return View(department);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating department");

                ViewBag.ErrorMessage = _environment.IsDevelopment() ? ex.Message : "An error occurred while creating the department.";
                return View(department);
            }
        }
        #endregion

        #endregion

        #region Details
        [HttpGet]

        public IActionResult Details(int? id)
        {
            if (id is  null)
            {
                return BadRequest(); //400
            }
            var department = _departmentServices.GetDepartmentbyId(id.Value);
            if (department is null)
            {
                return NotFound();//404
            }


            return View(department);
        }


        #endregion

        #region Edit
        #region Get
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department=_departmentServices.GetDepartmentbyId(id.Value);
            if (department is null) 
            {
                return NotFound();
            }
            var departmentVm = _mapper.Map<DepartmentDetailsReturnDTO, DepartmentEditViewModel>(department);
       
            return View(departmentVm);
        }
        #endregion
        #region post
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel DepartmentVM) 
        {
            if (!ModelState.IsValid)
            {
                return View(DepartmentVM);
            }
            var message=string.Empty;
            try
            {
                //Manual Mapping
                //var updateDepartment = new UpdateDepartmentDTO() 
                //{
                //    Id=id,
                //    code=DepartmentVM.Code,
                //    Name=DepartmentVM.Name,
                //    CreationDate=DepartmentVM.CreationDate,
                //};

                var updateDepartment = _mapper.Map<UpdateDepartmentDTO>(DepartmentVM);

                var updated=_departmentServices.UpdateDepartment(updateDepartment)>0;
                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
                message = "Sorry, An Error Acured While Updating the Department";
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, ex.Message);

                message=_environment.IsDevelopment()?ex.Message:" Sorry, An Error Acured While Updating the Department";
            }
            ModelState.AddModelError(String.Empty, message);
            return View(DepartmentVM);
        }
        #endregion
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
            var department = _departmentServices.GetDepartmentbyId(id.Value);
            if (department is null)
            {
                return NotFound();
            }

            return View(department); // Ensure Delete.cshtml exists
        }
        #endregion

        #region Post
        [HttpPost]
        [ValidateAntiForgeryToken] // Helps prevent CSRF attacks
        public IActionResult Delete(int id)
        {
            try
            {
                var deleted = _departmentServices.DeleteDepartment(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Department deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error: Could not delete department.";
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = "An error occurred while deleting the department.";
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion
        #endregion




    }
}
