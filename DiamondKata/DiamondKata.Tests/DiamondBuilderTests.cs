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

    [Test]
    public void BuildDiamond_ShouldProduceCorrectOutput()
    {
        _lineBuilder.Setup(x => x.BuildLine('A', 2, 0)).Returns("__A__");
        _lineBuilder.Setup(x => x.BuildLine('B', 2, 1)).Returns("_B_B_");
        _lineBuilder.Setup(x => x.BuildLine('C', 2, 2)).Returns("C___C");
        _lineBuilder.Setup(x => x.BuildLine('B', 2, 3)).Returns("_B_B_");
        _lineBuilder.Setup(x => x.BuildLine('A', 2, 4)).Returns("__A__");

        var result = _diamondBuilder.BuildDiamond('C');

        var expected = "__A__\n_B_B_\nC___C\n_B_B_\n__A__";

        Assert.That(result, Is.EqualTo(expected));
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
