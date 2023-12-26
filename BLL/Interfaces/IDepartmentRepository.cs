using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    #region None Generic

    //public interface IDepartmentRepository
    //{
    //    //Department GetDepartmentById(int? id);
    //    //IEnumerable<Department> GetAllDepartments();
    //    //int AddDepartment(Department department);
    //    //int UpdateDepartment(Department department);
    //    //int DeleteDepartment(Department department);
    //}
    #endregion
    #region Generic
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
    }
    #endregion

}
