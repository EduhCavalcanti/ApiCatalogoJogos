using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Service
{
    public interface IJogoService
    {
        //Vai listar o jogos passando numero de página e quantidade de item que vai ser exibido nessa página
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);

        //Vai pegar obter pelo id passado 
        Task<JogoViewModel> ObterPoId(Guid id);

        //Vai inserir um novo jogo
        Task<JogoViewModel> Inserir(JogoInputModel jogo);

        //Atualizar 
        Task Atualizar(Guid id, JogoInputModel jogo);

        //Atualizar especifico 
        Task Atualizar(Guid id, double preco);

        //Deletar 
        Task Deletar(Guid id);

        
    }
}
