using senai_InLock_webAPI.Domains;
using senai_InLock_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=MARC-NOTE; initial catalog=InLock_Games;; user Id=sa; pwd=marcsql";

        public void AtualizarUrl(int idUsuario, UsuarioDomain usuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE Usuario SET email = @email, senha = @senha, idTipoUsuario = @idTipoUsuario WHERE idUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    cmd.Parameters.AddWithValue("@email", usuarioAtualizado.email);

                    cmd.Parameters.AddWithValue("@senha", usuarioAtualizado.senha);

                    cmd.Parameters.AddWithValue("@idTipoUsuario", usuarioAtualizado.idTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarId(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Usuario WHERE idUsuario = @id";

                con.Open();

                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),

                            email = rdr["email"].ToString(),

                            senha = rdr["senha"].ToString(),

                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = @"INSERT INTO Usuario(email, senha, idTipoUsuario) 
                                       VALUES(@email, @senha, @idTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@email", novoUsuario.email);
                    cmd.Parameters.AddWithValue("@senha", novoUsuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.idTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Usuario WHERE idUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listarUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Usuario";

                con.Open();

                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain user = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            senha = rdr[2].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr[3])
                        };

                        listarUsuarios.Add(user);
                    }

                    return listarUsuarios;
                }
            }
        }

        public UsuarioDomain Login(string email, string senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define o comando a ser executado no banco de dados
                string querySelect = @"SELECT idUsuario, email, U.idTipoUsuario, TU.nomeTipo 
                                       FROM usuario U INNER JOIN tipoUsuario TU ON U.idTipoUsuario = TU.idTipoUsuario 
                                       WHERE email = @email AND senha = @senha";

                // Define o comando cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.Parameters.AddWithValue("@senha", senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas do banco de dados
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),

                            email = rdr["email"].ToString(),

                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),

                            tipoUsuario = new TipoUsuarioDomain()
                            {
                                nomeTipo = rdr["nomeTipo"].ToString()
                            }
                        };

                        // Retorna o usuário buscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }
        }
    }
}
