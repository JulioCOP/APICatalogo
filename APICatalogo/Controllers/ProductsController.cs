using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")] //Rota da requisição para acessar o controlador, sendo necessário informar apenas a URL "Produtos"
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context; //apenas leitura da calsse db context

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        // criação do método action  que retornam dados, ou seja, métodos que usam  metodo HTTP GET

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Products.ToList();
            if (products is null)
            {
                return NotFound("Produtos não encontrados!"); //Método action é retorna um tipo ActionResult
            }
            return products;
        }
        //metodo Get para retorno dos produtos pelo ID
        //Necessário repassa o ID pelo REQUEST

        [HttpGet("{id:int}")]
        public ActionResult<Product> ProductGet(int id)
        {
            var product = _context.Products.FirstOrDefault(p=>p.ProductId== id);
            if (product == null)
            {
                return NotFound("Produto não encontrado!");
            }
            return product;
        }
    }
}

