﻿using Domain.Entities;
namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();
        List<EmpleadosVM> ObtenerEmpleado();

        List<Items> ObtenerItemsDisponibles();


        List<string> sendMessage(string email, string secret);


        void GuardarEmpleados(Persona empleado);

        void GuardarItem(Items item);

        void AsignarItem(ItemsVM  asignacion);
    }
}
