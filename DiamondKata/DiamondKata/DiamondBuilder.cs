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
        if (index == -1)
        {
            throw new ArgumentException("Non-alphabet character provided!");
        }

        var step = 0;
        var result = string.Empty;
        var lineCount = (2 * index) + 1;

        while (step < lineCount)
        {
            var i = step;
            if (step > index)
            {
                i = index + (index - step);
            }

            result += (step == 0 ? string.Empty : "\n") + _lineBuilder.BuildLine(alphabet[i], index, i);

            step++;
        }

        return result;
    }
}
