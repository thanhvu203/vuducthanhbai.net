using Exercise.DataBase;
using Exercise.Dto;
using Exercise.Models;
using Exercise.Respo.Interface;
using Exercise.Service.Interface;
using System;
using WebApi.TokenConfig;

namespace Exercise.Service.Service
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IRepo _irepo;
        private readonly DBContext _dBContext;
        public DepartmentsService(DBContext dbContext, IRepo repo)
        {
            _dBContext = dbContext;
            _irepo = repo;
        }
        public string AddNewDepartments(DepartmentDto departmentDto)
        {
            if (departmentDto == null)
            {
                throw new ArgumentNullException("not null");
            }

            var random = new Random();
            var employeeCode = $"EMP-{random.Next(1000, 9999)}";
            Departments departments = new Departments
            {
                NameDepartments = departmentDto.NameDepartments,
                CodeDepartment = employeeCode,
                Location = departmentDto.Location,
            };

            _dBContext.Add(departments);
            _dBContext.SaveChanges();

            return ("add sucess!! ");
        }



        public string deletete(int Id)
        {
            var delete = _irepo.GetDepartByID(Id);
            if (delete == null)
            {
                throw new ArgumentNullException("not found");
            }
            _dBContext.Remove(delete);
            return ("deleted !!");
        }
    }
}
