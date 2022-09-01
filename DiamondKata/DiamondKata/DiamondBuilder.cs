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

        var step = 0;
        var result = string.Empty;
        var lineCount = (2 * index) + 1;

        while (step < lineCount)
        {
            result += (step == 0 ? string.Empty : "\n") + _lineBuilder.BuildLine(upperCase, step);

            step++;
        }

        return result;
    }
}
