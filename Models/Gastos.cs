namespace Proyecto.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string? Fecha { get; set; }
    }
}
