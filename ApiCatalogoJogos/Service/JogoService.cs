using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoJogos.Entities;
using ApiCatalogoJogos.ViewModel;
using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Repositorie;
using ApiCatalogoJogos.Exceptions;


namespace ApiCatalogoJogos.Service
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepositorio _IJogoRepositorio;

        //Construtor para injeção de dependência 
        public JogoService (IJogoRepositorio IjogoRepositorio){
            _IJogoRepositorio = IjogoRepositorio;
        }

        public async Task Atualizar(Guid id, JogoInputModel jogo)
        {
            //Vai pegar o jogodor pela id para verificar se ele existe

            var entidadeJogo = await _IJogoRepositorio.ObterPorId(id);

            if(entidadeJogo == null){
                throw new JogadoNaoCadastrado();
            }
            //vai criar um obj com tipo Jogos para atualizar passando os parametros novos 
            var insertJogo = new Jogos{
                Id=entidadeJogo.Id,
                Nome=jogo.Nome,
                Produtora=jogo.Produtora,
                Preco=jogo.preco
            };

            await _IJogoRepositorio.Atualizar(insertJogo);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            //Vai pegar o jogodor pela id para verificar se ele existe
            var jogoId = await _IJogoRepositorio.ObterPorId(id);

            if(jogoId == null){
                throw new JogadoNaoCadastrado();
            }

            //Vao criar um obj do tipo Jogos passando o preco atualizado que vem do parametro
            var insertJogo = new Jogos{
                Id=jogoId.Id,
                Nome=jogoId.Nome,
                Produtora=jogoId.Produtora,
                Preco = preco
            };
            //Vai passar o obj atualizado
            await _IJogoRepositorio.Atualizar(insertJogo);
        }

        public async Task Deletar(Guid id)
        {
            //Vai pegar o id passado
            var jogo = await _IJogoRepositorio.ObterPorId(id);

            //vai verificar se o jogo está cadastrado
            if(jogo == null){
                throw new JogadoNaoCadastrado();
            }
            //Se tiver vai exlcuir
            await _IJogoRepositorio.Remover(id);
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            //Vai buscar no banco de dados uma lista de jogos com nome e produto
            var entidadeJogo = await _IJogoRepositorio.Obter(jogo.Nome, jogo.Produtora);

            //Vai verificar se tem na lista algum jogo cadastrado
            if(entidadeJogo.Count > 0){
                throw new JogoJaCadastradoExceptions();
            }

            //Vai pegar os dados recebido do JogoInputView para converter para tipo jogos para adicionar no banco
            var insertJogo = new Jogos{
                Id= Guid.NewGuid(),
                Nome=jogo.Nome,
                Produtora=jogo.Produtora,
                Preco=jogo.preco
                
            };
            //Vai adicionar novo jogo no banco 
            await _IJogoRepositorio.Inserir(insertJogo);

            //Vai retornar jogador cadastrado do tipo JogoViewModel
            return new JogoViewModel{
                Id=insertJogo.Id,
                Nome=insertJogo.Nome,
                Produtora=insertJogo.Produtora,
                Preco=insertJogo.Preco
            };
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _IJogoRepositorio.Obter(pagina, quantidade);

            //Vai pegar do repositorio (Banco de dados) a lista de jogos e depois vai criar o JogoViewModel para ser retornado 
            return jogos.Select(jogos => new JogoViewModel {
                Id=jogos.Id,
                Nome=jogos.Nome,
                Produtora=jogos.Produtora,
                Preco=jogos.Preco
            }).ToList(); //Vai retornar em lista

        }

        public async Task<JogoViewModel> ObterPoId(Guid id)
        {
            //Vai retornar um jogo pelo id passado
            var jogoId = await _IJogoRepositorio.ObterPorId(id);

            //Verifica se é null
            if(jogoId == null){
                return null;
            }

            //Retorna para JogoViewModel passando os dados recebido do jogoId
            return new JogoViewModel{
                Id=jogoId.Id,
                Nome=jogoId.Nome,
                Produtora=jogoId.Produtora,
                Preco=jogoId.Preco
            };
        }

    }

}