Console.TreatControlCAsInput = true;

var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
Console.WriteLine(desktopPath);

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Ctrl + C");
Console.ResetColor();
Console.WriteLine(" for copy to clipboard");

var keyInfo = Console.ReadKey(true);
if(keyInfo.Key is ConsoleKey.C
&& keyInfo.Modifiers is ConsoleModifiers.Control)
{
	var t = new Thread(_ => { Clipboard.SetText(desktopPath); Console.WriteLine("Copied to clipboard!"); });
	t.SetApartmentState(ApartmentState.STA);
	t.Start();
	t.Join();
}