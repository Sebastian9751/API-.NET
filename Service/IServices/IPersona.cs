using Domain;
using Domain.Entities;
namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();
        List<EmpleadosVM> ObtenerEmpleado();

        string CrearPersonService(PersonaVM employeVM);

        bool IsAuthenticated(LoginVM loginVM);

        List<string> sendMessage(string email, string secret);
    }
}
