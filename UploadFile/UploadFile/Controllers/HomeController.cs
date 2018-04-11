using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadFile.Models;

namespace UploadFile.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Remessa arq)
        {
            try
            {
                string nomeArquivo = "";
                string arquivoEnviados = "";

                foreach (var item in arq.Arquivos)
                {
                    if(item.ContentLength > 0)
                    {
                        nomeArquivo = Path.GetFileName(item.FileName);
                        var caminho = Path.Combine(Server.MapPath("~/Imagens"), nomeArquivo);
                        item.SaveAs(caminho);
                    }
                    arquivoEnviados = arquivoEnviados + "," + nomeArquivo;
                }
                ViewBag.Mensagem = "Arquivos enviados: " + arquivoEnviados + "com sucesso.";
            }
            catch (Exception ex)
            {


                ViewBag.Mensagem = "Erro:"+ex.Message;
            }

            return View();
        }
    }
}