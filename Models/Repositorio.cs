using FloriculturaBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    public class Repositorio
    {
        FloriculturaContext context = new FloriculturaContext();
        public Usuario GetByUsernameAndPassword(Usuario usuario)
        {
            return context.Usuarios.Where(u => u.UsuarioLogin == usuario.UsuarioLogin & u.UsuarioSenha == usuario.UsuarioSenha).FirstOrDefault();
        }
    }
}