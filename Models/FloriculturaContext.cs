using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    //Classe para conexão com o banco de dados pelo Entity Framework. Para utilizar, basta instanciar a classe
    public class FloriculturaContext : DbContext
    {
        public FloriculturaContext() : base("Floricultura")
        {
            //Ao iniciar o aplicativo, ele verificará se o banco de dados existe. Se não exister, irá criar um novo
            Database.SetInitializer<FloriculturaContext>(new CreateDatabaseIfNotExists<FloriculturaContext>());

            //Caso um dos modelos de classe tenham sofrido alterações que impactem no banco de dados, o banco será
            //apagado e recriado. Todos os dados do banco serão perdidos, mesmo de tabelass que não foram alteradas
            Database.SetInitializer<FloriculturaContext>(new DropCreateDatabaseIfModelChanges<FloriculturaContext>());
        }

        //Aqui declaramos para o Entity Framework os modelos que queremos que sejam passado para o banco de dados
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }


    }
}