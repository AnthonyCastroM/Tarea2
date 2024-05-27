using System;

namespace Ejercicio2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region VARIABLES
            int opcion = 0;
            int numeroFactura = 0;
            string cedula = "";
            string nombre = "";
            string nombreLocalidad = "";
            int localidad = 0;
            int entradas = 0;
            float precioEntrada = 0;
            float precioTotal = 0;
            float precioSubTotal = 0;
            float precioCargos = 0;
            int entradasSol = 0;
            int entradasSombra = 0;
            int entradasPreferencial = 0;
            float dineroSol = 0;
            float dineroSombra = 0;
            float dineroPreferencial = 0;
            #endregion

            Console.WriteLine("############## SISTEMA DE CONTROL DE VENTAS ##############\n");

            //Menu
            while (opcion != 3)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1- Generar Factura");
                Console.WriteLine("2- Estadisticas");
                Console.WriteLine("3- Salir");
                Console.Write("Selecciona una opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        GenerarFactura();
                        break;

                    case 2:
                        Estadisticas();
                        break;

                    case 3:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida. Por favor, selecciona una opción valida.");
                        break;
                }

                Console.WriteLine(); // Línea en blanco para mejorar la legibilidad del menú
            }

            void GenerarFactura()
            {
                Console.Write("Digite el numero de factura: ");
                int.TryParse(Console.ReadLine(), out numeroFactura);
                Console.Write("Digite el numero de cedula: ");
                cedula = Console.ReadLine();
                Console.Write("Digite su nombre: ");
                nombre = Console.ReadLine();
                Console.Write("\nTipo localidad: \n\t1-Sol Norte/Sur \n\t2-Sombra Este/Oeste \n\t3-Preferencial\n");

                while (localidad < 1 || localidad > 3)
                {
                    Console.Write("Ingresar localidad: ");
                    int.TryParse(Console.ReadLine(), out localidad);
                    if (localidad > 3)
                    {
                        Console.WriteLine("La localidad ingresada no existe!");
                    }
                }
                while (entradas < 1 || entradas > 4)
                {
                    Console.Write("Ingresar cantidad de entradas: ");
                    int.TryParse(Console.ReadLine(), out entradas);
                    if (entradas > 4)
                    {
                        Console.WriteLine("No puedes comprar mas de 4 entradas");
                    }
                }

                //Asignacion de precio de entrada y nombre de localidad
                switch (localidad)
                {
                    case 1:
                        precioEntrada = 10500;
                        nombreLocalidad = "Sol Norte/Sur";
                        break;
                    case 2:
                        precioEntrada = 20500;
                        nombreLocalidad = "Sombra Este/Oeste";
                        break;
                    case 3:
                        precioEntrada = 25500;
                        nombreLocalidad = "Preferencial";
                        break;
                }

                //Calculo de factura
                precioSubTotal = precioEntrada * entradas;
                precioCargos = 1000 * entradas;
                precioTotal = precioSubTotal + precioCargos;


                //Factura
                Console.Clear();
                Console.Clear();
                Console.WriteLine("==============FACTURA==============");
                Console.WriteLine("#" + numeroFactura);
                Console.WriteLine("\nCedula: " + cedula);
                Console.WriteLine("Nombre Comprador: " + nombre);
                Console.WriteLine("Localidad: " + nombreLocalidad);
                Console.WriteLine("Cantidad entradas: " + entradas);
                Console.WriteLine("\n\nSubTotal: " + precioSubTotal);
                Console.WriteLine("Cargos por servicios: " + precioCargos);
                Console.WriteLine("SubTotal: " + precioTotal);
                Console.WriteLine("===================================");


                //Suna estadisticas
                if (localidad == 1)
                {
                    entradasSol = entradasSol + entradas;
                    dineroSol = dineroSol + precioTotal;
                }
                else if (localidad == 2)
                {
                    entradasSombra = entradasSombra + entradas;
                    dineroSombra = dineroSombra + precioTotal;
                }
                else if (localidad == 3)
                {
                    entradasPreferencial = entradasPreferencial + entradas;
                    dineroPreferencial = dineroPreferencial + precioTotal;
                }
            }



            //Estadisticas
            void Estadisticas()
            {
                Console.WriteLine("==================ESTADISTICAS================");
                Console.WriteLine("Cantidad Entradas Localidad Sol Norte / Sur: " + entradasSol);
                Console.WriteLine("Acumulado Dinero Localidad Sol Norte / Sur: " + dineroSol);
                Console.WriteLine("\nCantidad Entradas Localidad Sombra Este / Oeste: " + entradasSombra);
                Console.WriteLine("Acumulado Dinero Localidad Sombra Este / Oeste: " + dineroSombra);
                Console.WriteLine("\nCantidad Entradas Localidad Preferencial: " + entradasPreferencial);
                Console.WriteLine("Acumulado Dinero Localidad Preferencial: " + dineroSombra);
                Console.WriteLine("==============================================");
            }
        }
    }
}
