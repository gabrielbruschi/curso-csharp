using System;
using Xunit;

namespace MeuAppTests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(0)]
        public void MyFirstTheory(int value)
        {
            Assert.True(MenorQueQuatro(value));
        }

        bool MenorQueQuatro(int value)
        {
            return value < 4;
        }

        [Fact]
        public void CriaUmDiretor()
        {
            var diretor = new Diretor("Nome Teste");
            Assert.Equal("Nome Teste", diretor.Nome);
        }
    }
}
