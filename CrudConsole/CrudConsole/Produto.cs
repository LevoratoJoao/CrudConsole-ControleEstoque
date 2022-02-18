using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsole
{
    class Produto
    //IDPROD, DESCRICAO, ESTOQUE, VALOR
    {
        private int idprod;
        private string descricao;
        private int estoque;
        private double valor;

        public void SetIdprod(int idprod)
        {
            this.idprod = idprod;
        }
        public int GetIdProd()
        {
            return this.idprod;
        }

        public void SetDescricao(string descricao)
        {
            this.descricao = descricao;
        }
        public string GetDescricao()
        {
            return this.descricao;
        }
        
        public void SetEstoque(int estoque)
        {
            this.estoque = estoque;
        }
        public int GetEstoque()
        {
            return this.estoque;
        }

        public void SetValor(double valor)
        {
            this.valor = valor;
        }
        public double GetValor()
        {
            return this.valor;
        }


    }
}
