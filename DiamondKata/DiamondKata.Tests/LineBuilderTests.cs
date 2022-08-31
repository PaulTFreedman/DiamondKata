namespace DiamondKata.Tests;

internal class LineBuilderTests
{
    private LineBuilder _lineBuilder;

    [SetUp]
    public void Setup()
    {
        _lineBuilder = new LineBuilder();
    }

    [Test]
    public void BuildLine_ShouldReturnStringWithCorrectLength()
    {
        var letter = 'C';

        var result = _lineBuilder.BuildLine(letter, 0);

        Assert.That(result.Length, Is.EqualTo(5));
    }
}
