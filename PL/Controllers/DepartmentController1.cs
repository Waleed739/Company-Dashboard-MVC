using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DepartmentController1 : Controller
    {
        //private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentController1> _logger;
        private readonly IUniteOfWork _uniteOfWork;

        //private readonly IEmployeeRepository _employeeRepository;

        public DepartmentController1(/*IDepartmentRepository departmentRepository,*/
            ILogger<DepartmentController1> logger,IUniteOfWork uniteOfWork/*,IEmployeeRepository employeeRepository*/)
        {
            //_departmentRepository = departmentRepository;
            _logger = logger;
            _uniteOfWork = uniteOfWork;
            //_employeeRepository = employeeRepository;
        }
        [HttpGet,ActionName("Departments")]
        public IActionResult Index()
        {
            var departments = _uniteOfWork.DepartmentRepository.GetAll();
             
            //to send data fro controller to view

            //ViewData["Message"] = "Hello from view Data";                      for the same request
            //ViewBag.Message2 = "Hello from view bag";                          for the same request
            TempData.Keep("Message");       //to keep the temp data even if you refresh the page         
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _uniteOfWork.DepartmentRepository.Add(department);
               
                TempData["Message"] = "Department created successfully!!";   //for tewo consequetive requists 
               
                return RedirectToAction("Index");
            }
            return View(department);
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = _uniteOfWork.DepartmentRepository.GetById(id);
            if (department == null)
                return NotFound();
            return View(department);
        }
        [HttpPost]
        public IActionResult Update(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _uniteOfWork.DepartmentRepository.Update(department);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View(department);
            
        }
        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var department = _uniteOfWork.DepartmentRepository.GetById(id);
                if (department == null)
                    return NotFound();
                return View(department);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = _uniteOfWork.DepartmentRepository.GetById(id);
            if (department == null)
                return NotFound();
            _uniteOfWork.DepartmentRepository.Delete(department);
            return RedirectToAction("Index");
        }
    }
}
