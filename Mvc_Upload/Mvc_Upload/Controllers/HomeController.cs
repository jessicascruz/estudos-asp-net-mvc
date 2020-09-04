using Mvc_Upload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Upload.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Index(Remessa arq)
        {
            try
            {
                string nomeArquivo = "";
                string arquivoEnviado = "";
                foreach (var arquivo in arq.Arquivos)
                {
                    if(arquivo.ContentLength > 0)
                    {
                        nomeArquivo = Path.GetFileName(arquivo.FileName);
                        var caminho = Path.Combine(Server.MapPath("~/Imagens"), nomeArquivo);
                        arquivo.SaveAs(caminho);
                    }

                    arquivoEnviado = arquivoEnviado + "," + nomeArquivo;
                }
                ViewBag.Mensagem = "Arquivos :" + arquivoEnviado + ", com sucesso.";
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Erro :" + ex.Message;
            }
            return View();
        }
    }
}