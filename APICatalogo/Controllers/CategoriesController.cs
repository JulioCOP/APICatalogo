using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // injeção de dependÊncia e gerar o contrutor
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategoriesProducts()
        {
            return _context.Categories.Include(p=> p.Products).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryID == id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada!");
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (category is null)

                return BadRequest();
            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", 
                   new { id = category.CategoryID }, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryID == id);
            if (category is null)
            {
                return NotFound("Categoria não encontrada!");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }

    }
}
