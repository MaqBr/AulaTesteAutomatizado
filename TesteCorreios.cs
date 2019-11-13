using System;
using System.IO;
using Xunit;
using Microsoft.Extensions.Configuration;
using AulaTesteAutomatizado.Config;

namespace AulaTesteAutomatizado
{
    public class TesteCorreios
    {

        private IConfiguration _configuration;
        public TesteCorreios()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();
        }

        [Theory]
        [InlineData(Browser.Chrome, "MT", "Cuiabá", "Boa esperança")]
        public void ConsultarPorBairro(Browser browser, string UF, string cidade, string bairro)
        {
            TelaCorreios tela =
                new TelaCorreios(_configuration, browser);

            tela.CarregarPagina();

            tela.PreencherUF(UF);
            tela.PreencherLocalidade(cidade);
            tela.PreencherBairro(bairro);
            tela.ProcessarConsulta();

            tela.Fechar();

            //Assert.Equal(valorKm, resultado);
        }
    }
}
