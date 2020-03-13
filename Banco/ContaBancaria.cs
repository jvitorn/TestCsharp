using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class ContaBancaria
    {
        private string nomeCliente;
        private double saldo;
        private bool bloqueada = false;
        private ContaBancaria()
        {

        }
        public ContaBancaria(string nomeDoCliente , double saldoDaConta)
        {
            nomeCliente = nomeDoCliente;
            saldo = saldoDaConta;
        }
        public string NomeCliente
        {
            get { return nomeCliente; }
        }
        public double Saldo
        {
            get { return saldo; }
        }
        public void Debito(double valor)
        {
            if (bloqueada)
            {
                throw new Exception("Conta Bloqueada");
            }
            if(valor > saldo)
            {
                throw new ArgumentOutOfRangeException("Valor Maior que o saldo");
            }
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("Valor menor que 0");
            }
            saldo += valor; // codigo errado

        }
        public void Credito(double valor)
        {
            if (bloqueada)
            {
                throw new Exception("Conta Bloqueada");
            }
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("Valor menor que 0");
            }
            saldo += valor;
        }
        private void ContaBloqueada()
        {
            bloqueada = true;
        }
        private void ContaNaoBloqueada()
        {
            bloqueada = false;
        }
        private static void Main()
        {
            ContaBancaria ba = new ContaBancaria("Shadow", 13.69);
            ba.Credito(5.77);
            ba.Debito(11.22);
            Console.WriteLine("O Saldo atual é R${0}", ba.Saldo);
        }
    }
}
