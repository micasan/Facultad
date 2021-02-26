using System;
using System.Collections;

namespace Facultad
{
    class CMateria: IComparable
    {
        private string Nombre;
        private string Dia;
        private string Horario;
        private ArrayList LegDocentes; //Contiene numeros de legajos de los docentes
        private ArrayList LegAlumns; //Contiene los numeros de legajos de los alumnos


        //Constructores
        public CMateria()
        {
            this.Nombre = "Sin asignar";
            this.Dia = "Sin asignar";
            this.Horario = "Sin asignar";
            this.LegAlumns = new ArrayList();
            this.LegDocentes = new ArrayList();
        }
        public CMateria(string Nom, string Di, string Hor)
        {
            this.Nombre = Nom;
            this.Dia = Di;
            this.Horario = Hor;
            this.LegAlumns = new ArrayList();
            this.LegDocentes = new ArrayList();
        }

        //Setters
        public void SetNombre(string NomMat)
        { this.Nombre = NomMat; }
        public void SetDia(string Di)
        { this.Dia = Di;  }
        public void SetHorario(string Hor)
        { this.Horario = Hor; }

        //Getters
        public string GetNombre ()
        { return this.Nombre;  }
        public string GetDia ()
        { return this.Dia; }
        public string GetHorario ()
        { return this.Horario;  }

        public string DarDatos (CAlumnos ListaAlums, CDocentes ListaDocs)
        {
            string ret = "\n\nNombre materia: " + this.Nombre;
            ret += "\nDia " + this.Dia + ", horario " + this.Horario;
            ret += "\nDictada por: " + this.MostrarDocente(ListaDocs);
            ret += "\nAlumnos que la cursan:\n" + this.MostrarAlumnos(ListaAlums);
            return ret;
        }

        public bool AsignarDocente (ulong LegDoc, CDocentes ListaDocs)
        {
            CDocente Aux = ListaDocs.BuscaDocente(LegDoc);
            if (Aux != null)
            {
                Aux.AgregarMateria(this.Nombre);
                this.LegDocentes.Add(LegDoc);
                return true;
            }
            return false;
        }

        public bool InscribirAlumno (ulong LegAlum, CAlumnos ListaAlums)
        {
            CAlumno AuxAlum = ListaAlums.BuscarAlumno(LegAlum);
            if (AuxAlum != null)
            {

                this.LegAlumns.Add(LegAlum);
                AuxAlum.AgregarMateria(this.Nombre);
                return true;
            }
            return false;
            
        }

        public bool BuscarEntreAlumnos (ulong LegAlum, CAlumnos ListaAlums)
        {
            CAlumno AuxAlum = ListaAlums.BuscarAlumno(LegAlum);
            foreach (ulong LegAux in this.LegAlumns)
            {
                string NomAux = ListaAlums.BuscarAlumno(LegAux).GetNombres();
                if (NomAux == AuxAlum.GetNombres())
                {
                    return true;
                }
            }
            return false;
        }

        public bool BuscarEntreDocentes (ulong LegDoc, CDocentes ListaDocs)
        {
            CDocente AuxDoc = ListaDocs.BuscaDocente(LegDoc);
            foreach (ulong LegAux in this.LegDocentes)
            {
                string NomAux = ListaDocs.BuscaDocente(LegAux).GetNombres();
                if (NomAux == AuxDoc.GetNombres())
                {
                    return true;
                }
            }
            return false;
        }

        public string MostrarDocente (CDocentes ListaDocs)
        {
            string Texto = "";
            CDocente AuxDoc;
            if (this.LegDocentes == null)
            {
                return "No hay docente asignado";
            }
            foreach(ulong Leg in this.LegDocentes)
            {
                AuxDoc = ListaDocs.BuscaDocente(Leg);
                Texto += AuxDoc.GetNombres() + " " + AuxDoc.GetApellidos();
            }
            return Texto;
        }

        public string MostrarAlumnos (CAlumnos ListaAlums)
        {
            string Texto = "";
            CAlumno AuxAlum;
            if (this.LegAlumns == null)
            {
                return "No hay alumnos asignados";
            }
            foreach (ulong Leg in this.LegAlumns)
            {
                AuxAlum = ListaAlums.BuscarAlumno(Leg);
                Texto += "\n" + AuxAlum.GetNombres() + " " + AuxAlum.GetApellidos();
            }
            return Texto;
        }

        public int CantAlumnos ()
        {
            return this.LegAlumns.Count;
        }

        public int CantDocentes()
        {
            return this.LegDocentes.Count;
        }

        public void EliminarPersonas (CAlumnos ListaAlums, CDocentes ListaDocs)
        {
            CAlumno AuxAlum = null;
            CDocente AuxDoc = null;

            //Elimino el nombre de la materia de los datos de todos los alumnos anotados
            for (int I=0; I<this.LegAlumns.Count; I++)
            {
                AuxAlum = ListaAlums.BuscarAlumno((ulong)LegAlumns[I]);
                AuxAlum.EliminarMateria(this.Nombre);
            }

            //La elimino de los docentes
            for (int I=0; I<this.LegDocentes.Count; I++)
            {
                AuxDoc = ListaDocs.BuscaDocente((ulong)LegDocentes[I]);
                AuxDoc.EliminarMateria(this.Nombre);
            }
        }

        public int CompareTo(object obj)
        {
          if(obj is CMateria)
            {
                return this.GetNombre().CompareTo(((CMateria)obj).GetNombre());
            }
            return int.MaxValue;
        }

    }
}
