using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace ExamFinal
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        static Form1 frm1;
        static void ConsoleProperties()
        {
            Console.Title = "Estadistica Colegio";
            Console.WindowHeight = 15;
            Console.WindowWidth = 72;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

        }
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread thrd1 = new Thread(EstadisticaColegio);            
            thrd1.Start();
            HideConsoleWindow();
            Application.Run(new Form1());
        }
        static void EstadisticaColegio(object state)
        {



            int opcionMenu = 0;


            do
            {
                try
                {
                    ConsoleProperties();
                    Console.Clear();
                    Console.WriteLine("+++++++++++++++++++++++++++++++");
                    Console.WriteLine("1- Generar datos");
                    Console.WriteLine("2- Mostrar datos");
                    Console.WriteLine("3- Imprimir datos");
                    Console.WriteLine("4- Salir");
                    Console.WriteLine("+++++++++++++++++++++++++++++++");
                    Console.Write("Digite una opción: ");

                    opcionMenu = Convert.ToInt32(Console.ReadLine());

                    switch (opcionMenu)
                    {
                        case 1:



                            break;

                        case 2:



                            break;

                        case 3:

                            break;

                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOpción inválida.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nIngrese una opción: ");
                            break;

                        case 4:
                            HideConsoleWindow();
                            break;
                    }


                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDigite un valor númerico");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\nPresione cualquier tecla para reintentar...");
                    Console.ReadKey();

                }
            }
            while (opcionMenu != 4);
        }

    

        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();

            }
            else
            {
                ShowWindow(handle, SW_SHOW);

            }
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);

        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
    }
}

