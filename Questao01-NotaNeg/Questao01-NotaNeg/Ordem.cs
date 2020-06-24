using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao01_NotaNeg
{
    class Ordem
    {
        private String Ticker { get; set; }
        private char Operacao { get; set; }
        private int Quantidade { get; set; }
        private float Unitario { get; set; }

        public Ordem(String pTicker, char pOperacao, int pQuantidade, float pUnitario)
        {
            this.Ticker = pTicker;
            this.Operacao = pOperacao;
            this.Quantidade = pQuantidade;
            this.Unitario = pUnitario;
        }

        public float totalOperacao()
        {
            return this.Unitario * this.Quantidade;
        }
    }    
}
