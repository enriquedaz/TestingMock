using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core1
{
    public class Servicio : IServicio
    {
        Random rnd = new Random();
        public List<Alumno> GetAlumnos()
        {
            List<Alumno> result = new List<Alumno>();
            result.Add(new Alumno() { CI = 1, Nombre = "Juan", Nota = 89 });
            result.Add(new Alumno() { CI = 2, Nombre = "Pedro", Nota = 78 });
            result.Add(new Alumno() { CI = 3, Nombre = "Maria", Nota = 45});
            result.Add(new Alumno() { CI = 4, Nombre = "Jose", Nota = 51 });
            result.Add(new Alumno() { CI = 5, Nombre = "Raul", Nota = 59 });

            return result;
        }

     
        public string GetEstadoNota(int nota)
        {
            String Estado = "Aprovado";
            if (nota < 51)
            {
                Estado = "Reprovado";
            }
            return Estado;
        }

        public int GetNota(int CI)
        {
            int nota = rnd.Next(1, 100);
            return nota;
        }

        public void Validar(string token)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new Exception("token invalido");
            }
        }
    }
}
