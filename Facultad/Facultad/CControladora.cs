using System;
namespace Facultad
{
    public class CControladora
    {
        public static void Main()
        {
            CAlumnos ListaAlumnos = new CAlumnos();
            CDocentes ListaDocentes = new CDocentes();
            CMaterias ListaMaterias = new CMaterias();
            int Opcion, AuxInt;
            ulong AuxLeg;
            string AuxApe, AuxNom;
            string AuxNomMat, AuxDia, AuxHorIni, AuxHorFin;
            string AuxHorario;
            CDocente AuxDoc;
            CMateria AuxMat;

            do
            {
                Opcion = int.Parse(CInterfaz.DarOpcion());
                switch (Opcion)
                {
                    case 1:  //Establecer cuota general para Alumnos
                        ListaAlumnos.SetCuota(float.Parse(CInterfaz.PedirDato("Cuota General")));
                        break;

                    case 2:  //Conocer Cuota General para alumnos.
                        CInterfaz.MostrarInfo(Convert.ToString(ListaAlumnos.GetCuota()));
                        break;

                    case 3:  //Agregar un Alumno
                        AuxLeg = Convert.ToUInt64(CInterfaz.PedirDato("Legajo del alumno"));
                        AuxApe = CInterfaz.PedirDato("Apellidos del alumno");
                        AuxNom = CInterfaz.PedirDato("Nombres del alumno");
                        float AuxBeca = Convert.ToSingle(CInterfaz.PedirDato("Beca del alumno"));

                        if (!ListaAlumnos.CrearAlumno(AuxLeg, AuxApe, AuxNom, AuxBeca))
                        {
                            CInterfaz.MostrarInfo("Alumno no agregado. Legajo Preexistente");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Alumno agregado con exito");
                        }
                        break;

                    case 4:  //Mostrar datos de un Alumno
                        AuxLeg = ulong.Parse(CInterfaz.PedirDato("Legajo del alumno a buscar"));
                        CInterfaz.MostrarInfo(ListaAlumnos.DarDatos(AuxLeg));
                        break;

                    case 5:  //Listar los datos de todos los Alumnos
                        CInterfaz.MostrarInfo(ListaAlumnos.DarDatos());
                        break;

                    case 6:  //Ordenar por legajo los datos de todos los Alumnos
                        ListaAlumnos.Ordenar();
                        CInterfaz.MostrarInfo("Lista de Alumnos Ordenada");
                        break;

                    case 7:  //Remover un Alumno
                        AuxLeg = Convert.ToUInt64(CInterfaz.PedirDato("Legajo"));
                        if (!ListaAlumnos.EliminarAlumno(AuxLeg))
                        {
                            CInterfaz.MostrarInfo("Alumno Inexistente");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Alumno Removido");
                        }
                        break;

                    case 8:  //Agregar un docente
                        AuxLeg = ulong.Parse(CInterfaz.PedirDato("Legajo del docente"));
                        AuxNom = CInterfaz.PedirDato("Nombre del docente");
                        AuxApe = CInterfaz.PedirDato("Apellido del docente");

                        if (!ListaDocentes.CrearDocente(AuxLeg, AuxNom, AuxApe))
                        {
                            CInterfaz.MostrarInfo("Docente no agregado. Legajo preexistente");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Docente agregado con exito");
                        }
                        break;

                    case 9:  //Mostrar datos de un docente
                        AuxLeg = ulong.Parse(CInterfaz.PedirDato("Numero de legajo de docente a buscar"));
                        CInterfaz.MostrarInfo(ListaDocentes.DarDatos(AuxLeg));
                        break;

                    case 10: //Listar datos de todos los docentes
                        CInterfaz.MostrarInfo("\nLista de docentes\n" + ListaDocentes.DarDatos());
                        break;

                    case 11: //Ordenar por legajo los docentes
                        ListaDocentes.OrdenarDocentes();
                        CInterfaz.MostrarInfo("\nLista de docentes ordenada");
                        break;

                    case 12: //Remover un docente
                        AuxLeg = ulong.Parse(CInterfaz.PedirDato("Numero de codigo del docente a eliminar"));
                        if (ListaDocentes.EliminarDocente(AuxLeg) == true)
                        {
                            CInterfaz.MostrarInfo("Docente eliminado");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Docente no se encontraba en la lista");
                        }
                        break;

                    case 13: //Agregar una materia
                        AuxNomMat = CInterfaz.PedirDato("Nombre de la materia");
                        if (ListaMaterias.BuscaMateria(AuxNomMat) == null)
                        {
                            AuxDia = CInterfaz.PedirDato("Dia de la semana en que se dicta la materia");
                            AuxHorIni = CInterfaz.PedirDato("Hora de inicio");
                            AuxHorFin = CInterfaz.PedirDato("Hora de finalizacion");
                            AuxLeg = ulong.Parse(CInterfaz.PedirDato("Legajo del docente que dictará la materia"));
                            AuxHorario = "desde las " + AuxHorIni + "hs hasta las " + AuxHorFin + "hs";
                            
                            ListaMaterias.CrearMateria(AuxNomMat, AuxDia, AuxHorario);
                            if (!ListaMaterias.AsignarDocente(AuxLeg, AuxNomMat, ListaDocentes))
                            {
                                CInterfaz.MostrarInfo("La materia se ha creado, pero no se ha podido asignar el docente, " +
                                    "ya que su legajo no existe");
                            }
                            else
                            {
                                CInterfaz.MostrarInfo("Materia creada exitosamente");
                            }
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("\n\nLa materia ya existe\n");
                        }

                        break;

                    case 14: //Agregar un alumno a una materia
                        AuxLeg = ulong.Parse(CInterfaz.PedirDato("Legajo del alumno a agregar"));
                        AuxNomMat = CInterfaz.PedirDato("Materia a la que se lo desea agregar");
                        if (!ListaMaterias.InscribirAlumno (AuxNomMat, AuxLeg, ListaAlumnos))
                        {
                            CInterfaz.MostrarInfo("\n\nNo se ha podido agregar el alumno a la materia");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("\n\nAlumno agregado exitosamente");
                        }
                        break;

                    case 15: //Agregar un docente a una materia
                        AuxNomMat = CInterfaz.PedirDato("Materia a la que se lo desea agregar");
                        AuxLeg = ulong.Parse(CInterfaz.PedirDato("Legajo del docente a agregar"));
                        if (!ListaMaterias.AsignarDocente(AuxLeg, AuxNomMat, ListaDocentes))
                        {
                            CInterfaz.MostrarInfo("No se ha podido asignar el docente a la materia");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Docente asignado correctamente");
                        }
                        break;

                    case 16: //Mostrar datos de una materia
                        AuxNomMat = CInterfaz.PedirDato("\nNombre de la materia a buscar");
                        CInterfaz.MostrarInfo(ListaMaterias.DarDatos(AuxNomMat, ListaAlumnos, ListaDocentes));

                        break;

                    case 17: //Listar los datos de todas las materias
                        CInterfaz.MostrarInfo(ListaMaterias.DarDatos(ListaAlumnos, ListaDocentes));
                        break;

                    case 18: //Ordenar alfabeticamente todas las materias
                        ListaMaterias.OrdenarMaterias();
                        break;

                    case 19: //Remover una materia
                        AuxNomMat = CInterfaz.PedirDato("\nNombre de la materia a eliminar");
                        if (!ListaMaterias.EliminarMateria(AuxNomMat, ListaAlumnos, ListaDocentes))
                        {
                            CInterfaz.MostrarInfo("\nLa materia no se encuentra en la lista");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("\nMateria eliminada exitosamente");
                        }
                        break;

                    case 20:  //Salir
                        break;

                    default:
                        CInterfaz.MostrarInfo("Opción inválida");
                        break;
                }
            } while (Opcion != 20);
        }
    }
}

