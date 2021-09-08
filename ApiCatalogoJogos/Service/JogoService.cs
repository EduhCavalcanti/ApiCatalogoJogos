using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoJogos.Entities;
using ApiCatalogoJogos.ViewModel;
using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Repositorie;


namespace ApiCatalogoJogos.Service
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepositorio _IJogoRepositorio;

        //Construtor para injeção de dependência 
        public JogoService (IJogoRepositorio IjogoRepositorio){
            _IJogoRepositorio = IjogoRepositorio;
        }

        public Task Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, double preco)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModel> ObterPoId(Guid id)
        {
            throw new NotImplementedException();
        }
    }


}