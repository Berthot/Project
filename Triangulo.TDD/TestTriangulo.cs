using NUnit.Framework;

namespace TesteCandidatoTDD
{
    public class TesteTriangulo
    {


        [Test]
        [TestCase("[[6],[3,5],[9,7,1],[4,6,8,4]]", 26)]
        [TestCase("[[6],[3,5],[9,7,1]]", 18)]
        [TestCase("[[6],[3,5]]", 11)]
        [TestCase("[[6],[3,5],[9,1,3],[4,6,1,4]]", 18)]
        [TestCase("[[6],[3,5],[9,1,3],[4,6,6,4]]", 20)]
        [TestCase("[[1],[1,1],[1,1,1],[1,1,1,1]]", 4)]
        [TestCase("[[1],[1,1],[1,1,1]]", 3)]
        public void TestResultadoTriangulo(string array, int result)
        {
            // Arrange
            var triangulo = new Triangulo.Domain.Triangulo();
            // Act
            var retorno = triangulo.TriangleResult(array);
            // Assert
            Assert.IsTrue(retorno == result);
        }
    }

}