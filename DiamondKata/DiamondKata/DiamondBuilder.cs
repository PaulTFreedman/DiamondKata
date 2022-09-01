namespace DiamondKata;

public class DiamondBuilder : IDiamondBuilder
{
    private readonly ILineBuilder _lineBuilder;
    private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public DiamondBuilder(ILineBuilder lineBuilder)
    {
        _lineBuilder = lineBuilder;
    }

    public string BuildDiamond(char letter)
    {
        var upperCase = char.ToUpper(letter);
        var index = Array.IndexOf(alphabet, upperCase);

        var i = 0;
        var result = string.Empty;
        var lineCount = (2 * index) + 1;

        while (i < lineCount)
        {
            result += (i == 0 ? string.Empty : "\n") + _lineBuilder.BuildLine(upperCase, i);

            i++;
        }

        return result;
    }
}
