using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core1
{
    public class Admin
    {
        List<Alumno> ListAlumnos;
        string token;
        IServicio serv;

        public Admin(string user, string password, IServicio serv)
        {
            if (user=="Damian" && password=="007")
            {
                token = "Token valido";
            }
            serv.Validar(token);
            this.serv = serv;
        }
        public List<Alumno> GetNotas()
        {
            
            ListAlumnos = serv.GetAlumnos();
            foreach (var alumno in ListAlumnos)
            {
                alumno.Nota = serv.GetNota(alumno.CI);
            }
            return ListAlumnos;
        }

        public List<Alumno> GetEstadoNota()
        {
            ListAlumnos = serv.GetAlumnos();
            foreach (var alumno in ListAlumnos)
            {
                alumno.estadoNota = serv.GetEstadoNota(alumno.Nota);
            }
            return ListAlumnos;
        }
    }
}
