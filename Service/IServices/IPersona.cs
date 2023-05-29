using Domain.Entities;
namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();
        List<Asignaciones> ObtenerEmpleado();

        List<Items> ObtenerItemsDisponibles();


        List<string> sendMessage(string email, string secret);


        void GuardarEmpleados(Persona empleado);

        void GuardarItem(Items item);

        void AsignarItem(ItemsVM  asignacion);

        void SetStatusItem(bool status, int id_item);
    }
}
