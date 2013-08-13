using System;
using System.IO;

namespace T9Assignment
{
	class Program
	{
		static void Main(string[] args)
		{
			
			if (args.Length != 1)
			{
				Console.WriteLine("Usage: T9Assignment filename.in");
				Console.WriteLine("Options:");
				Console.WriteLine("\tfilename - input file with text info that will be convert to T9 format");
			}
			else
			{
				if (File.Exists(args[0]))
				{
					var sr = new StreamReader(args[0]);
					int counter = 0;
					string line = string.Empty;

					string outFilename = string.Format("{0}.out", args[0].Split(".".ToCharArray())[0]);

					var sw = new StreamWriter(outFilename);
					var formatter = new T9Formatter();

					while ((line = sr.ReadLine()) != null)
					{
						if (counter >= 1)
						{
							string t9Line = formatter.GetT9String(line.ToLower());
							Console.WriteLine("{0} => {1}", line, t9Line);
							sw.WriteLine("Case #{0}: {1}", counter, t9Line);
						}
						counter++;
					}

					sw.Close();
					sr.Close();

					Console.WriteLine("\n========\nFile {0} successfully converted to T9 format and saved to {1}",
						args[0], outFilename);
				}
				else
				{
					Console.WriteLine("File you specified does not exist");
				}

			}
		}
	}
}
