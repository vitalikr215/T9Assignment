using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace T9Assignment.Tests
{
	/// <summary>
	/// Summary description for T9Test
	/// </summary>
	[TestClass]
	public class T9Test
	{
		private TestContext testContextInstance;
		private T9Formatter formatter;

		public T9Test()
		{
			formatter = new T9Formatter();
		}

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		
		[TestMethod]
		public void CheckAnySymbolConversion()
		{
			string result = formatter.GetT9String("i");
			Assert.AreEqual("444", result);
		}

		[TestMethod]
		public void CheckSeveralSymbolsUsingSameKey()
		{
			// 'h' and 'i' used key '4' 
			string result = formatter.GetT9String("hi");
			Assert.AreEqual("44 444", result);
		}

		[TestMethod]
		public void CheckSameSymbol()
		{
			string result = formatter.GetT9String("aa");
			Assert.AreEqual("2 2", result);
		}

		[TestMethod]
		public void CheckConversionWordWithBeginigSpace()
		{
			string result = formatter.GetT9String(" span");
			Assert.AreEqual("07777 7266", result);
		}
		
		[TestMethod]
		public void CheckConversionWordWithTrailingSpace()
		{
			string result = formatter.GetT9String("span ");
			Assert.AreEqual("7777 72660", result);
		}

		[TestMethod]
		public void CheckConversionSeveralWordsWithSpaces()
		{
			string result = formatter.GetT9String("hello world");
			Assert.AreEqual("4433555 555666096667775553", result);
		}

		[TestMethod]
		public void CheckConversionUpperCaseSymbols()
		{
			string result = formatter.GetT9String("YeS");
			Assert.AreEqual("999337777", result);
		}

		[TestMethod]
		public void CheckConversionWithIncorrectSymbols()
		{
			string result = formatter.GetT9String("Y1e2S l-");
			Assert.AreEqual("Incorrect input string format", result);
		}
	}
}
