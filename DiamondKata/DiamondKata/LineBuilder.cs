namespace DiamondKata;

public class LineBuilder : ILineBuilder
{
    private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public string BuildLine(char letter, int i)
    {
        // TODO some logic to convert incoming row number to a suitable i value
        // e.g. for letter == 'C'  0->0, 1->1, 2->2, 3->1, 4->0

        var index = Array.IndexOf(alphabet, letter);

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
