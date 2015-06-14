using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class CidadeController : Controller
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        public ActionResult Index()
        {
            var cidade = db.Cidade.ToList();
            return View(cidade);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        public ActionResult Adicionar(Cidade cidade)
        {
            return View();
        }
             
    }
}
