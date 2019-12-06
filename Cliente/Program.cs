using Core1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            IServicio serv = new Servicio();
            try
            {
                Console.WriteLine("------------------------------");

                Admin admin = new Admin("Damian", "007", serv);

                List<Alumno> ListaNota = admin.GetNotas();

                foreach (var item in ListaNota)
                {
                    Console.WriteLine("CI:{0} - Nombre:{1} - Nota:{2}",
                    item.CI, item.Nombre, item.Nota);
                }

                Console.WriteLine("------------------------------");

                foreach (var item in ListaNota)
                {
                    Console.WriteLine("CI:{0} - Nombre:{1} - Nota:{2} - Estado:{3}",
                    item.CI, item.Nombre, item.Nota, item.estadoNota);

                }
                Console.WriteLine("------------------------------");


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();

        }
    }
}
