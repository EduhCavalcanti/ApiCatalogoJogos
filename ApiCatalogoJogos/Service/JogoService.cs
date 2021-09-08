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

        public Task<List<JogoViewModel>> Obter(int pagina, int quantidade){

            
        }

        public Task<JogoViewModel> ObterPorId(Guid id){

        }

        public Task<JogoViewModel> Inserir(JogoInputModel obj){

        }

        public Task Atualizar(Guid id, JogoInputModel obj){

        }

        public Task Atualizar(Guid id, double preco){

        }

        public Task Deletar(Guid id){

        }

    }


}