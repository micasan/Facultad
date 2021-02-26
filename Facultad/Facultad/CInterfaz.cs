﻿using System;

namespace Facultad
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("**************************************************************");
            Console.WriteLine("*            Sistema de Gestión de la Facultad               *");
            Console.WriteLine("**************************************************************");
            Console.WriteLine("\n* 1.  Establecer Cuota General para alumnos.               *");
            Console.WriteLine("\n* 2.  Conocer Cuota General para alumnos.                  *");
            Console.WriteLine("\n* 3.  Agregar un Alumno.                                   *");
            Console.WriteLine("\n* 4.  Mostrar datos de un Alumno.                          *");
            Console.WriteLine("\n* 5.  Listar los datos de todos los Alumnos.               *");
            Console.WriteLine("\n* 6.  Ordenar por legajo los datos de todos los Alumnos.   *");
            Console.WriteLine("\n* 7.  Remover un Alumno.                                   *"); 
            Console.WriteLine("\n* 8.  Agregar un Docente.                                  *");
            Console.WriteLine("\n* 9.  Mostrar datos de un Docente.                         *");
            Console.WriteLine("\n* 10. Listar los datos de todos los Docentes.              *");
            Console.WriteLine("\n* 11. Ordenar por legajo los datos de todos los Docentes.  *");
            Console.WriteLine("\n* 12. Remover un Docente.                                  *");
            Console.WriteLine("\n* 13. Agregar una Materia.                                 *");
            Console.WriteLine("\n* 14. Agregar un Alumno a una materia.                     *");
            Console.WriteLine("\n* 15. Agregar un Docente a una materia.                    *");
            Console.WriteLine("\n* 16. Mostrar datos de una Materia.                        *");
            Console.WriteLine("\n* 17. Listar los datos de todas las Materias.              *");
            Console.WriteLine("\n* 18. Ordenar alfabeticamente todas las Materias.          *");
            Console.WriteLine("\n* 19. Remover una Materia.                                 *");
            Console.WriteLine("\n* 20. Salir de la aplicación.                             *");
            Console.WriteLine("\n************************************************************");
            return CInterfaz.PedirDato("opción elegida");
        }

        public static string PedirDato(string NombDato)
        {
            Console.Write("[?] Ingrese " + NombDato + ": ");
            string Ingreso = Console.ReadLine();
            while (Ingreso == "")
            {
                Console.Write("[!] " + NombDato + "es de ingreso OBLIGATORIO:");
                Ingreso = Console.ReadLine();
            }
            Console.Clear();
            return Ingreso.Trim();  //.Trim() Remueve espacios en blanco previos y posteriores.

        }

        public static void MostrarInfo(string Mensaje)
        {
            Console.WriteLine(Mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

