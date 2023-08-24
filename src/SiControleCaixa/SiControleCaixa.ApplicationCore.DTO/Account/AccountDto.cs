using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.ApplicationCore.DTO.Account
{
    public  class AccountDto
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage ="O campo {0} está no formato inválido")]
        public string Email { get;set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100,ErrorMessage ="O campo precisa ter entre {2} e {1}^caracteres",MinimumLength =8)]
        public string Password { get;set; }
        [Compare("Password", ErrorMessage ="As senhas não conferem")]
        public string confirmPassword { get;set; }
    }

    public class LoginAccountDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está no formato inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo precisa ter entre {2} e {1}^caracteres", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
