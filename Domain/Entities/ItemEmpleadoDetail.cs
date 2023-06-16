namespace Repository.DAO
{
    public class ItemEmpleadoDetail
    {
        public int Id { get; set; }
        public int Id_asignacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaLiberacion { get; set; }
    }
}