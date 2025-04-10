using Domain.DomainEntities;
using Domain.Enums.Chamado;
using NUnit.Framework;
using Action = Domain.Enums.Action;

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

            chamado.ChangeState(Action.Encerrar);

            Assert.That(chamado.CurrentStatus, Is.EqualTo(Status.Encerrado));
        }
    }
}