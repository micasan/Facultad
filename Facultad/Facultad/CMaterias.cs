using System;
using System.Collections;

namespace Facultad
{
    class CMaterias
    {
        private ArrayList ListaMaterias;

        public CMaterias ()
        {
            this.ListaMaterias = new ArrayList();
        }

        public CMateria BuscaMateria(string NomMat)
        {
            foreach (CMateria Aux in this.ListaMaterias)
            {
                if (Aux.GetNombre() == NomMat) return Aux;
            }
            return null;
        }

        public bool CrearMateria (string Nom, string Dia, string Hora)
        {
            if (this.BuscaMateria(Nom) == null)
            {
                this.ListaMaterias.Add(new CMateria(Nom, Dia, Hora));
                return true;
            }
            return false;
        }

        public string DarDatos(CAlumnos ListaAlums, CDocentes ListaDocs) //Dar datos de todas las materias
        {
            string Ret = "";
            foreach (CMateria Aux in this.ListaMaterias)
            {
                Ret += Aux.DarDatos(ListaAlums, ListaDocs);
            }
            return Ret;
        }

        public string DarDatos (string Nom, CAlumnos ListaAlums, CDocentes ListaDocs) //Dar datos de una materia en particular
        {
            CMateria AuxMat = this.BuscaMateria(Nom);
            if (AuxMat != null) return AuxMat.DarDatos(ListaAlums, ListaDocs);
            return "Materia no se encuentra en la lista";
        }

        public bool EliminarMateria (string Nom, CAlumnos ListaAlums, CDocentes ListaDocs)
        {
            CMateria AuxMat = this.BuscaMateria(Nom);
            CAlumno AuxAlum = null;
            CDocente AuxDoc = null;
            if (AuxMat != null)
            {
                AuxMat.EliminarPersonas(ListaAlums, ListaDocs);
                this.ListaMaterias.Remove(AuxMat);
                return true;
            }
            return false;
        }

        public bool AsignarDocente (ulong LegDoc, string NomMat, CDocentes ListaDocs)
        {
            CMateria AuxMat = this.BuscaMateria(NomMat);
            CDocente AuxDoc = ListaDocs.BuscaDocente(LegDoc);
            if (AuxMat != null)
            {
                if (AuxDoc != null)
                {
                    if (!AuxMat.BuscarEntreDocentes(LegDoc, ListaDocs))
                    {
                        AuxMat.AsignarDocente(LegDoc, ListaDocs);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool InscribirAlumno (string NomMat, ulong LegAlum, CAlumnos ListaAlums)
        {
            CMateria AuxMat = this.BuscaMateria(NomMat);
            if (AuxMat != null)
            {
                if (!AuxMat.BuscarEntreAlumnos(LegAlum, ListaAlums))
                {
                    if (AuxMat.InscribirAlumno(LegAlum, ListaAlums))
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        public void OrdenarMaterias ()
        {
            this.ListaMaterias.Sort();
        }
    }
}
