using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    #region None Generic
    //public interface IEmployeeRepository
    //{
    //    //Employee GetEmployeeById(int? id);
    //    //IEnumerable<Employee> GetAllEmployees();
    //    //int AddEmployee(Employee employee);
    //    //int UpdateEmployee(Employee employee);
    //    //int DeleteEmployee(Employee employee);

    //}
    #endregion
    #region Generic
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        //IEnumerable<Employee> GetEmployeesByDepartmentName(string name);
    }
    #endregion

}
