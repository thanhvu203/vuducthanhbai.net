using Exercise.DataBase;
using Exercise.Dto;
using Exercise.Models;
using Exercise.Respo.Interface;
using Exercise.Service.Interface;

namespace Exercise.Service.Service
{
    public class EmpoyleeSevice : IEmpoylee
    {
        private readonly IRepo _irepo;
        private readonly DBContext _dBContext;
        public EmpoyleeSevice(DBContext dbContext, IRepo repo)
        {
            _dBContext = dbContext;
            _irepo = repo;
        }
        public string AddEmpoylee(EmpoyleeDto dto, int idDepart)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto), "Not null");
            var random = new Random();
            var employeeCode = $"EMP-{random.Next(1000, 9999)}";

            var department = _dBContext.Departments.SingleOrDefault(d => d.Id == idDepart);
            if (department == null)
            {
                throw new ArgumentException("Invalid DepartmentId", nameof(idDepart));
            }

            department.NumberOfPersonal++;

            Employee employee = new Employee
            {
                EmployeeName = dto.EmployeeName,
                Employeecode = employeeCode,
                Department = department.NameDepartments,
                Rank = dto.Rank,
            };

            _dBContext.Employees.Add(employee);
            _dBContext.SaveChanges();

            return "Add success!!";
        }

        public string UpdatedEmpoylee(EmpoyleeUpdateDto dto, int idDepart, int userid)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto), "Not null");

            var existingEmpolyee = _dBContext.Employees.FirstOrDefault(c => c.Id == userid);
            var exitsDepart = _dBContext.Departments.FirstOrDefault(d => d.Id == idDepart);
            if (existingEmpolyee == null) throw new ArgumentNullException(nameof(existingEmpolyee), "Not null");


            existingEmpolyee.EmployeeName = dto.name;

            existingEmpolyee.Department = exitsDepart.NameDepartments;
            existingEmpolyee.Rank = dto.rank;


            _dBContext.SaveChanges();

            return "Update success!!";
        }


        public string Delete( int userid)
        {
           
            var existingEmpolyee = _dBContext.Employees.FirstOrDefault(c => c.Id == userid);
           _dBContext.Remove(existingEmpolyee);
            _dBContext.SaveChanges();

            return "delete success!!";
        }

    }
}
