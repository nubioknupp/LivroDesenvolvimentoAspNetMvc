using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadeController : Controller
    {

        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        public ActionResult Index()
        {
            var especialidade = db.Especialidade.ToList();
            return View(especialidade);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Especialidade.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidade);
        }

        public ActionResult Editar(long id)
        {
            var especialidade = db.Especialidade.Find(id);
            return View(especialidade);
        }

        [HttpPost]

        public ActionResult Editar(Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidade);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                var especialidade = db.Especialidade.Find(id);
                db.Especialidade.Remove(especialidade);
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
