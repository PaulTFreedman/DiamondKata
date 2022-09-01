namespace DiamondKata.Tests;

internal class LineBuilderTests
{
    private LineBuilder _lineBuilder;

    [SetUp]
    public void Setup()
    {
        _lineBuilder = new LineBuilder();
    }

    [TestCase(2, 0)]
    [TestCase(2, 1)]
    [TestCase(2, 2)]
    [TestCase(2, 3)]
    [TestCase(2, 4)]
    public void BuildLine_ShouldReturnStringWithCorrectLengthForAllSteps(int index, int step)
    {
        var letter = 'C';

        var result = _lineBuilder.BuildLine(letter, index, step);

        Assert.That(result.Length, Is.EqualTo(5));
    }

    [TestCase('A', "A")]
    [TestCase('q', "q")]
    [TestCase('~', "~")]
    [TestCase('3', "3")]
    [TestCase(' ', " ")]
    public void BuildLine_ShouldAllowAnyCharacter(char c, string expectedResult)
    {
        var result = _lineBuilder.BuildLine(c, 0, 0);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase('A', 2, 0, "__A__")]
    [TestCase('B', 2, 1, "_B_B_")]
    [TestCase('C', 2, 2, "C___C")]
    [TestCase('B', 2, 3, "_B_B_")]
    [TestCase('A', 2, 4, "__A__")]
    public void BuildLine_ShouldBuildLineCorrectly(char c, int index, int step, string expectedResult)
    {
        var result = _lineBuilder.BuildLine(c, index, step);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(2, -1)]
    [TestCase(2, 5)]
    [TestCase(0, -1)]
    [TestCase(0, 1)]
    public void BuildLine_ShouldThrowIfStepOutsideValidRange(int index, int step)
    {
        var letter = 'C';

        Assert.Throws<ArgumentOutOfRangeException>(() => _lineBuilder.BuildLine(letter, index, step));
    }
}
