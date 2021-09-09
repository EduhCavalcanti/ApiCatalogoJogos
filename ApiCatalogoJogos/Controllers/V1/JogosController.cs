using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoJogos.ViewModel;
using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Service;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _IjogoService;

        public JogosController(IJogoService ijogoService)
        {
            _IjogoService = ijogoService;
        }

        /// <summary>
        /// Buscar todos os jogos de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar os jogos sem paginação
        /// </remarks>
        /// <param name="pagina">Indica qual página está sendo consultada. Mínimo 1</param>
        /// <param name="quantidade">Indica a quantidade de reistros por página. Mínimo 1 e máximo 50</param>
        /// <response code="200">Retorna a lista de jogos</response>
        /// <response code="204">Caso não haja jogos</response>   
        //Método GET, para obter a lista de jogos
        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1,  [FromQuery, Range (1,50)] int quantidade = 5)//Quantidade de pagina vai ser de 1 até quanto der, quantidade vai ser de 1 até 50 listas de jogos
        {
            //Vai obter todas a listas de jogos
            var jogos = await _IjogoService.Obter(pagina, quantidade);

            //Se não tiver nenhuma lista vai retornar NoContent
            if(jogos.Count() == 0)
            {
                return NoContent();
            }
            return Ok(jogos);
        }

        /// <summary>
        /// Buscar um jogo pelo seu Id
        /// </summary>
        /// <param name="id">Id do jogo buscado</param>
        /// <response code="200">Retorna o jogo filtrado</response>
        /// <response code="204">Caso não haja jogo com este id</response>   
        //Método GET, vai obter um item a partir do ID passado na rota
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<JogoViewModel>> ObterPorId([FromRoute] Guid id)
        {
            //Vai retornar um jogo pelo id passado
            var IdJogo = await _IjogoService.ObterPoId(id);
            //Se não tiver nada vai retornar um null
            if(IdJogo == null)
            {
                return NoContent();
            }
            return Ok(IdJogo);
        }

        /// <summary>
        /// Inserir um jogo no catálogo
        /// </summary>
        /// <param name="jogo">Dados do jogo a ser inserido</param>
        /// <response code="200">Cao o jogo seja inserido com sucesso</response>
        /// <response code="422">Caso já exista um jogo com mesmo nome para a mesma produtora</response> 
        //Método para criação
        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> CriarJogo([FromBody] JogoInputModel jogo) //Vai retornar o id do jogo criado
        {
            try { 
                //Vai tentar inserir um jogo novo e vai retornar o id do jogo criado
                var jogoId = await _IjogoService.Inserir(jogo);
                //Vai retornar o id do jogo criado
                return Ok(jogoId);

            }catch(Exception e)
            {
                return UnprocessableEntity();
            }
        }

        /// <summary>
        /// Atualizar um jogo no catálogo
        /// </summary>
        /// /// <param name="id">Id do jogo a ser atualizado</param>
        /// <param name="jogo">Novos dados para atualizar o jogo indicado</param>
        /// <response code="200">Cao o jogo seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>   
        //Método para atualizar o jogo
        [HttpPut ("{id:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid id, [FromBody] JogoInputModel jogo)
        {
            await _IjogoService.Atualizar(id, jogo);
            return Ok();
        }

        /// <summary>
        /// Atualizar o preço de um jogo
        /// </summary>
        /// /// <param name="id">Id do jogo a ser atualizado</param>
        /// <param name="preco">Novo preço do jogo</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>
        //Método para atualizar um campo especifico do jogo
        [HttpPatch ("{id:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarPreco( [FromRoute] Guid id, [FromRoute] double preco)
        {
            try { 
                await _IjogoService.Atualizar(id, preco);
                return Ok();
            }catch(Exception e)
            {
                return NotFound("não existe esse jogo");
            }
        }

        /// <summary>
        /// Excluir um jogo
        /// </summary>
        /// /// <param name="id">Id do jogo a ser excluído</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>   
        //Método para deletar o jogo
        [HttpDelete ("{id:guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute] Guid id)
        {
            try { 
                await _IjogoService.Deletar(id);
                return Ok();
            }catch(Exception e)
            {
                return NotFound("jogo não encontrado!");
            }
        }
    }
}
