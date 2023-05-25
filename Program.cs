using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_List
{
    class Program
    {
        static void Main(string[] args)
        {

            BankAccount accountAna = new BankAccount("Ana Maria",  20000);
            accountAna.MakeDeposit(40000, DateTime.Now, "Deposito");
            Console.WriteLine(accountAna.GetAccountHistory());
            //BankAccount accountJorge = new BankAccount("Jorge Renato Bartolomeu", 50000 );
            // IMPRIMINDO AS CONTAS

            //  Console.WriteLine(accountJorge.GetAccountHistory());
            //Console.WriteLine(accountJorge.Balance);

            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("Invalid", -66);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exceção capturada criando conta com saldo negativo");
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
