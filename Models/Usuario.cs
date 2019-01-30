using FloriculturaBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioLogin { get; set; }
        public string UsuarioSenha { get; set; }
        public int FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}