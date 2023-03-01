using ProjetoWeb.Model;
namespace ProjetoWeb;



public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.UseStaticFiles();
        app.MapGet("/", () => "Hello World!");//Mapear Rotas do back-end para ser apresentado os valores no front-end
        app.MapGet("/produtos", (HttpContext pag) =>

        {
            pag.Response.Redirect("produtos.html", false);
        }
        );
        Pessoa Pessoa1 = new Pessoa(); //Instanciando a classe Pessoa
        Pessoa1.Nome = "Matheus"; // Atribuindo valores a variavel
        Pessoa1.Id = 1;// Atribuindo valores a variavel

        //app.MapGet("/fornecedores", () => $"O fornecedor {Pessoa1.Id} é : {Pessoa1.Nome}");

        app.MapGet("/fornecedores", (HttpContext contexto) =>
        {
            string pagina ="<h1>Fonecedores</h1>";
            pagina = pagina + $"<h2>ID : {Pessoa1.Id}, Nome : {Pessoa1.Nome}</h2>";
            contexto.Response.WriteAsync(pagina); //Imprimindo HTML Do back pro front end
        }
        );

        app.MapGet("/FornecedoresEnviarDados", (int Id, string Nome) =>
        {
            Pessoa1.Id = Id;
            Pessoa1.Nome = Nome;

            return "Dados Inseridos com Sucesso!"; //Envia os dados pro back-end e envia uma mensagem pro front retornando OK.
        }
        );

        app.MapGet("/api", (Func<object>) ( () =>  // Nesse ponto o argumento Func<object> explica que é um objeto JSON
        {
            return new {
            Pessoa1.Id,
            Pessoa1.Nome
            };
        }
        ));
        Banco dba = new Banco();
       
        app.MapGet("/banco", () => 
        
        {
            return dba.mensagem;
        }
        
        );
         dba.CarregarBanco();
        app.Run();
    }
}
