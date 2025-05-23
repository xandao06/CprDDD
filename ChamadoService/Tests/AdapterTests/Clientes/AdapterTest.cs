// AdapterTests/ClienteIntegrationTests.cs
using Application;
using Application.Cliente.Dto;
using Application.Cliente.Ports;
using Application.Cliente.Requests;
using Data;
using Data.Cliente;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AdapterTests
{
    public class ClienteIntegrationTests
    {
        private CPRDbContext _context;
        private IClienteRepository _repo;
        private IClienteManager _manager;

        [SetUp]
        public void Setup()
        {
            var opts = new DbContextOptionsBuilder<CPRDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new CPRDbContext(opts);
            _repo = new ClienteRepository(_context);
            _manager = new ClienteManager(_repo);
        }

        [Test]
        public async Task CriarCliente_Valido_DeveRetornarSucessoEGravarNoBanco()
        {
            var createDto = new CriarClienteDto
            {
                Contrato = "ABC123",
                Endereco = "Rua A, 123",
                Bairro = "Centro",
                CEP = "01001000",
                Telefone = "(11)99999-0000",
                EmpresaInfo = new EmpresaInfoDto
                {
                    RazaoSocial = "MinhaRazao",
                    Fantasia = "MeuFantasia",
                    CNPJ = "00000000000191",
                    InscricaoEstadual = "123456"
                }
            };

            var req = new CriarClienteRequest { ClienteData = createDto };
            var response = await _manager.CriarCliente(req);

            Assert.That(response.Success, Is.True);
            Assert.That(response.ClienteData.Id, Is.GreaterThan(0));

            var ent = await _context.Clientes.FindAsync(response.ClienteData.Id);
            Assert.That(ent, Is.Not.Null);
            Assert.That(ent.Contrato, Is.EqualTo("ABC123"));
            Assert.That(ent.ClienteInfo.EmpresaInfo.CNPJ, Is.EqualTo("00000000000191"));
        }

        [Test]
        public async Task CriarCliente_SemTipo_DeveRetornarMissingRequiredInformation()
        {
            var createDto = new CriarClienteDto
            {
                Contrato = "XYZ",
                Endereco = "Rua B",
                Bairro = "Bairro B",
                CEP = "02002000",
                Telefone = "11988887777"
                // sem EmpresaInfo e sem PessoaFisicaInfo
            };

            var req = new CriarClienteRequest { ClienteData = createDto };
            var response = await _manager.CriarCliente(req);

            Assert.That(response.Success, Is.False);
            Assert.That(response.ErrorCode, Is.EqualTo(ErrorCodes.MISSING_REQUIRED_INFORMATION));
        }
    }
}
