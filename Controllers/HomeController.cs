using FloriculturaBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloriculturaBeta.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Popular()
        {
            FloriculturaContext db = new FloriculturaContext();

            Cliente cliente = new Cliente()
            {
                ClienteNome = "Brunce Wayne",
                ClienteCpf = "333.333.333-33",
                ClienteTelefone = "11 3333-3333",
                ClienteEstado = "SP",
                ClienteCidade = "São Paulo",
                ClienteBairro = "Alto de Pinheiros",
                ClienteRua = "Diogenes Ribeiro de Lima",
                ClienteNumero = "50000",
                ClienteComplemento = "Apto 666",
            };
            db.Clientes.Add(cliente);

            var funcionario = new Funcionario()
            {
                FuncionarioNome = "Raul Pontes",
                FuncionarioCpf = "333.333.333-33"

            };

            db.Funcionarios.Add(funcionario);

            var produtos = new List<Produto>()
            {
                new Produto()
                {
                    ProdutoNome = "Margarida",
                    ProdutoDescricao = "amarela",
                    ProdutoValor = 10,
                    ProdutoEstoque = 25

                },

                new Produto()
                {
                    ProdutoNome = "Rosa",
                    ProdutoDescricao = "Vermelha",
                    ProdutoValor = 25,
                    ProdutoEstoque = 30

                },

                new Produto()
                {
                    ProdutoNome = "Tulipa",
                    ProdutoDescricao = "Branca",
                    ProdutoValor = 5,
                    ProdutoEstoque = 40

                },

                new Produto()
                {
                    ProdutoNome = "Gardenia",
                    ProdutoDescricao = "branca",
                    ProdutoValor = 8,
                    ProdutoEstoque = 40

                },


                new Produto()
                {
                    ProdutoNome = "Violeta",
                    ProdutoDescricao = "Roxa",
                    ProdutoValor = 6,
                    ProdutoEstoque = 40

                },


                new Produto()
                {
                    ProdutoNome = "Copo De Leite",
                    ProdutoDescricao = "Branca",
                    ProdutoValor = 12,
                    ProdutoEstoque = 40

                },


                new Produto()
                {
                    ProdutoNome = "Girassol",
                    ProdutoDescricao = "Branca",
                    ProdutoValor = 16,
                    ProdutoEstoque = 40

                },


                new Produto()
                {
                    ProdutoNome = "Amarílis",
                    ProdutoDescricao = "vermelho e branco",
                    ProdutoValor = 5,
                    ProdutoEstoque = 40

                },

            };

            db.Produtos.AddRange(produtos);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}