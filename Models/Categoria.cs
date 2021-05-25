using System.Collections.Generic;

namespace pc3.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NombreCategoria { get; set; }
        public ICollection<Producto> Productos {get; set; }
    }
}