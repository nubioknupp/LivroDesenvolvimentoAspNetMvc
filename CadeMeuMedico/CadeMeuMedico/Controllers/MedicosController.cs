using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        public ActionResult Index()
        {
            var medicos = db.Medicos.Include("Cidades").Include("Especialidades").ToList();
            return View(medicos);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IdCidade = new SelectList(db.Cidades, "IdCidade", "Nome");
            ViewBag.IdEspecialidade = new SelectList(db.Especialidades,
                                                      "IdEspecialidade", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(db.Cidades, "IdCidade", "Nome", medico.IdCidade);
            ViewBag.IdEspecialidade = new SelectList(db.Especialidades,
                                                      "IdEspecialidade", "Nome", medico.IdEspecialidade);
            return View(medico);
        }

        public ActionResult Editar(long id)
        {
            Medicos medico = db.Medicos.Find(id);

            ViewBag.IdCidade = new SelectList(db.Cidades, "IdCidade", "Nome", medico.IdCidade);
            ViewBag.IdEspecialidade = new SelectList(db.Especialidades,
                                                      "IdEspecialidade", "Nome", medico.IdEspecialidade);
            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(db.Cidades, "IdCidade", "Nome", medico.IdCidade);
            ViewBag.IdEspecialidade = new SelectList(db.Especialidades,
                                                      "IdEspecialidade", "Nome", medico.IdEspecialidade);
            return View(medico);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Medicos medico = db.Medicos.Find(id);
                db.Medicos.Remove(medico);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch (Exception)
            {
                return Boolean.FalseString;
            }

        }
    }
}
