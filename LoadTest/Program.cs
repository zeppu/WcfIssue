using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LoadTest
{
	class Program
	{
		private static int _count = 50;

		static void Main(string[] args)
		{
			var firstRun = true;

			while (true)
			{
				Console.WriteLine("1: Load test .NET Core");
				Console.WriteLine("2: Load test .NET Framework");
				Console.WriteLine("3: [Async] Load test .NET Core");
				Console.WriteLine("4: [Async] Load test .NET Framework");
				Console.WriteLine("c:xxx: Set count (eg: c:1000)");
				Console.WriteLine("x: Exit");
				Console.WriteLine("Make your selection");

				var value = Console.ReadLine();

				if (firstRun)
				{
					// Warm up
					Task.WaitAll(
						"http://localhost:5000/api/values/".GetAsync(),
						"http://localhost:5001/api/values/".GetAsync());
					firstRun = false;
				}

				if (value.Equals("x"))
					break;

				if (value.StartsWith("c"))
				{
					Console.WriteLine(!int.TryParse(value.AsSpan(2), out _count)
						? $"Invalid input: {value}"
						: $"Count set to: {_count}");
				}

				int.TryParse(value, out var selection);

				int port;
				string action = String.Empty;
				switch (selection)
				{
					case 1:
						port = 5000;
						break;
					case 2:
						port = 5001;
						break;
					case 3:
						port = 5000;
						action = "async/";
						break;
					case 4:
						port = 5001;
						action = "async/";
						break;
					default:
						port = 0;
						break;
				}

				if (port == 0)
				{
					continue;
				}

				Console.Clear();

				var tasks = new List<Task>();
				var baseUri = $"http://localhost:{port}/api/values/{action}";
				Console.WriteLine($"Sending {_count} requests to: {baseUri}");

				var sw = Stopwatch.StartNew();

				for (var i = 0; i < _count; i++)
				{
					var j = i+1;
					var uri = $"{baseUri}{j}";

					Console.WriteLine($"{j.ToString().PadLeft(5)}: Request: [{uri}]");
					var swLocal = Stopwatch.StartNew();
					tasks.Add(
						uri.AllowAnyHttpStatus()
							//.WithTimeout(10)
							.GetAsync()
							.ContinueWith(m =>
							{
								swLocal.Stop();
								Console.WriteLine(
									m.IsCompletedSuccessfully
										? $"[{sw.ElapsedMilliseconds}ms] {j.ToString().PadLeft(5)}: {m.Result.StatusCode.ToString()}"
										: $"[{sw.ElapsedMilliseconds}ms] {j.ToString().PadLeft(5)}: {m.Exception.InnerException.Message}");
							})
					);
				}

				Task.WaitAll(tasks.ToArray());
				sw.Stop();
				Console.WriteLine($"Run completed: [{sw.ElapsedMilliseconds}ms]");
				Console.WriteLine("Press any key to run again...");
				Console.ReadKey();
				Console.Clear();
			}

		}
	}
}
