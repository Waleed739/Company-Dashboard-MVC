using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;
using PL.Helper;
using PL.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace PL.Controllers
{
    public class EmployeeController1 : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public EmployeeController1(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public IActionResult Index(string SearchValue = "")
        {
            IEnumerable<Employee> employees;
            IEnumerable<EmployeeVM> MappedEmployees;
            // if (string.IsNullOrEmpty(SearchValue))
            employees = _uniteOfWork.EmployeeRepository.GetAll();
            MappedEmployees = _mapper.Map<IEnumerable<EmployeeVM>>(employees);
            // else
            //     employees = _uniteOfWork.EmployeeRepository.Search(SearchValue);

            return View(MappedEmployees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Department2 = _uniteOfWork.DepartmentRepository.GetAll();
            return View(new EmployeeVM());
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                //Employee employee = new Employee()
                //{
                //    Name = employeeVM.Name,
                //    Address = employeeVM.Address,
                //    Salary = employeeVM.Salary,
                //    DateOfHiring = employeeVM.DateOfHiring,
                //    DepartmentId = employeeVM.DepartmentId,
                //    IsActive = employeeVM.IsActive
                //};
                var employee = _mapper.Map<Employee>(employeeVM);
                employee.ImagePath = DocumentSettings.UploadFile(employeeVM.Image, "Images");
                try
                {
                    _uniteOfWork.EmployeeRepository.Add(employee);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            return View(employeeVM);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = _uniteOfWork.EmployeeRepository.GetById(id);
            var employeeVM = new EmployeeVM();
            employee = _mapper.Map<Employee>(employeeVM);

            if (employee == null)
                return NotFound();
            return View(employeeVM);
        }
        [HttpPost]
        public IActionResult Update(int id, EmployeeVM employeeVM)
        {


            if (id != employeeVM.Id)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = _mapper.Map<Employee>(employeeVM);
                    _uniteOfWork.EmployeeRepository.Update(employee);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View(employeeVM);

        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = _uniteOfWork.EmployeeRepository.GetById(id);
            var employeeMV = new EmployeeVM();
            employeeMV = _mapper.Map<EmployeeVM>(employee);
            if (employeeMV == null)
                return NotFound();
            _uniteOfWork.EmployeeRepository.Delete(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var employee = _uniteOfWork.DepartmentRepository.GetById(id);
                var employeeMV = new EmployeeVM();
                employeeMV = _mapper.Map<EmployeeVM>(employee);

                if (employeeMV == null)
                    return NotFound();
                return View(employeeMV);
            }
            catch (Exception )
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
