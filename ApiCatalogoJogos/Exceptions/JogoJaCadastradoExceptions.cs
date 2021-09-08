using System;

namespace ApiCatalogoJogos.Exceptions
{
    //Classe para tratamente de erro
    public class JogoJaCadastradoExceptions : Exception
    {
        public JogoJaCadastradoExceptions() : base ("Jogador já cadastrado!"){
            
        }
    }
}