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
    /// Classe responsável pelo Repositório de cliente
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        /// <summary>
        /// String de conexao com banco de dados que recebe os parâmetros:
        /// Data Source= Nome do Servidor; initial catalog= Nome do banco de dados; 
        /// user Id=sa que é o nome do usuário; pwd=Senha; Faz autenticação como o SqlServer passando Login e Senha. 
        /// integrated security=true; Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>

        string stringConexao = "Data Source=MARC-NOTE; initial catalog=Locadora; user Id=sa; pwd=marcsql";
        //string stringConexao = "Data Source=MARC-NOTE; initial catalog=Locadora; integrated security=true";


        public void AtualizarIdCorpo(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.idCliente != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Cliente SET nomeCliente, sobrenomeCliente, cpfCliente = @idCliente, @nomeCliente, @sobrenomeCliente, @cpfCliente = @idClienteAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", clienteAtualizado.idCliente);

                        cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);

                        cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);

                        cmd.Parameters.AddWithValue("@cpfCliente", clienteAtualizado.cpfCliente);
                    }
                }
            }                       
        }


        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao)) 
            {
                string queryUpdateUrl = "UPDATE Cliente SET nomeCliente, sobrenomeCliente, cpfCliente = @novoNomeCliente, @novoSobrenomeCliente @novoCpfCliente WHERE idCliente = @idAtualizado";

                using (SqlCommand command = new SqlCommand(queryUpdateUrl, con)) 
                {
                    command.Parameters.AddWithValue("@idAtualizado", idCliente);

                    command.Parameters.AddWithValue("@novoNomeCliente", clienteAtualizado.nomeCliente);

                    command.Parameters.AddWithValue("@novoSobrenomeCliente", clienteAtualizado.sobrenomeCliente);

                    command.Parameters.AddWithValue("@novoCpfCliente", clienteAtualizado.cpfCliente);

                    con.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public ClienteDomain BuscarPorId(int idCliente)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, sobrenomeCliente, cpfCliente FROM Cliente WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),

                            nomeCliente = reader["nomeCliente"].ToString(),

                            sobrenomeCliente = reader["sobrenomeCliente"].ToString(),

                            cpfCliente = (int)Convert.ToInt64(reader["cpfCliente"])

                        };

                        return clienteBuscado;
                    }
                    return null;
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoCliente"></param>
        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Cliente (nomeCliente, sobrenomeCliente, cpfCliente) VALUES(@nome, @sobrenome, @cpfCliente)";

                //Abre a conexão com o banco de dados
                con.Open(); 

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nome", novoCliente.nomeCliente);

                    cmd.Parameters.AddWithValue("@sobrenome", novoCliente.sobrenomeCliente);

                    cmd.Parameters.AddWithValue("@cpfCliente", novoCliente.cpfCliente);
                    
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
                string queryDelete = "DELETE FROM Cliente WHERE idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryDelete))
                {
                    cmd.Parameters.AddWithValue("@idCliente", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }

        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        /// <returns>Uma lista de cliente</returns>
        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listarCliente = new List<ClienteDomain>();

            //Declara a SqlConnection com o nome de "con", passando a string de conexão como parâmetro 
            using (SqlConnection con = new SqlConnection(stringConexao)) 
            {

                string querySelectAll = "SELECT idCliente, nomeCliente, sobrenomeCliente, cpfCliente FROM Cliente";

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

                    //Instânciando um objeto (cliente) do tipo ClienteDomain
                    ClienteDomain cliente = new ClienteDomain()
                    {
                        //Atribui a propriedade idCliente o valor da primeira coluna do banco de dados
                        idCliente = Convert.ToInt32(rdr[0]),

                        //Atribui a propriedade nomeCliente o valor da segunda coluna do banco de dados
                        nomeCliente = rdr[1].ToString(),

                        //Atribui a propriedade sobrenomeCliente o valor da terceira coluna do banco de dados
                        sobrenomeCliente = rdr[2].ToString(),

                        //Atribui a propriedade cpfCliente o valor da quarta coluna do banco de dados
                        cpfCliente = (int)Convert.ToInt64(rdr[3])

                    };

                    //Adciona o objeto genero criando a lista de veiculos
                    listarCliente.Add(cliente);
                }
            };

            return listarCliente;
        }
    }
}
