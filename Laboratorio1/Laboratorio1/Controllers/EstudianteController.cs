using Laboratorio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio1.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index(string Nombre, int lab1)
        {

            using (EstudianteEntities Estudiante = new EstudianteEntities())
            {

                TblNotasEstudiante tbl = new TblNotasEstudiante();
                tbl.Nombre = Nombre;
                tbl.lab1 = lab1;
                //tbl.lab2 = Lab2;
                //tbl.lab3 = Lab3;
                //tbl.par1 = Par1;
                //tbl.par2 = Par2;
                //tbl.par3 = Par3;
                Estudiante.TblNotasEstudiante.Add(tbl);
                Estudiante.SaveChanges();
                return View();
            }



        }
       public ActionResult ResultadoEstudiantes()
        {
            using ( EstudianteEntities Alumnos = new EstudianteEntities())
            {
                var ListaEstudiantes = Alumnos.TblNotasEstudiante.ToList();

                return View(ListaEstudiantes);
                 
            }
        }

          
    }
}