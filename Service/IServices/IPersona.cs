﻿using Domain.Entities;
namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();

        List<EmpleadosVM> ObtenerEmpleado();
      
        List<EmpleadosVM> ObtenerEmpleadoItem();
      
        List<Asignaciones> ObtenerEmpleado();

        List<Asignaciones> ObtenerEmpleadosById(int id);
      
        List<Items> ObtenerItemsDisponibles();


        List<string> sendMessage(string email, string secret);

        List<string> sendMessageRemember(string email, string secret, string destination);

        void GuardarEmpleados(Persona empleado);

        void GuardarItem(Items item);

        void AsignarItem(ItemsVM  asignacion);

        void SetStatusItem(bool status, int id_item);
    }
}
