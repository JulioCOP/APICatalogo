using APICatalogo.Context;
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

    }
}
