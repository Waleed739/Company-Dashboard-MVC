using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        public IEmployeeRepository EmployeeRepository { get ; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public UniteOfWork(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
        }
    }
}
