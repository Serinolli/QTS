using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao01_NotaNeg
{
    class Despesas
    {
        private float taxaLiquicadao { get; set; }
        private float emolumentos { get; set; }
        private float corretagem { get; set; }

        public Despesas()
        {
            this.corretagem = (float)(0.50);
            this.emolumentos = (float)(0.00003291);            
            this.taxaLiquicadao = (float)(0.000275);            
        }

        public float getTaxaLiquidacao(float totalOperacoes)
        {
            return this.taxaLiquicadao * totalOperacoes;
        }

        public float getEmolumentos(float totalOperacoes)
        {
            return this.emolumentos * totalOperacoes;
        }

        public float getCorretagem(int qtdOrdens)
        {
            return this.corretagem * qtdOrdens;
        }
    }
}
