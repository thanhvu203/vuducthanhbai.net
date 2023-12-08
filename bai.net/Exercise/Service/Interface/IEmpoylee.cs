using Exercise.Dto;

namespace Exercise.Service.Interface
{
    public interface IEmpoylee
    {
        string AddEmpoylee(EmpoyleeDto dto, int idDepart);

        string UpdatedEmpoylee(EmpoyleeUpdateDto dto, int idDepart, int id);
        string Delete(int userid);
    }
}
