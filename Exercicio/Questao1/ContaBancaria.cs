using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria: IContaBancaria
    {

        protected double saldo_;
        /// <summary>
        /// Valor do Saldo atual.
        /// </summary>
        public double Saldo
        {
            get
            {
                return saldo_;
            }

        }
        protected int numeroDaConta_;
        
        /// <summary>
        /// Retorna o número da Conta Bancária do Titular.
        /// </summary>
        public int NumeroDaConta
        {
            get
            {
                return numeroDaConta_;
            }
        }

        private string nomeTitular_;
        /// <summary>
        /// Retorna o Nome do Titular da Conta atual.
        /// </summary>
        public string NomeTitular
        {
            get { return nomeTitular_; }
        }
        
        protected double taxaPorSaque_;

        /// <summary>
        /// Retorna o valor da Taxa da operação
        /// </summary>
        public double TaxaPorSaque
        {
            get
            {
                return taxaPorSaque_;
            }
        }
        /// <summary>
        /// Criar uma Conta Bancária para o Cliente.
        /// </summary>
        /// <param name="numeroDaConta">Infome o número da Conta do Cliente</param>
        /// <param name="nomeTitular">Informe o Nome do Titular da Conta.</param>
        /// <param name="valorDepositoInicial">O preenchimento deste campo é opcional, somente no caso do Cliente optar por efetuar um Depósito Inicial ao criar a sua Conta</param>
        public ContaBancaria(int numeroDaConta, string nomeTitular, double? valorDepositoInicial=null)
        {
            if (string.IsNullOrEmpty(nomeTitular?.Trim()) || ((valorDepositoInicial??0.0)<0.0))
            {
                throw new Exception("Parâmetros de Abertura de Conta Bancária inválidos! Verifique o nome do Titular está correto ou se o Valor de Depósito Inicial é uma valor válido.");
            }


            this.numeroDaConta_ = numeroDaConta;
            this.nomeTitular_ = nomeTitular;
            this.saldo_ = valorDepositoInicial??0.0;
            this.taxaPorSaque_ = 3.5;
        }

        /// <summary>
        /// Efetuar operação de Depósito. 
        /// </summary>
        /// <param name="valorDeposito">Informe um valor que não seja negativo.</param>
        public void Deposito(double valorDeposito)
        {
            if (valorDeposito < 0.0)
            {
                throw new Exception("Valor de depósito inválido!");
            }
            this.saldo_ += valorDeposito;

        }

        /// <summary>
        /// Eeftuar uma operação de Saque caso exista saldo suficiente em conta.
        /// </summary>
        /// <param name="valorSaque">Informe um valor que não seja negativo.</param>
        /// <returns></returns>
        public bool Saque(double valorSaque)
        {
            if (valorSaque < 0.0)
            {
                throw new Exception("Valor inválido para efetuar operação de Saque!");
            }
            if (this.saldo_< valorSaque)
            {
                return false;
            }
            this.saldo_ -= (valorSaque+taxaPorSaque_);
            return true;
        }
    }
}
