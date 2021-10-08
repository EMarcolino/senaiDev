using senai_InLock_webAPI.Domains;
using senai_InLock_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Repositories
{
  
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=MARC-NOTE; initial catalog=InLock_Games;; user Id=sa; pwd=marcsql";

        // Cria uma lista onde serão armazenados os dados de Estudios com Jogos
        public List<EstudioDomain> ListarEstudiosJogos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAllEstudio = "SELECT idEstudio, nomeEstudio FROM Estudio";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdrEstudio;

                using (SqlCommand cmd = new SqlCommand(querySelectAllEstudio, con))
                {
                    rdrEstudio = cmd.ExecuteReader();

                    while (rdrEstudio.Read())
                    {
                        List<JogoDomain> listaJogos = new List<JogoDomain>();

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdrEstudio[0]),
                            nomeEstudio = rdrEstudio[1].ToString(),
                        };

                        using (SqlConnection conJogos = new SqlConnection(stringConexao))
                        {
                            string querySelectAllJogos = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor FROM jogo WHERE idEstudio = @idEstudio";

                            conJogos.Open();

                            SqlDataReader readerGames;

                            using (SqlCommand cmdGames = new SqlCommand(querySelectAllJogos, conJogos))
                            {
                                cmdGames.Parameters.AddWithValue("@idEstudio", estudio.idEstudio);

                                readerGames = cmdGames.ExecuteReader();

                                while (readerGames.Read())
                                {
                                    JogoDomain jogo = new JogoDomain()
                                    {
                                        idJogo = Convert.ToInt32(readerGames[0]),

                                        nomeJogo = readerGames[1].ToString(),

                                        descricao = readerGames[2].ToString(),

                                        dataLancamento = Convert.ToDateTime(readerGames[3]),

                                        valorJogo = Convert.ToDecimal(readerGames[4])
                                    };

                                    listaJogos.Add(jogo);
                                }
                            }
                            estudio.listaJogos = listaJogos;

                            listaEstudio.Add(estudio);
                        }

                    }
                }
                return listaEstudio;
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT nomeEstudio FROM Estudio";
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            nomeEstudio = rdr[0].ToString()
                        };

                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }
    }
}
