using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositorie
{
    public class JogoRepositorio : IJogoRepositorio
    {
        

        Task<List<Jogos>> IJogoRepositorio.Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        Task<Jogos> IJogoRepositorio.ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<Jogos>> IJogoRepositorio.Obter(string nome, string produtora)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Jogos obj)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Jogos obj)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}