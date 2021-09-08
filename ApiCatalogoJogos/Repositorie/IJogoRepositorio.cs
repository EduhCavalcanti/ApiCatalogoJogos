using ApiCatalogoJogos.Entities;

namespace ApiCatalogoJogos.Repositorie
{
    public interface IJogoRepositorio
    {
        //lista de jogo 
         Task<List<Jogo>> Obter(int pagina, int quantidade);
        //Retornar um jogo por id
         Task<Jogo> ObterPorId(Guid id); 
        //Obter por nome do jogo e produtora
         Task<List<Jogo>> Obter( string nome, string produtora);
         //Inserir um novo jogo
         Task Inserir (Jogo obj);
         //Atualizar jogo
         Task Atualizar (Jogo obj);
         //Deletar jogo
         Task Remover (Guid id);
    }
}