namespace Proyecto.Models
{
    public class Ingreso
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string? Fecha { get; set; }
    }
}