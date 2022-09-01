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
    public void BuildLine_ShouldReturnStringWithCorrectLength(int i)
    {
        var letter = 'C';

        var result = _lineBuilder.BuildLine(letter, i);

        Assert.That(result.Length, Is.EqualTo(5));
    }

    [TestCase(-1)]
    [TestCase(5)]
    public void BuildLine_ShouldThrowIfStepOutsideValidRange(int i)
    {
        var letter = 'C';

        Assert.Throws<ArgumentOutOfRangeException>(() => _lineBuilder.BuildLine(letter, i));
    }
}
