using AutoMapper;
using NUnit.Framework;

namespace TeAjudo.Models.Infraestrutura.Testes
{
    [TestFixture]
    public class AutoMapperTeste
    {
        [Test]
        public void MapeamentoEntidades_TestarMapeamentoEntidades_ResultadoCorreto()
        {
            Infraestrutura.Mapeamento.ConfiguracaoAutoMapper.Configurar();
            Mapper.AssertConfigurationIsValid();
        }
    }
}