using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using DotNetEnv;

class Program
{
    static void Main(string[] args)
    {
        // Carrega as variáveis de ambiente do arquivo .env
        Env.Load();

        IWebDriver driver = new ChromeDriver();

        var urlOfertasKabum = "https://www.kabum.com.br/ofertas/ofertadodia?pagina=1";

        try
        {
            driver.Navigate().GoToUrl(urlOfertasKabum);

            System.Threading.Thread.Sleep(5000);

            IReadOnlyList<IWebElement> ofertaElements = driver.FindElements(By.XPath("//span[@class='sc-d79c9c3f-0 nlmfp sc-cdc9b13f-16 eHyEuD nameCard']"));
            IReadOnlyList<IWebElement> precoDeElements = driver.FindElements(By.XPath("//span[@class='sc-620f2d27-1 bksuMM oldPriceCard']"));
            IReadOnlyList<IWebElement> precoPorElements = driver.FindElements(By.XPath("//span[@class='sc-620f2d27-2 bMHwXA priceCard']"));

            if (!(ofertaElements.Count == precoDeElements.Count && ofertaElements.Count == precoPorElements.Count))
            {
                Console.WriteLine("O número de elementos encontrados não é consistente.");
            }

            string emailBody = "";

            for (int i = 0; i < ofertaElements.Count; i++)
            {
                string ofertaDoDia = ofertaElements[i].Text;
                string precoDe = precoDeElements[i].Text;
                string precoPor = precoPorElements[i].Text;

                emailBody += "Oferta do Dia: " + ofertaDoDia + "\n";
                emailBody += "Preço Antigo: " + precoDe + "\n";
                emailBody += "Preço Atual: " + precoPor + "\n\n";
            }

            EnviarEmail(emailBody);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message);
        }
        finally
        {
            driver.Quit();
        }
    }

    static void EnviarEmail(string body)
    {
        string remetente = Environment.GetEnvironmentVariable("REMETENTE");
        string senha = Environment.GetEnvironmentVariable("SENHA");
        string destinatario = Environment.GetEnvironmentVariable("DESTINATARIO");
        string assunto = "Ofertas do Dia Site Kabum";

        using (MailMessage mensagem = new MailMessage(remetente, destinatario, assunto, body))
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(remetente, senha);
                client.EnableSsl = true;

                try
                {
                    client.Send(mensagem);
                    Console.WriteLine("E-mail enviado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao enviar o e-mail: " + ex.Message);
                }
            }
        }
    }
}
