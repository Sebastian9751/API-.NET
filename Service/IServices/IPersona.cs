using Domain.Entities;
namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();
        List<EmpleadosVM> ObtenerEmpleado();

        string CrearPersonService();

        bool IsAuthenticated(LoginVM loginVM);

        List<string> sendMessage(string email, string secret);
    }
}
