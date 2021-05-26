using Microsoft.AspNetCore.Mvc;
using pc3.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pc3.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoContext _context;
        public ProductoController(ProductoContext context){
            _context = context;
        }
        public IActionResult Productos() {
            var productos = _context.Productos.Include(x => x.Categoria).OrderBy(p => p.NombreProducto).ToList();
            return View(productos);
        }
        public IActionResult Categorias() {
            var categorias = _context.Categorias.OrderBy(p => p.NombreCategoria).ToList();
            return View(categorias);
        }
        public IActionResult NuevoProducto() {
            ViewBag.Categorias = _context.Categorias.ToList().Select(p => new SelectListItem(p.NombreCategoria, p.Id.ToString()));
            return View();
        }
        [HttpPost]
        public IActionResult NuevoProducto(Producto p) {
            if (ModelState.IsValid) {
                _context.Add(p);
                _context.SaveChanges();
                return RedirectToAction("NuevoProductoConfirmacion");
            }
            return View(p);
        }
         public IActionResult NuevoProductoConfirmacion() {
            return View();
        }
        public IActionResult NuevaCategoria() {
            return View();
        }
        [HttpPost]
        public IActionResult NuevaCategoria(Categoria p) {
            if (ModelState.IsValid) {
                _context.Add(p);
                _context.SaveChanges();
                return RedirectToAction("NuevaCategoriaConfirmacion");
            }
            return View(p);
        }
        public IActionResult NuevaCategoriaConfirmacion() {
            return View();
        }
        [HttpPost]
        public IActionResult BorrarCategoria(int id) {
            var categoriasproductos = _context.Categorias.Find(id);
            _context.Remove(categoriasproductos);
            _context.SaveChanges();

            return RedirectToAction("Categorias");
        }
        public IActionResult EditarCategoria(int id) {
            var categoriaproducto = _context.Categorias.Find(id);
            return View(categoriaproducto);
        }
        [HttpPost]
        public IActionResult EditarCategoria(Categoria p) {
            if (ModelState.IsValid) {
                var categoriaproducto = _context.Categorias.Find(p.Id);
                categoriaproducto.NombreCategoria = p.NombreCategoria;
                _context.SaveChanges();
                return RedirectToAction("EditarPuebloConfirmacion");
            }
            return View(p);
        }
         public IActionResult EditarCategoriaConfirmacion() {
            return View();
        }
        public IActionResult Lista() {
            var productos = _context.Productos.OrderBy(x => x.NombreProducto).ToList();
            return View(productos);
        }
    }
}