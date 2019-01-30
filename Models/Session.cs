using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace FloriculturaBeta.Models
{
    public class Session
    {
        public void SetAuthenticationToken(string name, bool isPersistant, Usuario userData)
        {
            string data = null;
            if (userData != null)
                data = new JavaScriptSerializer().Serialize(userData);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddYears(1), isPersistant, userData.UsuarioId.ToString());

            string cookieData = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
            {
                HttpOnly = true,
                Expires = ticket.Expiration
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public Usuario GetUserData()
        {
            Usuario userData = null;

            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                    userData = new JavaScriptSerializer().Deserialize(ticket.UserData, typeof(Usuario)) as Usuario;
                }
            }
            catch (Exception ex)
            {
            }

            return userData;
        }
    }
}