using Moq;

namespace DiamondKata.Tests;

internal class DiamondBuilderTests
{
    private DiamondBuilder _diamondBuilder;
    private Mock<ILineBuilder> _lineBuilder;

    [SetUp]
    public void Setup()
    {
        _lineBuilder = new Mock<ILineBuilder>();
        _diamondBuilder = new DiamondBuilder(_lineBuilder.Object);
    }

    [TestCase('a', 1)]
    [TestCase('b', 3)]
    [TestCase('c', 5)]
    [TestCase('z', 51)]
    public void BuildDiamond_ShouldPrintCorrectNumberOfRows(char c, int expectedRowCount)
    {
        var result = _diamondBuilder.BuildDiamond(c);

        var lines = result.Split("\n");

        Assert.That(lines.Length, Is.EqualTo(expectedRowCount));
    }

    [TestCase(' ')]
    [TestCase('@')]
    [TestCase('4')]
    public void BuildDiamond_ShouldThrowIfNonLetterCharProvided(char c)
    {
        Assert.Throws<ArgumentException>(() => _diamondBuilder.BuildDiamond(c));
    }

    [TestCase('a', 1)]
    [TestCase('A', 1)]
    [TestCase('z', 51)]
    [TestCase('Z', 51)]
    public void BuildDiamond_ShouldAllowUpperOrLowerCaseLetters(char c, int expectedRowCount)
    {
        var result = _diamondBuilder.BuildDiamond(c);

        var lines = result.Split("\n");

        Assert.That(lines.Length, Is.EqualTo(expectedRowCount));
    }
}
