using System.Collections.Generic;
namespace pc3.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string  NombreProducto { get; set; }
        public string Foto { get;  set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Celular { get; set; }
        public string LugarCompra { get; set; }
        public string NombreComprador { get; set; }
         public Categoria Categoria { get; set; }

         // EF Shadow property
         
         public int CategoriaId { get; set; }



    }
}