using System;
using System.Windows.Forms;

namespace Scratch
{
    public sealed class Program
    {
        private static readonly bool winForms = bool.Parse("false");

        [STAThread]
        public static void Main()
        {
            if (winForms)
            {
                Application.EnableVisualStyles();
                Application.ThreadException += ((sender, e) => BaseClass.WE(e.Exception));
                Application.Run(new MyForm());
            }
            else
            {
                MyClass myC = new MyClass();

                try
                {
                    myC.Go();
                }
                catch (Exception e)
                {
                    BaseClass.WE(e);
                }

                Console.WriteLine();
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }
    }
}
