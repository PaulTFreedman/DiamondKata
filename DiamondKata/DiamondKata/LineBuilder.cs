namespace DiamondKata;

public class LineBuilder : ILineBuilder
{
    public string BuildLine(char character, int index, int i)
    {
        if (i < 0 || i > index)
        {
            throw new ArgumentOutOfRangeException();
        }

        var outerGapCount = index - i;
        var innerGapCount = Math.Max((2 * (i - 1)) + 1, 0);
        var outerString = new string('_', outerGapCount);
        var innerString = new string('_', innerGapCount);

        string? line;
        if (i == 0)
        {
            line = outerString + character + outerString;
        } else
        {
            line = outerString + character + innerString + character + outerString;
        }

        return line;
    }
}
