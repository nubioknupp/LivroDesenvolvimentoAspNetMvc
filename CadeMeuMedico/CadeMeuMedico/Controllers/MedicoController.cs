using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class MedicoController : Controller
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        public ActionResult Index()
        {
            var medicos = db.Medico.Include("Cidade").Include("Especialidade").ToList();
            return View(medicos);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Nome");
            ViewBag.IdEspecialidade = new SelectList(db.Especialidade,
                                                      "IdEspecialidade", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Nome", medico.IdCidade);
            ViewBag.IdEspecialidade = new SelectList(db.Especialidade,
                                                      "IdEspecialidade", "Nome", medico.IdEspecialidade);
            return View(medico);
        }

        public ActionResult Editar(long id)
        {
            var medico = db.Medico.Find(id);

            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Nome", medico.IdCidade);
            ViewBag.IdEspecialidade = new SelectList(db.Especialidade,
                                                      "IdEspecialidade", "Nome", medico.IdEspecialidade);
            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Nome", medico.IdCidade);
            ViewBag.IdEspecialidade = new SelectList(db.Especialidade,
                                                      "IdEspecialidade", "Nome", medico.IdEspecialidade);
            return View(medico);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                var medico = db.Medico.Find(id);
                db.Medico.Remove(medico);
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
