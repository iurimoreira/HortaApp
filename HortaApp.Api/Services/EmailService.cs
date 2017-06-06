using System;
using System.Configuration;
using System.Net.Mail;

namespace HortaApp.Api.Services
{
    public class GmailEmailService : SmtpClient
    {

        public string UserName { get; set; }

        public GmailEmailService() : base(ConfigurationManager.AppSettings["GmailHost"], Int32.Parse(ConfigurationManager.AppSettings["GmailPort"]))
        {
            //pega os valores do web.config 
            this.UserName = ConfigurationManager.AppSettings["GmailUserName"];
            this.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["GmailSsl"]);
            this.UseDefaultCredentials = false;
            this.Credentials = new System.Net.NetworkCredential(this.UserName, ConfigurationManager.AppSettings["GmailPassword"]);
        }
    }
}