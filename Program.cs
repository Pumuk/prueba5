using System;

namespace Tarea1
{
    class Program
    {
        // --------------------------------------------
        // Carlos Martínez
        // Curso DAM/DAW
        // Modalidad Presencial/SemiPresencial
        // Práctica nº 1 (Funciones)
        // --------------------------------------------
        
        static void Main(string[] args)
        {
            char operacion = ' ';
            int resultado = 0;
            do
            {
                operacion = RealizarOperaciones(ref resultado);                
                Console.WriteLine("El resultado es {0}\n", resultado);
                
                if (operacion != 's') operacion = ' ';

            } while (operacion != 's'); // operacion == 's' --> SALIR
            
            Console.WriteLine("FIN PROGRAMA");
        }

        public static char RealizarOperaciones(ref int resultado)
        {
            char operacion = ' ';
            do
            {
                int numero = PedirNumero();
                
                if (operacion != ' ')
                    CalcularResultado(ref resultado, numero, operacion);
                else
                    resultado = numero;

                operacion = PedirOperacion();
            } while (operacion != '=' && operacion != 's');
            
            return operacion;
        }

        public static int PedirNumero()
        {
            int numero = 0;
            bool incorrecto = true;
            do
            {
                try
                {
                    Console.Write("Introduce un número: ");
                    numero = Convert.ToInt32(Console.ReadLine());
                    incorrecto = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("--> Número incorrecto");
                }
            } while (incorrecto);

            return numero;
        }

        public static char PedirOperacion()
        {
            char operacion = ' ';
            bool incorrecta = true;
            do
            {
                try
                {
                    Console.Write("Introduce una operación: ");
                    operacion = Convert.ToChar(Console.ReadLine());

                    switch (operacion)
                    {
                        case '+': case '-': case '/': case '*': case '=': case 's': incorrecta = false; break;
                        default: throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("--> Operación incorrecta");
                }
            } while (incorrecta);

            return operacion;
        }

        public static void CalcularResultado(ref int resultado, int numero, int operacion)
        {
            switch (operacion)
            {
                case '+': resultado += numero; break;
                case '-': resultado -= numero; break;
                case '/':
                    try { resultado /= numero; }
                    catch (DivideByZeroException) { Console.WriteLine("--> No se puede dividir entre 0"); }
                    break;
                case '*': resultado *= numero; break;
            }
        }
    }
}
