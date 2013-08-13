using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T9Assignment
{
	class T9Formatter
	{
		private static readonly List<T9Symbol> T9Alpabet = 
			new List<T9Symbol>
				{
					new T9Symbol{Letter = 'a', Key = 2, Repeat = 1},
					new T9Symbol{Letter = 'b', Key = 2, Repeat = 2},
					new T9Symbol{Letter = 'c', Key = 2, Repeat = 3},
					
					new T9Symbol{Letter = 'd', Key = 3, Repeat = 1},
					new T9Symbol{Letter = 'e', Key = 3, Repeat = 2},
					new T9Symbol{Letter = 'f', Key = 3, Repeat = 3},
					

					new T9Symbol{Letter = 'g', Key = 4, Repeat = 1},
					new T9Symbol{Letter = 'h', Key = 4, Repeat = 2},
					new T9Symbol{Letter = 'i', Key = 4, Repeat = 3},
					
					new T9Symbol{Letter = 'j', Key = 5, Repeat = 1},
					new T9Symbol{Letter = 'k', Key = 5, Repeat = 2},
					new T9Symbol{Letter = 'l', Key = 5, Repeat = 3},

					new T9Symbol{Letter = 'm', Key = 6, Repeat = 1},
					new T9Symbol{Letter = 'n', Key = 6, Repeat = 2},
					new T9Symbol{Letter = 'o', Key = 6, Repeat = 3},

					new T9Symbol{Letter = 'p', Key = 7, Repeat = 1},
					new T9Symbol{Letter = 'q', Key = 7, Repeat = 2},
					new T9Symbol{Letter = 'r', Key = 7, Repeat = 3},
					new T9Symbol{Letter = 's', Key = 7, Repeat = 4},

					new T9Symbol{Letter = 't', Key = 8, Repeat = 1},
					new T9Symbol{Letter = 'u', Key = 8, Repeat = 2},
					new T9Symbol{Letter = 'v', Key = 8, Repeat = 3},

					new T9Symbol{Letter = 'w', Key = 9, Repeat = 1},
					new T9Symbol{Letter = 'x', Key = 9, Repeat = 2},
					new T9Symbol{Letter = 'y', Key = 9, Repeat = 3},
					new T9Symbol{Letter = 'z', Key = 9, Repeat = 4},

					new T9Symbol {Letter = ' ', Key = 0, Repeat = 1}
				};

		private static string GetT9Symbol(char symbol, char? previousSymbol)
		{			
			try
			{
				var t9 = T9Alpabet.First(x => x.Letter == symbol);
				var sb = new StringBuilder();
				if (previousSymbol.HasValue)
				{
					var t9Previous = T9Alpabet.FirstOrDefault(x => x.Letter == previousSymbol.Value);
					if (t9.Key == t9Previous.Key)
					{
						sb.Append(" ");
					}
				}

				for (int i = 1; i <= t9.Repeat; i++)
				{
					sb.Append(t9.Key);
				}
				return sb.ToString();	
			}
			catch (InvalidOperationException)
			{
				return "-1";
			}			
		}

		public string GetT9String(string inputString)
		{
			var t9String = new StringBuilder();

			for (int i = 0; i < inputString.Length; i++)
			{
				string t9Symbol = (i == 0) 
					                  ? GetT9Symbol(inputString[i], null) 
					                  : GetT9Symbol(inputString[i], inputString[i-1]);

				if (t9Symbol == "-1")
				{
					return "Incorrect input string format";
				}

				t9String.Append(t9Symbol);	
			}
			return t9String.ToString();
		}
	}
}
