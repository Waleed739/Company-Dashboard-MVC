using AutoMapper;
using DAL.Entities;
using PL.Models;

namespace PL.Mapper
{
    public class MappingProfilies:Profile
    {
        public MappingProfilies()
        {
            CreateMap<EmployeeVM, Employee>().ReverseMap();
        }
    }
}
