using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCore_Email.Models;
using AspCore_Email.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_Email.Controllers
{
    public class EmailSenderController : Controller
    {
        private readonly IEmailSender _emailSender;
        public EmailSenderController(IEmailSender emailSender, IHostingEnvironment env)
        {
            _emailSender = emailSender;
        }
        public IActionResult EnviarEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnviarEmail(EmailModel email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(email.Destino, email.Assunto, email.Mensagem).GetAwaiter();
                    return RedirectToAction("EmailEnviado");
                }
                catch (Exception)
                {
                    return RedirectToAction("EmailFalhou");
                }
            }
            return View(email);
        }
        public async Task TesteEnvioEmail(string email, string assunto, string mensagem)
        {
            try
            {
                //email destino, assunto do email, mensagem a enviar
                await _emailSender.SendEmailAsync(email, assunto, mensagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult EmailEnviado()
        {
            return View();
        }
        public ActionResult EmailFalhou()
        {
            return View();
        }
    }
}