using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao01_NotaNeg
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ordem> Ordens = new List<Ordem>();     //Lista de ordens de C/V do cliente            
            int qtdOrdens = 0;                          //Variável para contar as ordens
            float totalOperacoes = 0;                   //Variável para calcular total das operações

            montarCabecalho();                          //Monta o cabeçalho da tela
            lerOrdens(ref Ordens);                      //Lê as ordens do cliente
            totalOperacoes = processaOrdens(ref qtdOrdens, Ordens);   //Calcula total das operações
            montarTotais(totalOperacoes, qtdOrdens);    //Calcula e monta totais da nota

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Tecle algo para sair.");
            Console.ReadKey();
        }

        static void montarCabecalho()
        {
            Console.WriteLine("*************************************************************");
            Console.WriteLine("                Exemplo - Nota Corretagem                    ");
            Console.WriteLine("*************************************************************");
            Console.WriteLine("");
        }

        static void montarTotais(float totalOper, int qtdOrdens)
        {
            Despesas desp = new Despesas();             //Classe que contém as info. de despesas
            float txLiq, emol, corr, liqNota = 0;

            txLiq = desp.getTaxaLiquidacao(totalOper);  //Calculando taxa de liquidação
            emol = desp.getEmolumentos(totalOper);      //Calculando emolumentos
            corr = desp.getCorretagem(qtdOrdens);       //Calculando corretagem
            liqNota = totalOper - txLiq - emol - corr;  //Calculando líquido da nota

            Console.WriteLine("");
            Console.WriteLine("+++++++++++++++ Total da Nota ++++++++++++++++++");
            Console.WriteLine("");
            Console.WriteLine("Total das operações: " + totalOper);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Taxa de Liquidação: " + Math.Round(txLiq,2));
            Console.WriteLine("Emolumentos: " + Math.Round(emol,2));
            Console.WriteLine("Corretagem: " + corr);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Valor líquido da nota: " + liqNota);
            Console.WriteLine("------------------------------------------------");
        }

        static void lerOrdens(ref List<Ordem> ord)
        {
            bool continuarLendo = true;
            String ticker = "";
            char operacao = ' ';
            int quantidade = 0;
            float unitario = 0;

            while (continuarLendo)
            {
                Console.Write("Ticker: ");
                ticker = Console.ReadLine().ToUpper();
                Console.Write("C/V: ");
                operacao = Convert.ToChar( Console.ReadLine().ToUpper());
                Console.Write("Quantidade: ");
                quantidade = Convert.ToInt32( Console.ReadLine() );
                Console.Write("Valor unitário: ");
                unitario = (float) Convert.ToDouble( Console.ReadLine() );

                ord.Add( new Ordem(ticker, operacao, quantidade, unitario) );

                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Adicionar outra ordem? (S/N) ");
                continuarLendo = (Console.ReadLine().ToUpper() == "S");
            }
        }

        static float processaOrdens(ref int qtd, List<Ordem> ord)
        {
            int auxQtd = 0;
            float auxOper = 0;

            foreach (var Ordem in ord)
            {
                auxQtd++;
                auxOper += Ordem.totalOperacao();
            }
            qtd = auxQtd;

            return auxOper;
        }
    }
}
