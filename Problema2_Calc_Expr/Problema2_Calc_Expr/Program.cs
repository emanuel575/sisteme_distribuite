using System;
using System.Windows.Forms;
using System.Data;


namespace Problema2_Calc_Expr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            var input = "3+(4*3)";

            DataTable dt = new DataTable();
            var result = dt.Compute(input,"");

            MessageBox.Show(result.ToString());
        }
    }
}
