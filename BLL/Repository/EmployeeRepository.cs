using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly MVCDbContext _context;

        public EmployeeRepository(MVCDbContext context ):base(context) 
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeesByDepartmentName(string name)
        {
            throw new NotImplementedException();
        }
        //public int AddEmployee(Employee employee)
        //{
        //    _context.Employees.Add( employee );
        //    return _context.SaveChanges();
        //}

        //public int DeleteEmployee(Employee employee)
        //{
        //    _context.Employees.Remove(employee);
        //    return _context.SaveChanges();
        //}

        //public IEnumerable<Employee> GetAllEmployees()
        //{
        //   return _context.Employees.ToList();
        //}

        //public Employee GetEmployeeById(int? id)
        //{
        //    return _context.Employees.Find(id);
        //}

        //public int UpdateEmployee(Employee employee)
        //{
        //    _context.Employees.Update(employee);
        //    return _context.SaveChanges();
        //}
    }
}
