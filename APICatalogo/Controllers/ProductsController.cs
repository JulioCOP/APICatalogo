using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")] //Rota da requisição para acessar o controlador, sendo necessário informar apenas a URL "Produtos"
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context; 
        //apenas leitura da classe db context

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        // criação do método action  que retornam dados, ou seja, métodos que usam  metodo HTTP GET

        [HttpGet] // api/produtos/"id"

        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int:min(1)}", Name="ObterProduto")]  // /produtos -> quando acessar a classe produtos o método get em questão será acionado
        public ActionResult<Product> Get([FromQuery]int id) 
                                    // FromQuerry id vem da cadeia de consulta,
                                    // ou seja, já mostra o valor sem precisar informar um nome
        {
            var products = _context.Products.AsNoTracking().FirstOrDefault(p=>p.ProductId == id);
            if (products is null)
            {
                return NotFound("Produto não encontrado!"); 
                //Método action é retorna um tipo ActionResult
            }
            return products;
        }
        //metodo Get para retorno dos produtos pelo ID
        //Necessário repassa o ID pelo REQUEST

 
        //metodo action para criar um novo produto

        [HttpPost] // /produtos
        public ActionResult Post(Product product)
        {
            if(product is null)
            {
                return BadRequest();
            }
            _context.Products.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterPoduto", 
                new { id = product.ProductId }, product);
        }
        //metodo action para atualizar um produto
        [HttpPut]
        public ActionResult Put(int id, Product product)
        {
            if(id != product.ProductId)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product); 
            // ao retornar como método ok, é possível visualizar o produto alterado
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId== id);
            if(product is null)
            {
                return NotFound("Produto não localizado, reveja a ID informada!");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}

