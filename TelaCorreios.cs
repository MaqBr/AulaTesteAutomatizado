using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AulaTesteAutomatizado.Config;

namespace AulaTesteAutomatizado
{
    public class TelaCorreios
    {
        private IConfiguration _configuration;
        private Browser _browser;
        private IWebDriver _driver;

        public TelaCorreios(
            IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string caminhoDriver = null;
            if (browser == Browser.Firefox)
            {
                caminhoDriver =
                    _configuration.GetSection("Selenium:CaminhoDriverFirefox").Value;
            }
            else if (browser == Browser.Chrome)
            {
                caminhoDriver =
                    _configuration.GetSection("Selenium:CaminhoDriverChrome").Value;
            }

            _driver = WebDriverFactory.CreateWebDriver(
                browser, caminhoDriver, false);
        }
        public void CarregarPagina()
        {
            _driver.LoadPage(
                TimeSpan.FromSeconds(Convert.ToInt32(
                    _configuration.GetSection("Selenium:Timeout").Value)),
                _configuration.GetSection("Selenium:UrlSiteCorreios").Value);
        }

        public void PreencherUF(string UF)
        {
            _driver.SetText(
                By.Name("UF"), UF);
        }

        public void PreencherLocalidade(string localidade)
        {
            _driver.SetText(
                By.Name("Localidade"), localidade);
        }

        public void PreencherBairro(string bairro)
        {
            _driver.SetText(
                By.Name("Bairro"), bairro);
        }

        public void ProcessarConsulta()
        {
            IWebElement webElement = _driver.FindElement(By.ClassName("btn2"));
            webElement.Click();
        }

        public string ObterBairroLocalizadoPorCEP(string CEP)
        {
            return 
                _driver.GetText(By.CssSelector(CEP));
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}