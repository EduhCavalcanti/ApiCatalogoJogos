using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositorie
{
    public class JogoRepositorio : IJogoRepositorio
    {
        
        public Task<List<Jogo>> Obter(int pagina , int quantidade){

        }

        public Task<Jogo> ObterPorId(Guid id){

        }

        public Task<List<Jogo>> Obter(string nome, string produtora){

        }

        public Task Inserir(Jogo obj){

        }

        public Task Atualizar(Guid id){

        }

        public Task Remover(Guid id){

        }
        

    }
}