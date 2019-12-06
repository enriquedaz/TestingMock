using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core1;
using Moq;
using System.Collections.Generic;

namespace CoreTest
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void ValidarToken_test()
        {
            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(x => x.Validar(It.IsAny<string>()));

            Admin admin = new Admin("jose","123", mockServicio.Object);
            Assert.IsNotNull(admin);
        }

        [TestMethod]
        public void GetAlumnosCount_test()
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos.Add(new Alumno() { CI = 5, Nombre = "Daniel" });
            ListaAlumnos.Add(new Alumno() { CI = 6, Nombre = "Pedro" });

            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(g => g.GetAlumnos()).Returns(ListaAlumnos);
            Admin admin = new Admin("Jose", "123", mockServicio.Object);
            Assert.AreEqual(2, admin.GetNotas().Count);
        }

        [TestMethod]
        public void GetNotas_test()
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos.Add(new Alumno() { CI = 6, Nombre = "Juan" });
            ListaAlumnos.Add(new Alumno() { CI = 7, Nombre = "Maria" });

            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(g => g.GetAlumnos()).Returns(ListaAlumnos);
            mockServicio.Setup(n =>n.GetNota(It.IsAny<int>())).Returns(50);
            Admin admin = new Admin("aa", "111", mockServicio.Object);
            Assert.AreEqual(50, admin.GetNotas()[0].Nota);
        }

        [TestMethod]
        public void GetNotaCero_test()
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos.Add(new Alumno() { CI = 500, Nombre = "Maria" });
            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(g => g.GetAlumnos()).Returns(ListaAlumnos);
            mockServicio.Setup(n => n.GetNota(It.IsAny<int>())).Returns(0);
            Admin admin = new Admin("Damian", "007", mockServicio.Object);
            Assert.AreEqual(0, admin.GetNotas()[0].Nota);
        }

        [TestMethod]
        public void GetEstado_test()
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos.Add(new Alumno() { CI = 500, Nombre = "Alberto", Nota = 39 });
            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(g => g.GetAlumnos()).Returns(ListaAlumnos);
            mockServicio.Setup(e => e.GetEstadoNota(It.IsAny<int>())).Returns("Aprovado");
            Admin admin = new Admin("Damian", "007", mockServicio.Object);
            Assert.AreEqual("Aprovado", admin.GetEstadoNota()[0].estadoNota);
        }
    }
}
