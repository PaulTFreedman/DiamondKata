namespace DiamondKata;

public class LineBuilder : ILineBuilder
{
    private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public string BuildLine(char letter, int i)
    {
        var upperCase = char.ToUpper(letter);

        var index = Array.IndexOf(alphabet, upperCase);
        if (index == -1)
        {
            throw new ArgumentException();
        }

        var step = i;
        if (i > index)
        {
            step = index + (index - i);
        }

        if (step < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var outerGapCount = index - step;
        var innerGapCount = Math.Max((2 * (step - 1)) + 1, 0);
        var outerString = new string('_', outerGapCount);
        var innerString = new string('_', innerGapCount);

        string? line;
        if (step == 0)
        {
            line = outerString + alphabet[step] + outerString;
        } else
        {
            line = outerString + alphabet[step] + innerString + alphabet[step] + outerString;
        }

        return line;
    }
}
