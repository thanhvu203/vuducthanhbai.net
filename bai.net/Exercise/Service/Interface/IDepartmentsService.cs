using Exercise.Dto;

namespace Exercise.Service.Interface
{
    public interface IDepartmentsService
    {
        string AddNewDepartments(DepartmentDto departmentDto);

        string deletete (int Id);
    }
}
