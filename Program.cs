using System.Diagnostics;

using static System.Net.Mime.MediaTypeNames;

var timer = new Stopwatch();
timer.Start();
_ = RotationalCipher.Rotate("abcdefghijklmnopqrstuvwxyz", 14);
timer.Stop();
Console.WriteLine($"Time:{timer.Elapsed.TotalMilliseconds}");
