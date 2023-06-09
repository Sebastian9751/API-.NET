﻿using Domain.Entities;
namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();
        List<Asignaciones> ObtenerEmpleado();

        List<Asignaciones> ObtenerEmpleadosById(int id);

        List<Items> ObtenerItemsDisponibles();


        List<string> sendMessage(string email, string secret);
        String login(string email, string password);


        void GuardarEmpleados(Persona empleado);

        void GuardarItem(Items item);

        void AsignarItem(ItemsVM  asignacion);

        void SetStatusItem(bool status, int id_item);

        List<string> sendMessageRemember(string email, string secret, string destination);
    }
}
