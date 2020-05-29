using System;

namespace ExplicitInterfaceImplementation
{
    public interface IWindow
    {
        void Close();
    }

    public interface IBankAccount
    {
        void Close();
    }

    public class BankingDialog : IBankAccount, IWindow
    {
        void IBankAccount.Close()
        {
            Console.WriteLine("IBankAccount.Close");
        }

        public void Close()
        {
            Console.WriteLine("IWindow.Close");
        }
    }

    class Program
    {
        static void ProcessWindow (IWindow w)
        {
            w.Close();
        }

        static void Main()
        {
            BankingDialog bd = new BankingDialog();

            bd.Close();

            IBankAccount ba = bd;

            ba.Close();

            IWindow w = bd;

            w.Close();

            ProcessWindow(bd);
        }
    }
}
