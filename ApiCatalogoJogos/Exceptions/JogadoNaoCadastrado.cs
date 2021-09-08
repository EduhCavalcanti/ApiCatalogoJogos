using System;

namespace ApiCatalogoJogos.Exceptions
{
    public class JogadoNaoCadastrado : Exception
    {
        public JogadoNaoCadastrado() : base ("Jogador não cadastrado"){
            
        }
    }
}