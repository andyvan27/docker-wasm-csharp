 using System.Text.Json;

//Console.WriteLine($"Hello, {Environment.OSVersion.Platform}");

Console.WriteLine("Content-Type: application/json");
Console.WriteLine();

var message = new {message = "Hello WASM!"};
Console.WriteLine(JsonSerializer.Serialize(message));
