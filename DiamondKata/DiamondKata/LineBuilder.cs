namespace DiamondKata;

public class LineBuilder : ILineBuilder
{
    private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public string BuildLine(char letter, int step)
    {
        var upperCase = char.ToUpper(letter);

        var index = Array.IndexOf(alphabet, upperCase);
        if (index == -1)
        {
            throw new ArgumentException();
        }

        var i = step;
        if (step > index)
        {
            i = index + (index - step);
        }

        if (i < 0)
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
            line = outerString + alphabet[i] + outerString;
        } else
        {
            line = outerString + alphabet[i] + innerString + alphabet[i] + outerString;
        }

        return line;
    }
}
