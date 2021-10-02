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
    /// Classe responsável pelo Repositório de Alugueis
    /// </summary>
    public class AluguelRepository : IAluguelRepository
    {
        /// <summary>
        /// String de conexao com banco de dados que recebe os parâmetros:
        /// Data Source= Nome do Servidor; initial catalog= Nome do banco de dados; 
        /// user Id=sa que é o nome do usuário; pwd=Senha; Faz autenticação como o SqlServer passando Login e Senha. 
        /// integrated security=true; Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>

        private string stringConexao = "Data Source=MARC-NOTE; initial catalog=Locadora; user Id=sa; pwd=marcsql";
        //string stringConexao = "Data Source=MARC-NOTE; initial catalog=Locadora; integrated security=true";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="aluguelAtualizado"></param>
        public void AtualizaIdCorpo(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.idAluguel != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Aluguel SET idCliente, idVeiculo = @idCliente, @idVeiculo = @idAluguelAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);

                        cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAluguel"></param>
        /// <param name="aluguelAtualizado"></param>
        public void AtualizaIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Aluguel SET @dataInicio, @dataEntrega WHERE idAluguel = @idAtualizado";

                using (SqlCommand command = new SqlCommand(queryUpdateUrl, con))
                {
                    command.Parameters.AddWithValue("@idAtualizado", idAluguel);

                    command.Parameters.AddWithValue("@dataInicio", aluguelAtualizado.dataInicio);

                    command.Parameters.AddWithValue("@dataEntrega", aluguelAtualizado.dataEntrega);


                    con.Open();

                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAluguel"></param>
        /// <returns></returns>
        public AluguelDomain BuscarporId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel FROM Aluguel WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain AluguelBuscado = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"])
                                                        
                        };

                        return AluguelBuscado;
                    }
                    return null;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoAluguel"></param>
        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Aluguel (nomeAluguel) VALUES('" + novoAluguel.idCliente + "')";

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
                string queryDelete = "DELETE FROM Aluguel WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Lista todos os alugueis
        /// </summary>
        /// <returns>Uma lista de Alugueis</returns>
        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listarAluguel = new List<AluguelDomain>();

            //Declara a SqlConnection com o nome de "con", passando a string de conexão como parâmetro 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "SELECT idAluguel, idCliente, idVeiculo, dataInicio, dataEntrega FROM Aluguel";

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
                    AluguelDomain aluguel = new AluguelDomain()
                    {
                        //Atribui a propriedade idAluguel o valor da primeira coluna do banco de dados
                        idAluguel = Convert.ToInt32(rdr[0]),

                        //Atribui a propriedade idCliente o valor da segunda coluna do banco de dados
                        idCliente = Convert.ToInt32(rdr[1]),

                        //Atribui a propriedade idVeiculo o valor da terceira coluna do banco de dados
                        idVeiculo = Convert.ToInt32(rdr[2]),

                        //Atribui a propriedade dataInicio o valor da quarta coluna do banco de dados
                        dataInicio = Convert.ToDateTime(rdr[3]),

                        //Atribui a propriedade dataEntrega o valor da quinta coluna do banco de dados
                        dataEntrega = Convert.ToDateTime(rdr[4])                                              

                    };

                    //Adciona o objeto genero criando a lista de veiculos
                    listarAluguel.Add(aluguel);
                }
            };

            return listarAluguel;
        }


    }
}
