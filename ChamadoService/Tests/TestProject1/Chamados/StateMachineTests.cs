using Domain.DomainEntities;
using Domain.Enums;
using NUnit.Framework;

namespace DomainTests.Chamados
{
    public class Tests
    {
        [SetUp]

        public void Setup()
        {
        }

        [Test]
        public void StatusSempreIniciaComStatusCriado()
        {
            var chamado = new Chamado();

            Assert.That(chamado.CurrentStatus, Is.EqualTo(Status.Criado));
        }

        [Test]
        public void StatusCriadoSeraEncerradoNaAcaoEncerrar()
        {
            var chamado = new Chamado();

            Assert.Pass();
        }
    }
}