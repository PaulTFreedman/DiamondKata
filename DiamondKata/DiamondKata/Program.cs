using DiamondKata;

if (args.Length == 0)
{
    Console.WriteLine("Please provide a single letter as input");
    return;
}

if (!char.TryParse(args[0], out var inputChar))
{
    Console.WriteLine("Input was not a single character!");
    return;
}

var lineBuilder = new LineBuilder();
var diamondBuilder = new DiamondBuilder(lineBuilder);

try
{
    var result = diamondBuilder.BuildDiamond(inputChar);
    Console.WriteLine(result);
} catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}