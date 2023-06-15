using Domain;
using Domain.Entities;
namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();
        List<Asignaciones> ObtenerEmpleado();

        ItemEmpleado ObtenerEmpleadosById(int id);

        List<Items> ObtenerItemsDisponibles();


        List<string> sendMessage(string email, string secret);
        String login(string email, string password);


        void GuardarEmpleados(Persona empleado);

        void GuardarItem(Items item);

        void AsignarItem(ItemsVM  asignacion);

        void SetStatusItem(bool status, int id_item);
        
        bool DeleteEmpleado(int id);
        bool DeleteItem(int id);
        bool UpdateEmpleado(UpdatePersona persona);
        bool UpdateItem(Items item);

        string DeleteAsignaciones(int idAsignacion);
        string DeleteAsignacionesByEmpleado(int id);
        List<string> sendMessageRemember(string email, string secret, string destination);
    }
}
