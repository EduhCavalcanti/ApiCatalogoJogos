using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ApiCatalogoJogos.Entities;
using Microsoft.Extensions.Configuration;

namespace ApiCatalogoJogos.Repositorie
{
    //Classe para fazer conexão com o banco de dados SQL Server
    public class JogoSqlServerRepositorio : IJogoRepositorio
    {
        private readonly SqlConnection sqlConnection;

        //Constructor conexão com Sql Server
        public JogoSqlServerRepositorio(IConfiguration configuration){
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task Atualizar(Jogos obj)
        {
            var comando = $"update Jogos set Nome = '{obj.Nome}',  Produtora = '{obj.Produtora}', Preco = {obj.Preco.ToString().Replace(",", ".")} where Id='{obj.Id}'";
            //Abri conexão com banco 
            await sqlConnection.OpenAsync();

            SqlCommand command = new SqlCommand(comando, sqlConnection);
            command.ExecuteNonQuery();
            //Fechar conexão
            await sqlConnection.CloseAsync();
        }

        public async Task Inserir(Jogos obj)
        {
            var comando =  $"insert Jogos (Id, Nome, Produtora, Preco) values ('{obj.Id}', '{obj.Nome}', '{obj.Produtora}', {obj.Preco.ToString().Replace(",", ".")})";
        
            await sqlConnection.OpenAsync();
            SqlCommand command = new SqlCommand(comando, sqlConnection);
            command.ExecuteNonQuery();
            await sqlConnection.CloseAsync();

        }

        public async Task<List<Jogos>> Obter(int pagina, int quantidade)
        {
            //Vai crirar lista de jogo 
            var jogo = new List<Jogos>();

            var comando = $"select * from Jogos order by id offset {((pagina - 1) * quantidade )} rows fetch next {quantidade} rows only";

            //Abri conexão com o banco de dados 
            await sqlConnection.OpenAsync();
            
            //Passa o texto da consulta e a conexão com banco 
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            //Recebe os comandos passado
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            //Avança SqlDataRead para próximo registro equanto houver linhas
            while(sqlDataReader.Read())//Read retornar true ou false
            {
                jogo.Add(new Jogos{
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtura"],
                    Preco = (double)sqlDataReader["Preco"]

                });
            }

            //Fechar conexão com banco de dados 
            await  sqlConnection.CloseAsync();

            return jogo;
        }

        public async Task<List<Jogos>> Obter(string nome, string produtora)
        {
            var jogos = new List<Jogos>();

            var comando = $"select * from Jogos where Nome = '{nome}' and Produtora = '{produtora}'";

            await sqlConnection.OpenAsync();
            SqlCommand command = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await command.ExecuteReaderAsync();

            while(sqlDataReader.Read()){
                jogos.Add(new Jogos{
                    Id=(Guid)sqlDataReader["Id"],
                    Nome=(string)sqlDataReader["Nome"],
                    Produtora=(string)sqlDataReader["Produto"],
                    Preco=(double)sqlDataReader["Preco"]
                });

                await sqlConnection.CloseAsync();

                return jogos;
            }

            await sqlConnection.CloseAsync();
            return jogos;
        }

        public async Task<Jogos> ObterPorId(Guid id)
        {
            Jogos jogo = null;

            var comando = $"select * from Jogos where Id='{id}'";

            await sqlConnection.OpenAsync();

            SqlCommand command = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await command.ExecuteReaderAsync();

            while(sqlDataReader.Read()){
                jogo = new Jogos{
                    Id=(Guid)sqlDataReader["Id"],
                    Nome=(string)sqlDataReader["Nome"],
                    Produtora=(string)sqlDataReader["Produtora"],
                    Preco=(double)sqlDataReader["Preco"]
                };

            }
            await sqlConnection.CloseAsync();
            return jogo;
        }

        public async Task Remover(Guid id)
        {
            var comando = $"delete Jogos where Id='{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand command = new SqlCommand(comando, sqlConnection);
            command.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
            
        }
    }
}