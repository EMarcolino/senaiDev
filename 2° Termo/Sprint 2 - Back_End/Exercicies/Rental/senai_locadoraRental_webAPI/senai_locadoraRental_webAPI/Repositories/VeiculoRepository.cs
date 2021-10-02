using senai_locadoraRental_webAPI.Domains;
using senai_locadoraRental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_locadoraRental_webAPI.Repositories
{
    /// <summary>
    /// Classe responsável pelo Repositório de Veículos
    /// </summary>
    public class VeiculoRepository : IVeiculoRepository
    {
        /// <summary>
        /// String de conexao com banco de dados que recebe os parâmetros:
        /// Data Source= Nome do Servidor; initial catalog= Nome do banco de dados; 
        /// user Id=sa que é o nome do usuário; pwd=Senha; Faz autenticação como o SqlServer passando Login e Senha. 
        /// integrated security=true; Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>

        private string stringConexao = "Data Source=MARC-NOTE; initial catalog=Locadora; user Id=sa; pwd=marcsql";
        //string stringConexao = "Data Source=MARC-NOTE; initial catalog=Locadora; integrated security=true";

        public void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.idVeiculo != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Veiculo SET idModelo = @idModelo = @idVeiculoAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idVeiculo", veiculoAtualizado.idVeiculo);

                        cmd.Parameters.AddWithValue("@idVeiculo", veiculoAtualizado.idModelo);
                    } 
                }
            }
        }

        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Veiculo SET @idModelo WHERE idVeiculo = @idAtualizado";

                using (SqlCommand command = new SqlCommand(queryUpdateUrl, con))
                {                    
                    command.Parameters.AddWithValue("@idAtualizado", idVeiculo);

                    command.Parameters.AddWithValue("@idModelo", veiculo.idModelo);

                    con.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <returns></returns>
        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idVeiculo FROM Cliente WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(reader["idCliente"])

                        };

                        return veiculoBuscado;
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoVeiculo"></param>
        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Veiculo (nomeVeiculo) VALUES('" + novoVeiculo.idModelo + "')";


                //Abre a conexão com o banco de dados
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Veiculo WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os veículos
        /// </summary>
        /// <returns>Uma lista de veículos</returns>
        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listarVeiculo = new List<VeiculoDomain>();

            //Declara a SqlConnection com o nome de "con", passando a string de conexão como parâmetro 
            using (SqlConnection con = new SqlConnection(stringConexao)) 
            {
                string querySelectAll = "SELECT * FROM Veiculo";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declarando SqlDataReader rdr que irá percorrer a tabela do banco de dados para trazer o que será lido e armazenar no rdr
                SqlDataReader rdr;

                //Declara SqlCommand passando a query que será executada e a conexão com o parânmetro 
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))

                //Executa a query e armazena os dados no rdr
                rdr = cmd.ExecuteReader();

                //Enquanto houver registros para serem lidos no rdr, o laço se repete
                while (rdr.Read())
                {
                    //Instânciando um objeto (veiculo) do tipo VeiculoDomain
                    VeiculoDomain veiculo = new VeiculoDomain()
                    {
                        //Atribui a propriedade idVeiculo o valor da primeira coluna do banco de dados
                        idVeiculo = Convert.ToInt32(rdr[0]),

                        //Atribui a propriedade idModelo o valor da segunda coluna do banco de dados
                        idModelo = Convert.ToInt32(rdr[1])

                    };

                    //Adciona o objeto genero criando a lista de veiculos
                    listarVeiculo.Add(veiculo);
                }
            };

            return listarVeiculo;
        }


    }
}
