using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FloriculturaBeta.Models;

namespace FloriculturaBeta.Controllers
{
    [Authorize]
    public class VendasController : Controller
    {
        private FloriculturaContext db = new FloriculturaContext();

        // GET: Vendas
        public ActionResult Index()
        {
            var vendas = db.Vendas.Include(v => v.Cliente).Include(v => v.Funcionario);
            return View(vendas.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            venda.ItensVenda = (from itemVendas in db.ItensVenda
                                where itemVendas.ItemVendaId == venda.VendaId
                                select itemVendas).ToList();
            return View(venda);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            string idUsuario;
            if (Session["idUsuario"] != null)
            {
                idUsuario = Session["idUsuario"] as string;
            }
            else
            {
                return RedirectToAction("Logout", "Login");
            }

            var funcionario = (from f in db.Funcionarios
                               join u in db.Usuarios on f.FuncionarioId equals u.FuncionarioId
                               where u.UsuarioLogin == idUsuario
                               select f);

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ClienteNome");
            //ViewBag.FuncionarioId = db.Funcionarios.Where(f => f.FuncionarioId == id);
            //ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "FuncionarioNome");
            ViewBag.FuncionarioId = new SelectList(funcionario, "FuncionarioId", "FuncionarioNome");
            var produtos = new Venda();
            produtos.Produtos = db.Produtos.OrderBy(x => x.ProdutoNome).ToList();

            return View(produtos);
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public ActionResult Create(Cliente cliente, Funcionario funcionario, List<Produto> lista)
        //{
        //    return View();
        //}
        public ActionResult Create(Venda venda)
        {
            if (ModelState.IsValid && venda.verificaQuantidade())
            {
                venda.VendaData = DateTime.Now;
                db.Vendas.Add(venda);
                db.SaveChanges();

                var itensVendidos = new List<ItemVenda>();

                for (int i = 0; i < venda.Produtos.Count; i++)
                {
                    venda.Produtos[i].QuantidadeVenda = venda.Produtos[i].QuantidadeVenda;
                    if (venda.Produtos[i].QuantidadeVenda > 0)
                    {
                        var produtoReferencia = venda.Produtos[i];
                        var produto = db.Produtos.SingleOrDefault(p => p.ProdutoId == produtoReferencia.ProdutoId);
                        if (produto != null)
                        {
                            produto.ProdutoEstoque -= venda.Produtos[i].QuantidadeVenda;
                            db.SaveChanges();
                        }
                        itensVendidos.Add(new ItemVenda()
                        {
                            ItemVendaQuantidade = venda.Produtos[i].QuantidadeVenda,
                            VendaId = venda.VendaId,
                            ProdutoId = venda.Produtos[i].ProdutoId,

                        });
                    }
                }

                if (itensVendidos.Count > 0)
                {
                    db.ItensVenda.AddRange(itensVendidos);
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }

            ViewBag.erro = "Quantidade de itens vendidos não pode ser superior a quantidade disponivel no estoque";
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ClienteNome", venda.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "FuncionarioNome", venda.FuncionarioId);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ClienteNome", venda.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "FuncionarioNome", venda.FuncionarioId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendaId,FuncionarioId,ClienteId")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "ClienteNome", venda.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "FuncionarioNome", venda.FuncionarioId);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Vendas.Find(id);
            db.Vendas.Remove(venda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
