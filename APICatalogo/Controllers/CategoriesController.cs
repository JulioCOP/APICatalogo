using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context; // injeção de dependência

        public CategoriesController(AppDbContext context) // solicitando uma instância
        {
            _context = context;
        }
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("products")] // metodo para retornar uma lista de categorias relacionados com os produtos
        public ActionResult<IEnumerable<Category>> GetCategoriesProducts()
        {
            return _context.Categories.Include(p=> p.Products).ToList();
        }

        //Definir o retorno de uma categoria a partir do seu ID

        [HttpGet("{id:int}", Name ="ObterCategoria")]
        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(p=>p.CategoryID == id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada, reveja o valor informado!");
            }
            return Ok(category);        
        }
        //criar um categoria
        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {
            if(category == null)
            {
                return BadRequest();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategorua", new {id=category.CategoryID}, category);
        }
        [HttpPut("{id=int}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }
            _context.Entry(category).State=EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.First(p=>p.CategoryID == id);
            if(category == null)
            {
                return NotFound("Categoria não encontrada, verifique o valor de categoria informado!");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }
    }
}
