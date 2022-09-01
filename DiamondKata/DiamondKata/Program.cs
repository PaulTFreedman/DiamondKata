// See https://aka.ms/new-console-template for more information
using DiamondKata;

var lineBuilder = new LineBuilder();
var diamondBuilder = new DiamondBuilder(lineBuilder);

var result = diamondBuilder.BuildDiamond(args[0].ToCharArray()[0]);

Console.WriteLine(result);