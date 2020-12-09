using API_boletim.Context;
using API_boletim.Domains;
using API_boletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_boletim.Repositories
{
    public class AlunoRepository : IAluno
    {

        // chamando a classe de conexão do banco
        BoletimContext conexao = new BoletimContext();

        // chamando o objeto que podera receber e executar os comando do banco
        SqlCommand cmd = new SqlCommand();
        
        public Aluno Alterar(int id, Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPTADE Aluno SET " +
                "Nome = @nome" +
                "RA = @ra" +
                "Idade = @idade WHERE idAluno = @id";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public Aluno BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Aluno a = new Aluno();

            while (dados.Read())
            {
                {
                    a.idAluno = Convert.ToInt32(dados.GetValue(0));
                    a.Nome = dados.GetValue(1).ToString();
                    a.RA = dados.GetValue(2).ToString();
                    a.Idade = Convert.ToInt32(dados.GetValue(3));
                }
            }

            conexao.Desconectar();

            return a;
        }

        public Aluno Cadastrar(Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Aluno (Nome, Ra, Idade)" +
                "VALUES" +
                "(@nome, @ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Aluno WHERE idAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Aluno> LerTodos()
        {
            // abrir conexão
            cmd.Connection = conexao.Conectar();

            //preparar a query (consulta)
            cmd.CommandText = "SELECT * FROM Aluno";

            SqlDataReader dados = cmd.ExecuteReader();

            //criamos a lista pra guardar os alunos
            List<Aluno> alunos = new List<Aluno>();

            while (dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        idAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Convert.ToInt32(dados.GetValue(3))
                    }
                );
            }

            //fechar conexão
            conexao.Desconectar();

            return alunos;
        }
    }
}
