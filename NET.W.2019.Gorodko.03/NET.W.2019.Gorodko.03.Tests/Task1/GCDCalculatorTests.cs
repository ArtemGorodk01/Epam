using System;
using Moq;
using NET.W._2019.Gorodko._03.Task1;
using NET.W._2019.Gorodko._03.Task1.GCDAlgorithms.Abstarct;
using NUnit.Framework;

[TestFixture]
public class GCDCalculatorTests
{
    private Mock<IGCDAlgorithm> _algorithm;

    public GCDCalculatorTests()
    {
        _algorithm = new Mock<IGCDAlgorithm>();

        _algorithm.Setup<int>(a => a.Execute(1, 1)).Returns(1);
        _algorithm.Setup<int>(a => a.Execute(1, 2)).Returns(1);
        _algorithm.Setup<int>(a => a.Execute(1, 4)).Returns(1);
        _algorithm.Setup<int>(a => a.Execute(2, 4)).Returns(2);
        _algorithm.Setup<int>(a => a.Execute(2, 8)).Returns(2);
        _algorithm.Setup<int>(a => a.Execute(4, 4)).Returns(4);
        _algorithm.Setup<int>(a => a.Execute(4, 8)).Returns(4);
    }

    [Test]
    public void Calculate_ParamsIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => GCDCalculator.Calculate(out long time, _algorithm.Object, 1, 1, null));
    }

    [Test]
    public void Calculate_AlgorithmIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => GCDCalculator.Calculate(out long time, null, 1, 1, 1, 1));
    }

    [TestCase(1, 1, 1, ExpectedResult = 1)]
    [TestCase(1, 2, 4, ExpectedResult = 1)]
    [TestCase(2, 4, 8, ExpectedResult = 2)]
    [TestCase(4, 4, 8, ExpectedResult = 4)]
    public int Calculates_ReturnsRightResult(int number1, int number2, params int[] numbers)
    {
        return GCDCalculator.Calculate(out long time, _algorithm.Object, number1, number2, numbers);
    }
}
