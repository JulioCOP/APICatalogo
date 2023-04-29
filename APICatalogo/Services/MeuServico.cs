
// Classe MeuServico implementa a interface IMeuServico

namespace APICatalogo.Services
{
    public class MeuServico : IMeuServico 
    {
        // Definir o serviço
        public string Saudacao(string nome)
        {
            return $"Seja bem vindo, {nome}! \n\n{DateTime.Now}";
        }
        //implementar o serviço na classe Program ou Startup
    }
}
