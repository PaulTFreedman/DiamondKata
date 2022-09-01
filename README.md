# DiamondKata
### Problem

Given a character from the alphabet, print a diamond of its output with that character being the midpoint of the diamond.

Examples

    > diamond.exe A
      A

    > diamond.exe B
       A
      B B
       A

    > diamond.exe C
        A
       B B
      C   C
       B B
        A

It may be helpful visualise the whitespace in your rendering like this:

    > diamond.exe C
    _ _ A _ _
    _ B _ B _
    C _ _ _ C
    _ B _ B _
    _ _ A _ _
    
### Prerequisites
Install .NET 6

### Running Locally
From root of repository:

`dotnet run --project ./DiamondKata/DiamondKata/DiamondKata.csproj {letter}` e.g `dotnet run --project ./DiamondKata/DiamondKata/DiamondKata.csproj D`

### Running Tests
From root of repository:

`dotnet test ./DiamondKata/`

### Possible Improvements
- Use IoC rather than concrete objects in Program.cs
- Cover Program.cs with component tests
