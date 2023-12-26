using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class DepartmentRepository:GenericRepository<Department>,IDepartmentRepository
    {
        private readonly MVCDbContext _context;

        public DepartmentRepository(MVCDbContext context) : base(context)
        {
            _context = context;
        }

      

        //public int AddDepartment(Department department)
        //{
        //    _context.Departments.Add(department);
        //    return _context.SaveChanges();
        //}

        //public int DeleteDepartment(Department department)
        //{
        //    _context.Departments.Remove(department);
        //    return _context.SaveChanges();
        //}

        //public IEnumerable<Department> GetAllDepartments()
        //    => _context.Departments.ToList();

        //public Department GetDepartmentById(int? id)
        //=> _context.Departments.Find(id);

        //public int UpdateDepartment(Department department)
        //{
        //    _context.Departments.Update(department);
        //    return _context.SaveChanges();
        //}
    }
}
