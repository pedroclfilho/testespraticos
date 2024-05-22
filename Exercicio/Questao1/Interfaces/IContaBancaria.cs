using System;
using System.Globalization;

namespace Questao1
{
    interface IContaBancaria
    {

        /// <summary>
        /// Valor do Saldo atual.
        /// </summary>
        public double Saldo { get; }

        /// <summary>
        /// Retorna o número da Conta Bancária do Titular.
        /// </summary>
        public int NumeroDaConta { get; }
        /// <summary>
        /// Retorna o Nome do Titular da Conta atual.
        /// </summary>
        public string NomeTitular { get; }


        /// <summary>
        /// Retorna o valor da Taxa da operação
        /// </summary>
        public double TaxaPorSaque { get; }

        /// <summary>
        /// Efetuar operação de Depósito. 
        /// </summary>
        /// <param name="valorDeposito">Informe um valor que não seja negativo.</param>
        void Deposito(double valorDeposito);

        /// <summary>
        /// Eeftuar uma operação de Saque caso exista saldo suficiente em conta.
        /// </summary>
        /// <param name="valorSaque">Informe um valor que não seja negativo.</param>
        /// <returns></returns>
        bool Saque(double valorSaque);
    }
}
