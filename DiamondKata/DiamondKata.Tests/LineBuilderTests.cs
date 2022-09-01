namespace DiamondKata.Tests;

internal class LineBuilderTests
{
    private LineBuilder _lineBuilder;

    [SetUp]
    public void Setup()
    {
        _lineBuilder = new LineBuilder();
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void BuildLine_ShouldReturnStringWithCorrectLengthForAllSteps(int step)
    {
        var letter = 'C';

        var result = _lineBuilder.BuildLine(letter, step);

        Assert.That(result.Length, Is.EqualTo(5));
    }

    [TestCase(-1)]
    [TestCase(5)]
    public void BuildLine_ShouldThrowIfStepOutsideValidRange(int step)
    {
        var letter = 'C';

        Assert.Throws<ArgumentOutOfRangeException>(() => _lineBuilder.BuildLine(letter, step));
    }

    [TestCase(' ')]
    [TestCase('@')]
    [TestCase('4')]
    public void BuildLine_ShouldThrowIfNonLetterCharProvided(char c)
    {
        Assert.Throws<ArgumentException>(() => _lineBuilder.BuildLine(c, 0));
    }

    [TestCase('a', 1)]
    [TestCase('A', 1)]
    [TestCase('z', 51)]
    [TestCase('Z', 51)]
    public void BuildLine_ShouldAllowUpperOrLowerCaseLetters(char c, int expectedLength)
    {
        var result = _lineBuilder.BuildLine(c, 0);

        Assert.That(result.Length, Is.EqualTo(expectedLength));
    }
}
