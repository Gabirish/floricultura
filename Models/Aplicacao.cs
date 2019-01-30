using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    public class Aplicacao
    {
        Repositorio repo = new Repositorio();
        public Usuario GetByUsernameAndPassword(Usuario usuario)
        {
            return repo.GetByUsernameAndPassword(usuario);
        }
    }
}