using System.Data.SqlClient;
namespace ProjetoWeb.Model
{
    public class Banco
    {
        public string mensagem = "Olá, Banco!";

        public void CarregarBanco(){

            try{

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(
                    "User ID=sa;Password=Password"+
                    "Server=localhost\\SQLEXPRESS;"+
                    "Database=projetoclientes;"+
                    "Trusted_Connection=False;"

                );

                using(SqlConnection conexao = new SqlConnection(builder.ConnectionString))
                {
                    string sql =" Select  * FROM clientes";
                    using(SqlCommand comando = new SqlCommand(sql, conexao))
                    {
                        conexao.Open();

                        using(SqlDataReader tabela = comando.ExecuteReader())
                        {
                            while(tabela.Read())
                            {
                                System.Console.WriteLine(tabela["nome"]);
                            }
                        }
                    }
                }

            }catch(Exception e){
                System.Console.WriteLine("Erro :"+e.ToString);
            }
        }
    }
}