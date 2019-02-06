namespace FloriculturaBeta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        ClienteNome = c.String(nullable: false),
                        ClienteCpf = c.String(nullable: false),
                        ClienteTelefone = c.String(nullable: false),
                        ClienteEstado = c.String(nullable: false),
                        ClienteCidade = c.String(nullable: false),
                        ClienteBairro = c.String(nullable: false),
                        ClienteRua = c.String(nullable: false),
                        ClienteNumero = c.String(),
                        ClienteComplemento = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioId = c.Int(nullable: false, identity: true),
                        FuncionarioNome = c.String(nullable: false),
                        FuncionarioCpf = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.ItemVendas",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        ItemVendaQuantidade = c.Int(nullable: false),
                        VendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Vendas", t => t.VendaId, cascadeDelete: true)
                .Index(t => t.ProdutoId)
                .Index(t => t.VendaId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        ProdutoNome = c.String(nullable: false),
                        ProdutoDescricao = c.String(nullable: false),
                        ProdutoValor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProdutoEstoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        FuncionarioId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        VendaData = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        UsuarioLogin = c.String(),
                        UsuarioSenha = c.String(),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "FuncionarioId", "dbo.Funcionarios");
            DropForeignKey("dbo.ItemVendas", "VendaId", "dbo.Vendas");
            DropForeignKey("dbo.Vendas", "FuncionarioId", "dbo.Funcionarios");
            DropForeignKey("dbo.Vendas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ItemVendas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Usuarios", new[] { "FuncionarioId" });
            DropIndex("dbo.Vendas", new[] { "ClienteId" });
            DropIndex("dbo.Vendas", new[] { "FuncionarioId" });
            DropIndex("dbo.ItemVendas", new[] { "VendaId" });
            DropIndex("dbo.ItemVendas", new[] { "ProdutoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Vendas");
            DropTable("dbo.Produtoes");
            DropTable("dbo.ItemVendas");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Clientes");
        }
    }
}
