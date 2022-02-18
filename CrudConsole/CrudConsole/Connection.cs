using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CrudConsole
{
    class Connection
    {
        static string ConexaoString = "DATA SOURCE=JOAOVITOR; INITIAL CATALOG=PROVA; Trusted_Connection=True";
        
        static SqlConnection conn;

        public SqlConnection conectar()
        {
            conn = new SqlConnection(ConexaoString);

            try
            {
                conn.Open();
                Console.WriteLine("Conexão realizada com sucesso!!!");

            }
            catch (Exception)
            {
                Console.WriteLine("Erro ao conectar no banco");
            }

            return conn;
        }

        public void InserirProduto(int id, string descricao, int estoque, double valor)
        {
            string query = "SELECT * FROM PRODUTO WHERE IDPROD = '" + id + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    Console.WriteLine("Produto com id já existente");
                }
                reader.Close();

                query = "INSERT INTO PRODUTO VALUES (@IDPROD, @DESCRICAO, @ESTOQUE, @VALOR)";
                cmd = new SqlCommand(query, conn);

                try
                {
                    cmd.Parameters.Add(new SqlParameter("@IDPROD", id));
                    cmd.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));
                    cmd.Parameters.Add(new SqlParameter("@ESTOQUE", estoque));
                    cmd.Parameters.Add(new SqlParameter("@VALOR", valor));
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Produto inserido com sucesso");
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro no banco de dados ");
                }
            }
            catch
            {
                
            }
 
        }

        public void AlterarProduto(string descricao, int estoque, double valor, int id)
        {

            string query = "UPDATE PRODUTO SET DESCRICAO = @DESCRICAO,\nESTOQUE = @ESTOQUE,\nVALOR = @VALOR\nWHERE IDPROD = @IDPROD";

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));
                cmd.Parameters.Add(new SqlParameter("@ESTOQUE", estoque));
                cmd.Parameters.Add(new SqlParameter("@VALOR", valor));
                cmd.Parameters.Add(new SqlParameter("@IDPROD", id));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Produto alterado com sucesso!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro no banco de dados " + e);
            }
        }

        public void DeleteProduto(int id)
        {
            string query = "DELETE FROM PRODUTO WHERE IDPROD = '" + id + "'";

            SqlCommand cmd = new SqlCommand(query, conn);

            int ret = cmd.ExecuteNonQuery();

            if (ret == 0)
            {
                Console.WriteLine("Produto não encontrado!");
            }
            else
            {
                Console.WriteLine("Produto excluido com sucesso");
            }
        }

        public Produto PesquisarProduto(int id, Produto produto)
        {
            string query = "SELECT * FROM PRODUTO WHERE IDPROD = '" + id + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    produto.SetIdprod(int.Parse(reader[0].ToString()));
                    produto.SetDescricao(reader[1].ToString());
                    produto.SetEstoque(int.Parse(reader[2].ToString()));
                    produto.SetValor(double.Parse(reader[3].ToString()));
                }
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao pesquisar o produto " + e.Message);
            }
            return produto;
        }

    }
}
