using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace CALCULADORA_VLSM_v5._0
{
    class clsMostrarTabla
    {
        string NombreSub = "";
        string mask_dec;
        int N_sub;
        int mask = 0;// LA MASK SIEMPRE ES 32 MENOS EL NUMERO DE BITS UTILIZADOS
        int J;
        int const_i=0;
        int Colum; // NUMERO DE COLUMNAS
        int IP_Mother = 0;
        int Broadcast = 0;
        int oct1, oct2, oct3,oct4;
        int Punto1, Punto2, Punto3,Punto4;
        int mask_Original;
        int HostRedir;
        string Bin_oct1, Bin_oct2, Bin_oct3, Bin_oct4;
        dynamic Redi;//Direccion IP indicada 192.168.1.
        dynamic IP_Original;
        dynamic RED_BIN;
        dynamic TOTAL = 0;
        dynamic Rango_host1, Rango_host2;
        dynamic x_print,X_TOTAL;
        dynamic[] TABLA = new dynamic[16777216];//
        bool Z;
        List<dynamic> Tablita = new List<dynamic>();
        public void VALIDACION()
        {
            if (const_i == 256)
            {
                const_i = 0;
                oct3 += 1;

                if (oct3 == 256)
                {
                    const_i = 0;
                    oct3 = 0;
                    oct2 += 1;
                }
            }
        }
        public void MostraDatos()
        {
            Console.Beep();
            Console.WriteLine("Cual es la direccion IP de Origen".ToUpper());
            Redi = Console.ReadLine();
            IP_Original = Convert.ToString(Redi);
            Punto1 = Redi.IndexOf(".");
            Punto2 = Redi.IndexOf(".", 4);
            Punto3 = Redi.IndexOf(".", 8);
            Punto4 = Redi.IndexOf(".", 8);
            oct1 = Convert.ToInt32(Redi.Substring(0, Punto1));
            oct2 = Convert.ToInt32(Redi.Substring(Punto1 + 1, Punto2 - Punto1 - 1));
            oct3 = Convert.ToInt32(Redi.Substring(Punto2 + 1, Punto3 - Punto2 - 1));
            oct4 = Convert.ToInt32(Redi.Substring(Punto4 + 1));

            Bin_oct1 = Convert.ToString(oct1, 2);
            Bin_oct2 = Convert.ToString(oct2, 2);
            Bin_oct3 = Convert.ToString(oct3, 2);
            Bin_oct4 = Convert.ToString(oct4, 2);
            RED_BIN = Bin_oct1 + "." + Bin_oct2 + "." + Bin_oct3 + "." + Bin_oct4;
            Console.WriteLine("Cual es la mask:_".ToUpper());
            mask_Original = Convert.ToInt32(Console.ReadLine());
            IP_Original = IP_Original + "/" + mask_Original;
            Console.WriteLine("Cuantas subredes Existen".ToUpper());
            N_sub = Convert.ToInt32(Console.ReadLine());
            oct3 = 0;
            VALIDACION_MASK();
            Redi = oct1 + ".";
            ///     CICLO PARA EL NUMERO DE REDES EXISTENTES
            for (int N = 0; N < N_sub; N++)
            {
                dynamic N_Bits = 0;
                Z = true;
                List<dynamic> Sub_redes_list = new List<dynamic>();
                Console.WriteLine("Nombre de la Subred: ".ToUpper() + (N + 1));
                NombreSub = Console.ReadLine();
                Console.WriteLine("Cauntas Direcciones ocupa: ".ToUpper());
                HostRedir = Convert.ToInt32(Console.ReadLine());
                Console.Beep();
                ///               NUMERO DE BITS
                if (HostRedir == 1)
                {
                    N_Bits = 1;
                    mask = 32 - N_Bits;
                    Colum = 2;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();                
                }
                else
                if (HostRedir == 2)
                {
                    N_Bits = 2;
                    mask = 32 - N_Bits;
                    Colum = 4;
                    DATA();
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                  }
                else
                if (HostRedir >= 3 && HostRedir <= 6)
                {
                    N_Bits = 3;
                    mask = 32 - N_Bits;
                    Colum = 8;
                    DATA();
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else
                if (HostRedir >= 7 && HostRedir <= 14)
                {
                    N_Bits = 4;
                    mask = 32 - N_Bits;
                    Colum = 16;
                    IP_Mother = J;
                    DATA();
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else
                if (HostRedir >= 15 && HostRedir <= 30)
                {
                    N_Bits = 5;
                    mask = 32 - N_Bits;
                    Colum = 32;
                    DATA();
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else
                if (HostRedir >= 31 && HostRedir <= 62)
                {
                    N_Bits = 6;
                    mask = 32 - N_Bits;
                    Colum = 64;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();

                }
                else
                if (HostRedir >= 63 && HostRedir <= 126)
                {
                    N_Bits = 7;
                    mask = 32 - N_Bits;
                    Colum = 128;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();

                }
                else
                if (HostRedir >= 127 && HostRedir <= 254)
                {
                    N_Bits = 8;
                    mask = 32 - N_Bits;
                    Colum = 256;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();

                }
                if (HostRedir >= 255 && HostRedir <= 511)
                {
                    N_Bits = 9;
                    mask = 32 - N_Bits;
                    Colum = 512;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;

                    }
                    RESUMEN();
                    TABLA_PRINT();



                }
                else if (HostRedir >= 512 && HostRedir <= 1023)
                {
                    N_Bits = 10;
                    mask = 32 - N_Bits;
                    Colum = 1024;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;

                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else if (HostRedir >= 1024 && HostRedir <= 2047)
                {
                    N_Bits = 11;
                    mask = 32 - N_Bits;
                    Colum = 2048;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else if (HostRedir >= 2048 && HostRedir <= 4095)
                {
                    N_Bits = 12;
                    mask = 32 - N_Bits;
                    Colum = 4096;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else if (HostRedir >= 4096 && HostRedir <= 8191)
                {
                    N_Bits = 13;
                    mask = 32 - N_Bits;
                    Colum = 8192;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else if (HostRedir >= 8192 && HostRedir <= 16383)
                {
                    N_Bits = 14;
                    mask = 32 - N_Bits;
                    Colum = 16384;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else if (HostRedir >= 16384 && HostRedir <= 32767)
                {
                    N_Bits = 15;
                    mask = 32 - N_Bits;
                    Colum = 32768;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else if (HostRedir >= 32768 && HostRedir <= 65535)
                {
                    N_Bits = 16;
                    mask = 32 - N_Bits;
                    Colum = 65535;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }

                ////// continuar mañana desde aqui 4/3/18...
                else if (HostRedir >= 65536 && HostRedir <= 131071)
                {

                    N_Bits = 17;
                    mask = 32 - N_Bits;
                    Colum = 131072;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();

                }
                else if (HostRedir >= 131072 && HostRedir <= 262143)
                {

                    N_Bits = 18;
                    mask = 32 - N_Bits;
                    Colum = 262144;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();

                }
                else if (HostRedir >= 262144 && HostRedir <= 524287)
                {

                    N_Bits = 19;
                    mask = 32 - N_Bits;
                    Colum = 524288;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();

                }
                else if (HostRedir >= 524288 && HostRedir <= 1048575)
                {

                    N_Bits = 20;
                    mask = 32 - N_Bits;
                    Colum = 1048576;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else if (HostRedir >= 1048576 && HostRedir <= 2097151)
                {

                    N_Bits = 21;
                    mask = 32 - N_Bits;
                    Colum = 2097152;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();

                }
                else if (HostRedir >= 2097152 && HostRedir <= 4194303)
                {

                    N_Bits = 22;
                    mask = 32 - N_Bits;
                    Colum = 2097153;
                    IP_Mother = J;
                    Broadcast = J + Colum - 1;
                    Rango_host1 = J + 1;
                    Rango_host2 = Broadcast - 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();

                }
                else if (HostRedir >= 4194304 && HostRedir <= 8388607)
                {

                    N_Bits = 23;
                    mask = 32 - N_Bits;
                    Colum = 4194304;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        VALIDACION();
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
                else if (HostRedir >= 8388608 && HostRedir <= 16777215)
                {
                    N_Bits = 24;
                    mask = 32 - N_Bits;
                    Colum = 16777216;
                    DATA();
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (dynamic i = J; i < J + Colum; i++)
                    {
                        if (const_i == 256)
                        {
                            const_i = 0;
                            oct3 += 1;

                            if (oct3 == 256)
                            {
                                const_i = 0;
                                oct3 = 0;
                                oct2 += 1;
                            }
                            if (oct2 == 256)
                            {
                                const_i = 0;
                                oct3 = 0;
                                oct2 = 0;
                                oct1 += 1;
                            }
                        }
                        TABLA[i] = Redi + oct2 + "." + oct3 + "." + const_i + "\\" + mask;
                        const_i += 1;
                    }
                    RESUMEN();
                    TABLA_PRINT();
                }
            }
            TOTAL = 16777216 - J;// NUMERO DE REDEAS SOBRANTES //
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("REDES LIBRES: " + TOTAL);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\nOPRIMA ENTER PARA MOSTRAR TABLA");
            Console.WriteLine("   ████████╗ █████╗ ██████╗ ██╗      █████╗       ");
            Console.WriteLine("   ╚══██╔══╝██╔══██╗██╔══██╗██║     ██╔══██╗     ");
            Console.WriteLine("█████╗██║   ███████║██████╔╝██║     ███████║█████╗");
            Console.WriteLine("╚════╝██║   ██╔══██║██╔══██╗██║     ██╔══██║╚════╝");
            Console.WriteLine("      ██║   ██║  ██║██████╔╝███████╗██║  ██║      ");
            Console.WriteLine("      ╚═╝   ╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝     ");
             Console.ReadLine();
            Console.Beep();    
            Console.WriteLine(X_TOTAL);       
            Console.ReadLine();
        }

        public void Interfaz()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("                         ██╗   ██╗██╗     ███████╗███╗   ███╗    ███████╗    ██████╗    ██████╗ ");
            Console.WriteLine("                         ██║   ██║██║     ██╔════╝████╗ ████║    ██╔════╝   ██╔═████╗   ╚════██╗");
            Console.WriteLine("                         ██║   ██║██║     ███████╗██╔████╔██║    ███████╗   ██║██╔██║    █████╔╝");
            Console.WriteLine("                         ╚██╗ ██╔╝██║     ╚════██║██║╚██╔╝██║    ╚════██║   ████╔╝██║    ╚═══██╗");
            Console.WriteLine("                          ╚████╔╝ ███████╗███████║██║ ╚═╝ ██║    ███████║██╗╚██████╔╝██╗██████╔╝ ");
            Console.WriteLine("                           ╚═══╝  ╚══════╝╚══════╝╚═╝     ╚═╝    ╚══════╝╚═╝ ╚═════╝ ╚═╝╚═════╝");
            Console.WriteLine("                                           ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.WriteLine("                                           ███▓▒░░.CALCULADORA VLSM v5.0.3 ░░▒▓███ ");
            Console.WriteLine("                                           ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                        ( ( (                           ");
            Console.WriteLine("                         ) ) )                          ");
            Console.WriteLine("                        ( ( (                           ");
            Console.WriteLine("                      '. ___ .'                         ");
            Console.WriteLine("                     '  (> <) '                         ");
            Console.WriteLine("                ---oOO-- (_) ----oOO---                 ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║         INGRESA LA IP DE ESTA FORMA X.X.X.X          ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║______________________________________________________║");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("║ CREADOR: OSCAR EDUARDO RAYGOZA   PROYECTO:   REDES   ║");
            Console.WriteLine("║ PROFESOR: CARLOS HINOJOSA M.             TIC´S 2°B   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                            © Oscar Eduardo Raygoza ®");
            Console.WriteLine("                                                                                                █║▌│█│║▌║││█║▌║▌║    ");
            Console.WriteLine();
            Console.WriteLine();
        }
        public void VALIDACION_MASK()
        {
           
            if (mask == 30)
            {
                mask_dec = "255.255.255.252";
            }
            else if (mask == 29)
            {
                mask_dec = "255.255.255.248";
            }
            else if (mask == 28)
            {
                mask_dec = "255.255.255.240";
            }
            else if (mask == 27)
            {
                mask_dec = "255.255.255.224";
            }
            else if (mask == 26)
            {
                mask_dec = "255.255.255.192";
            }
            else if (mask == 25)
            {
                mask_dec = "255.255.255.128";
            }
            else if (mask == 24)
            {
                mask_dec = "255.255.255.0";
            }
            else if (mask == 23)
            {
                mask_dec = "255.255.254.0";
            }
            else if (mask == 22)
            {
                mask_dec = "255.255.252.0";
            }
            else if (mask == 21)
            {
                mask_dec = "255.255.248.0";
            }
            else if (mask == 20)
            {
                mask_dec = "255.255.240.0";
            }
            else if (mask == 19)
            {
                mask_dec = "255.255.224.0";
            }
            else if (mask == 18)
            {
                mask_dec = "255.255.192.0";
            }
            else if (mask == 17)
            {
                mask_dec = "255.255.128.0";
            }
            else if (mask == 16)
            {
                mask_dec = "255.255.0.0";
            }
            else if (mask == 15)
            {
                mask_dec = "255.254.0.0";
                
            }
            else if (mask == 14)
            {
                mask_dec = "255.252.0.0";
            }
            else if (mask == 13)
            {
                mask_dec = "255.248.0.0";
            }
            else if (mask == 12)
            {
                mask_dec = "255.240.0.0";
            }
            else if (mask == 11)
            {
                mask_dec = "255.224.0.0";
            }
            else if (mask == 10)
            {
                mask_dec = "255.192.0.0";
            }
            else if (mask == 9)
            {
                mask_dec = "255.128.0.0";
            }
            else if (mask == 8)
            {
                mask_dec = "255.0.0.0";
            }
            else if (mask == 7)
            {
                mask_dec = "254.0.0.0";
            }
            else if (mask == 6)
            {
                mask_dec = "252.0.0.0";
            }
            else if (mask == 5)
            {
                mask_dec = "248.0.0.0";
            }
            else if (mask == 4)
            {
                mask_dec = "240.0.0.0";
            }
            else if (mask == 3)
            {
                mask_dec = "224.0.0.0";
            }
            else if (mask == 2)
            {
                mask_dec = "192.0.0.0";
            }
            else if (mask == 1)
            {
                mask_dec = "128.0.0.0";
            }
            else if (mask == 0)
            {
                mask_dec = "0.0.0.0";
            }





            if (mask_Original == 15 && oct2 >= 255)
            {
                oct2 = 254;
            }
            else if (mask_Original == 14 && oct2 >= 252)
            {
                oct2 = 252;
            }
            else if (mask_Original == 13 && oct2 >= 248)
            {
                oct2 = 248;
            }
            else if (mask_Original == 12 && oct2 >= 240)
            {
                oct2 = 240;
            }
            else if (mask_Original == 11 && oct2 >= 224)
            {
                oct2 = 224;
            }
            else if (mask_Original == 10 && oct2 >= 192)
            {
                oct2 = 192;
            }
            else if (mask_Original == 9 && oct2 >= 128)
            {
                oct2 = 128;
            }
            else if (mask_Original == 8 && oct2 >= 0)
            {
                oct2 = 0;
            }
            else if (mask_Original == 7 && oct1 >= 254)
            {
                oct2 = 0;
                oct1 = 254;
            }
            else if (mask_Original == 6 && oct1 >= 252)
            {
                oct2 = 0;
                oct1 = 252;
            }
            else if (mask_Original == 5 && oct1 >= 248)
            {
                oct2 = 0;
                oct1 = 248;
            }
            else if (mask_Original == 4 && oct1 >= 240)
            {
                oct2 = 0;
                oct1 = 240;
            }
            else if (mask_Original == 3 && oct1 >= 224)
            {
                oct2 = 0;
                oct1 = 224;
            }
            else if (mask_Original == 2 && oct1 >= 198)
            {
                oct2 = 0;
                oct1 = 198;
            }
            else if (mask_Original == 1 && oct1 >= 128)
            {
                oct2 = 0;
                oct1 = 128;
            }
            else if (mask_Original == 0 && oct1 >= 0)
            {
                oct2 = 0;
                oct1 = 0;
            }
        } 
        public void TABLA_PRINT()
        {
            VALIDACION_MASK();
                            
            x_print = ("\n\n▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒\nIP: " + TABLA[IP_Mother] + "\n\nRANGO DE HOST:   " + TABLA[Rango_host1] + "  A  " + TABLA[Rango_host2] + "\n\nBROADCAST:  " + TABLA[Broadcast] + "\n\nNOMBRE DE LA RED: " + NombreSub + "\n\nMASK DEC: " + mask_dec +"\n\nTAMAÑO USADO: "+HostRedir+" | TAMAÑO REQUERIDO: "+Colum+ "\n▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒");
            X_TOTAL += x_print;
        }

        public void RESUMEN()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\nIP DE ORIGEN: " + IP_Original);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("BINARIO: => " + RED_BIN);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nNOMBRE DE RED: " + NombreSub + "\n\nIP DE RED: " + TABLA[IP_Mother]);
            Console.WriteLine("\nBROADCAST: " + TABLA[Broadcast]);
            Console.WriteLine("\nRANGO DE HOST:  " + TABLA[Rango_host1] + "   ---    " + TABLA[Rango_host2]);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n");
            J = J + Colum;
        }

        public void DATA()
        {
            IP_Mother = J;
            Broadcast = J + Colum - 1;
            Rango_host1 = J + 1;
            Rango_host2 = Broadcast - 1;
        }

    }
}