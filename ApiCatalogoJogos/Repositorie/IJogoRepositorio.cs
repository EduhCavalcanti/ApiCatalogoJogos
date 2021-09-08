using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCatalogoJogos.Entities;

namespace ApiCatalogoJogos.Repositorie
{
    public interface IJogoRepositorio
    {
        //lista de jogo 
         Task<List<Jogos>> Obter(int pagina, int quantidade);
        //Retornar um jogo por id
         Task<Jogos> ObterPorId(Guid id); 
        //Obter por nome do jogo e produtora
         Task<List<Jogos>> Obter( string nome, string produtora);
         //Inserir um novo jogo
         Task Inserir (Jogos obj);
         //Atualizar jogo
         Task Atualizar (Jogos obj);
         //Deletar jogo
         Task Remover (Guid id);
    }
}