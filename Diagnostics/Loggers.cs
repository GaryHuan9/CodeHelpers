using System;

namespace CodeHelpers.Diagnostics
{
	public interface ILogger
	{
		void Write(string text);
		void WriteWarning(string text);
		void WriteError(string text);
	}

	public class ConsoleLogger : ILogger
	{
		public void Write(string text) => Console.WriteLine(text);

		public void WriteWarning(string text)
		{
			var foreground = Console.ForegroundColor;
			var background = Console.BackgroundColor;

			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.Yellow;

			Console.WriteLine(text);

			Console.ForegroundColor = foreground;
			Console.BackgroundColor = background;
		}

		public void WriteError(string text)
		{
			var foreground = Console.ForegroundColor;
			var background = Console.BackgroundColor;

			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.Red;

			Console.WriteLine(text);

			Console.ForegroundColor = foreground;
			Console.BackgroundColor = background;
		}
	}
}