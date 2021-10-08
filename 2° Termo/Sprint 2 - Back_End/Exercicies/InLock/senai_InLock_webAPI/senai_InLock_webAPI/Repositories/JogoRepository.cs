using senai_InLock_webAPI.Domains;
using senai_InLock_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=MARC-NOTE; initial catalog=InLock_Games;; user Id=sa; pwd=marcsql";

        public void AtualizarUrl(int idJogo, JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = @"UPDATE Jogo SET idEstudio = @novoIdEstudio, nomeJogo = @novoNomeJogo, descricao = @novaDescricao, dataLancamento = @novaDataLancamento, valor = @novoValor 
                                          WHERE idJogo = @idJogoAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idjogoAtualizado", idJogo);

                    cmd.Parameters.AddWithValue("@novoIdEstudio", jogoAtualizado.idEstudio);

                    cmd.Parameters.AddWithValue("@novoNomeJogo", jogoAtualizado.nomeJogo);

                    cmd.Parameters.AddWithValue("@novaDescricao", jogoAtualizado.descricao);

                    cmd.Parameters.AddWithValue("@novaDataLancamento", jogoAtualizado.dataLancamento);

                    cmd.Parameters.AddWithValue("@novoValor", jogoAtualizado.valorJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectId = @"SELECT nomeEstudio ,nomeJogo, descricao, dataLancamento, valorJogo 
                                         FROM Jogo LEFT JOIN Estudio ON Estudio.idEstudio = Jogo.idEstudio 
                                         WHERE idJogo = @idJogoBuscado";

                SqlDataReader rdrJogo;

                using (SqlCommand cmd = new SqlCommand(querySelectId, con))
                {
                    cmd.Parameters.AddWithValue("@idJogoBuscado", idJogo);

                    con.Open();
                    rdrJogo = cmd.ExecuteReader();


                    while (rdrJogo.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain()
                        {
                            estudio = new EstudioDomain() {
                                idEstudio = Convert.ToInt32(rdrJogo[0]),
                                nomeEstudio = rdrJogo[1].ToString()
                            },

                            nomeJogo = rdrJogo[2].ToString(),

                            descricao = rdrJogo[3].ToString(),

                            dataLancamento = Convert.ToDateTime(rdrJogo[4]),

                            valorJogo = Convert.ToDecimal(rdrJogo[5])
                        };
                        return jogoBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = @"INSERT INTO Jogo (idEstudio, nomeJogo, descricao, dataLancamento, valor) 
                                       VALUES (@idEstudio, @nomeJogo, @descricao, @dataLancamento, @valor)";
                
                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @nomeJogo
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);

                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);

                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);

                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);

                    cmd.Parameters.AddWithValue("@valor", novoJogo.valorJogo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM JOGOS WHERE idJogo = @idJogo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

            public List<JogoDomain> ListarTodos()
        {
                // Cria uma lista listaJogos onde serão armazenados os dados
                List<JogoDomain> listaJogos = new List<JogoDomain>();

                // Declara a SqlConnection con passando a string de conexão como parâmetro
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    // Declara a instrução a ser executada
                    string querySelectAll = "SELECT J.idJogo, nomeJogo, descricao, dataLancamento, valor, J.idEstudio, E.nomeEstudio FROM jogo J " +
                                            "INNER JOIN estudio E " +
                                            "ON J.idEstudio = E.idEstudio";

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                    SqlDataReader rdr;

                    // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {
                        // Executa a query e armazena os dados no rdr
                        rdr = cmd.ExecuteReader();

                        // Enquanto houver registros para serem lidos no rdr, o laço se repete
                        while (rdr.Read())
                        {
                            // Instacia um objeto jogo do tipo Jogo
                            JogoDomain jogo = new JogoDomain()
                            {
                                // Atribui às propriedades os valores das respectivas colunas da tabela do banco de dados
                                idJogo = Convert.ToInt32(rdr[0]),

                                nomeJogo = rdr[1].ToString(),

                                descricao = rdr[2].ToString(),

                                dataLancamento = Convert.ToDateTime(rdr[3]),

                                valorJogo = Convert.ToDecimal(rdr[4]),

                                idEstudio = Convert.ToInt32(rdr[5]),

                                estudio = new EstudioDomain()
                                {
                                    nomeEstudio = rdr[6].ToString()
                                }
                            };

                            // Adiciona o objeto jogo à lista listaJogos
                            listaJogos.Add(jogo);
                        }
                    }
                }

                // Retorna a lista de jogos
                return listaJogos;                       
        }
    }
}
