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
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult ResultadoEstudiantes()
        {
            using (EstudianteEntities Alumnos = new EstudianteEntities())
            {
                var ListaEstudiantes = Alumnos.TblNotasEstudiante.ToList();

                return View(ListaEstudiantes);

            }
        }
        public ActionResult Resultado(string Nombre, double lab1, double lab2, double lab3, double par1, double par2, double par3)
        {

            using (EstudianteEntities Estudiante = new EstudianteEntities())
            {
                TblNotasEstudiante NuevoEstudiante = new TblNotasEstudiante();
                NuevoEstudiante.Nombre = Nombre;
                NuevoEstudiante.lab1 = (decimal?)lab1;
                NuevoEstudiante.lab2 = (decimal?)lab2;
                NuevoEstudiante.lab3 = (decimal?)lab3;
                NuevoEstudiante.par1 = (decimal?)par1;
                NuevoEstudiante.par2 = (decimal?)par2;
                NuevoEstudiante.par3 = (decimal?)par3;
                Estudiante.TblNotasEstudiante.Add(NuevoEstudiante);
                Estudiante.SaveChanges();

            }

            double LaboratorioPorcentaje = 0.4;
                double ParcialPorcentaje = 0.6;

                ViewBag.total1 = (lab1 * LaboratorioPorcentaje) + (par1 * ParcialPorcentaje);
                ViewBag.total2 = (lab2 * LaboratorioPorcentaje) + (par2 * ParcialPorcentaje);
                ViewBag.total3 = (lab3 * LaboratorioPorcentaje) + (par3 * ParcialPorcentaje);



                ViewBag.Nombre = Nombre;
                ViewBag.lab1 = lab1;
                ViewBag.lab2 = lab2;
                ViewBag.lab3 = lab3;
                ViewBag.par1 = par1;
                ViewBag.par2 = par2;
                ViewBag.par3 = par3;
                return View();
            

        }
    }

}     
    
