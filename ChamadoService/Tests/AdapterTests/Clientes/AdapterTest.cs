using Application;
using Application.Cliente.Dto;
using Application.Cliente.Ports;
using Application.Cliente.Requests;
using Data;
using Data.Cliente;
using Domain.Entities;
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
            // monta um DbContext “in memory”
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
            // 1) cria o Dto de entrada sem Id
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
                // não preencher PessoaFisicaInfo
            };

            var request = new CriarClienteRequest { CriarClienteData = createDto };

            // 2) executa o manager
            var response = await _manager.CriarCliente(request);

            // 3) checa o resultado
            Assert.That(response.Success, Is.True, "esperava Success=true");
            Assert.That(response.ClienteData.Id, Is.GreaterThan(0), "esperava Id gerado >0");

            // 4) confere no contexto InMemory
            var entidade = await _context.Clientes.FindAsync(response.ClienteData.Id);
            Assert.That(entidade, Is.Not.Null, "entidade não foi salva");
            Assert.That(entidade.Contrato, Is.EqualTo("ABC123"));
            Assert.That(entidade.ClienteInfo.EmpresaInfo.CNPJ, Is.EqualTo("00000000000191"));
        }

        [Test]
        public async Task CriarCliente_SemTipo_DeveRetornarMissingRequiredInformation()
        {
            // Dto sem EmpresaInfo e sem PessoaFisicaInfo
            var createDto = new CriarClienteDto
            {
                Contrato = "XYZ",
                Endereco = "Rua B",
                Bairro = "Bairro B",
                CEP = "02002000",
                Telefone = "11988887777"
            };

            var request = new CriarClienteRequest { CriarClienteData = createDto };
            var response = await _manager.CriarCliente(request);

            Assert.That(response.Success, Is.False);
            Assert.That(response.ErrorCode, Is.EqualTo(ErrorCodes.MISSING_REQUIRED_INFORMATION));
        }

        // Você pode adicionar também testes para:
        //  - passar *ambos* EmpresaInfo e PessoaFisicaInfo → ErrorCodes.INVALID_CLIENT_TYPE
        //  - valores inválidos de CEP ou Telefone → ErrorCodes.MISSING_REQUIRED_INFORMATION
    }
}
