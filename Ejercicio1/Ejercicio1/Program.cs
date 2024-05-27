using System;
using System.Collections.Generic;

namespace Ejercicio1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> cedulas = new List<string>();
            List<string> nombres = new List<string>();
            List<int> tiposEmpleados = new List<int>();
            List<double> horasLaboradas = new List<double>();
            List<double> preciosPorHora = new List<double>();
            List<double> salariosOrdinarios = new List<double>();
            List<double> aumentos = new List<double>();
            List<double> salariosBrutos = new List<double>();
            List<double> deduccionesCCSS = new List<double>();
            List<double> salariosNetos = new List<double>();

            int cantidadOperarios = 0;
            double acumuladoSalarioNetoOperarios = 0;
            int cantidadTecnicos = 0;
            double acumuladoSalarioNetoTecnicos = 0;
            int cantidadProfesionales = 0;
            double acumuladoSalarioNetoProfesionales = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================Registro de Aumentos Salariales de Empleados==================");

                Console.Write("Ingrese la cédula del empleado: ");
                string cedula = Console.ReadLine();
                cedulas.Add(cedula);

                Console.Write("Ingrese el nombre del empleado: ");
                string nombre = Console.ReadLine();
                nombres.Add(nombre);

                Console.Write("Ingrese el tipo de empleado (1-Operario, 2-Técnico, 3-Profesional): ");
                int tipoEmpleado = Convert.ToInt32(Console.ReadLine());
                tiposEmpleados.Add(tipoEmpleado);

                Console.Write("Ingrese la cantidad de horas laboradas: ");
                double horas = Convert.ToDouble(Console.ReadLine());
                horasLaboradas.Add(horas);

                Console.Write("Ingrese el precio por hora: ");
                double precioHora = Convert.ToDouble(Console.ReadLine());
                preciosPorHora.Add(precioHora);

                double salarioOrdinario = horas * precioHora;
                salariosOrdinarios.Add(salarioOrdinario);

                double aumento = salarioOrdinario * ObtenerPorcentajeAumento(tipoEmpleado);
                aumentos.Add(aumento);

                double salarioBruto = salarioOrdinario + aumento;
                salariosBrutos.Add(salarioBruto);

                double deduccionCCSS = salarioBruto * 0.0917;
                deduccionesCCSS.Add(deduccionCCSS);

                double salarioNeto = salarioBruto - deduccionCCSS;
                salariosNetos.Add(salarioNeto);

                if (tipoEmpleado == 1)
                {
                    cantidadOperarios++;
                    acumuladoSalarioNetoOperarios += salarioNeto;
                }
                else if (tipoEmpleado == 2)
                {
                    cantidadTecnicos++;
                    acumuladoSalarioNetoTecnicos += salarioNeto;
                }
                else if (tipoEmpleado == 3)
                {
                    cantidadProfesionales++;
                    acumuladoSalarioNetoProfesionales += salarioNeto;
                }

                MostrarDetallesEmpleado(cedula, nombre, tipoEmpleado, precioHora, horas, salarioOrdinario, aumento, salarioBruto, deduccionCCSS, salarioNeto);

                Console.WriteLine("¿Desea registrar otro empleado? (SI = 1 | NO = 2):");
                if (int.Parse(Console.ReadLine()) != 1)
                {
                    break;
                }
            }

            MostrarEstadisticas(cantidadOperarios, acumuladoSalarioNetoOperarios, cantidadTecnicos, acumuladoSalarioNetoTecnicos, cantidadProfesionales, acumuladoSalarioNetoProfesionales);
        }

        static double ObtenerPorcentajeAumento(int tipoEmpleado)
        {
            switch (tipoEmpleado)
            {
                case 1: return 0.15;
                case 2: return 0.10;
                case 3: return 0.05;
                default: return 0;
            }
        }

        static void MostrarDetallesEmpleado(string cedula, string nombre, int tipoEmpleado, double precioHora, double horas, double salarioOrdinario, double aumento, double salarioBruto, double deduccionCCSS, double salarioNeto)
        {
            Console.WriteLine($"\nDetalles del Empleado:");
            Console.WriteLine($"Cédula: {cedula}");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Tipo Empleado: {tipoEmpleado}");
            Console.WriteLine($"Salario por Hora: {precioHora:C}");
            Console.WriteLine($"Cantidad de Horas: {horas}");
            Console.WriteLine($"Salario Ordinario: {salarioOrdinario:C}");
            Console.WriteLine($"Aumento: {aumento:C}");
            Console.WriteLine($"Salario Bruto: {salarioBruto:C}");
            Console.WriteLine($"Deducción CCSS: {deduccionCCSS:C}");
            Console.WriteLine($"Salario Neto: {salarioNeto:C}");
        }

        static void MostrarEstadisticas(int cantidadOperarios, double acumuladoSalarioNetoOperarios, int cantidadTecnicos, double acumuladoSalarioNetoTecnicos, int cantidadProfesionales, double acumuladoSalarioNetoProfesionales)
        {
            double promedioSalarioNetoOperarios = cantidadOperarios > 0 ? acumuladoSalarioNetoOperarios / cantidadOperarios : 0;
            double promedioSalarioNetoTecnicos = cantidadTecnicos > 0 ? acumuladoSalarioNetoTecnicos / cantidadTecnicos : 0;
            double promedioSalarioNetoProfesionales = cantidadProfesionales > 0 ? acumuladoSalarioNetoProfesionales / cantidadProfesionales : 0;

            Console.WriteLine("\nEstadísticas:");
            Console.WriteLine("\nOperarios:");
            Console.WriteLine($"Cantidad de Empleados: {cantidadOperarios}");
            Console.WriteLine($"Acumulado Salario Neto: {acumuladoSalarioNetoOperarios:C}");
            Console.WriteLine($"Promedio Salario Neto: {promedioSalarioNetoOperarios:C}");

            Console.WriteLine("\nTécnicos:");
            Console.WriteLine($"Cantidad de Empleados: {cantidadTecnicos}");
            Console.WriteLine($"Acumulado Salario Neto: {acumuladoSalarioNetoTecnicos:C}");
            Console.WriteLine($"Promedio Salario Neto: {promedioSalarioNetoTecnicos:C}");

            Console.WriteLine("\nProfesionales:");
            Console.WriteLine($"Cantidad de Empleados: {cantidadProfesionales}");
            Console.WriteLine($"Acumulado Salario Neto: {acumuladoSalarioNetoProfesionales:C}");
            Console.WriteLine($"Promedio Salario Neto: {promedioSalarioNetoProfesionales:C}");
        }
    }
}
