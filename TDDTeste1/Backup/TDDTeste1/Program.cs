using System.Collections.Generic;
using NUnit.Framework;
namespace TDDTeste1
{
    public class MaiorEMenor
    {
        public Produto Menor { get; private set; }
        public Produto Maior { get; private set; }

        public void Encontra(CarrinhoDeCompras carrinho)
        {
            foreach (Produto produto in carrinho.Produtos)
            {
              if(Menor == null || produto.Valor < Menor.Valor)
              {
                  Menor = produto;
              } 
              else if(Maior == null || produto.Valor > Maior.Valor)
              {
                  Maior = produto;
              }
            }
        }
    }
    public class Produto
    {
        private string _nome;
        private double _valor;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public double Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        
        public Produto()
        {
            Nome = string.Empty;
            Valor = 0;
        }
        public Produto(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
    public class CarrinhoDeCompras
    {
        private List<Produto> produtos = new List<Produto>();

        public List<Produto> Produtos
        {
            get { return produtos; }
            set { produtos = value; }
        }
        public void Adiciona(Produto p)
        {
            produtos.Add(p);
        }
    }
    [TestFixture]
    public class TestaMaiorEMenor
    {
        [Test]
        public void OrdemDecrescente()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            carrinho.Adiciona(new Produto("Geladeira", 450.0));
            carrinho.Adiciona(new Produto("Liquidificador", 250.0));
            carrinho.Adiciona(new Produto("Pratos", 70.0));

            MaiorEMenor algoritmo = new MaiorEMenor();
            algoritmo.Encontra(carrinho);
            Assert.AreEqual("Pratos",algoritmo.Menor.Nome);
            Assert.AreEqual("Geladeira", algoritmo.Maior.Nome);

        }
        
    }
}
