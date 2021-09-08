using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        //Obrigatorio,com no maximo 50 letras e minimo 3
        [Required]
        [StringLength(50, MinimumLength =3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50, MinimumLength =3)]
        public string  Produtora { get; set; }
    
        //Obrigatorio,com valor mínimo 1 e no máximo 1000
        [Required]
        [Range(1,100)]
        public double preco { get; set; }
    }
}
