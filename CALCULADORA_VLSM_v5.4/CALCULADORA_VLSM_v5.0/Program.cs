using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULADORA_VLSM_v5._0
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    clsMostrarTabla Run = new clsMostrarTabla();
                    Run.Interfaz();
                    Run.MostraDatos();
                }
                catch (Exception)
                {
                    Console.Beep();
                    Console.WriteLine("\n\nLA DIRECCION IP ESTA MAL ESCRITA O\nLA MATRIZ NO DA PARA MAS :( ESPERE UNA PROXIMA ACTUALIZACION");
                    Console.ReadLine();
                }
            }
        }
    }
}
