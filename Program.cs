
if (args.Length != 3)
{
  Console.WriteLine("Usage: dotnet run <target-file> <target-column> <search-key>");
  return -1;
}

string targetFile = args[0];
if (!File.Exists(targetFile))
{
  Console.WriteLine("Error: target file does not exists {0}", targetFile);
  return -1;
}

if (!int.TryParse(args[1], out int targetColumn))
{
  Console.WriteLine("Error: target column must be a number");
  return -1;
}

string searchKey = args[2];

using StreamReader reader = File.OpenText(targetFile);

string? line = null;
while ((line = reader.ReadLine()) != null)
{
  string[] tokens = line.Trim(';').Split(",");
  if (targetColumn >= tokens.Length)
  {
    Console.WriteLine("Error: target column outside available indexes");
    return -1;
  }
  string cell = tokens[targetColumn];
  if (cell == searchKey)
  {
    Console.WriteLine(line);
  }
}

return 0;
