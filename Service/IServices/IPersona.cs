using Domain.Entities;
namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();
        List<EmpleadosVM> ObtenerEmpleado();


        List<string> sendMessage(string email, string secret);
    }
}
