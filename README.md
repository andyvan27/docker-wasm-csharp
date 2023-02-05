# wasm-csharp
Wasm hello world in C# Console with wasmtime and Web with wagi

## Reference

This is the code created when following steps from the totorial Video of Fanie Reynders. Many thanks to Fanie for putting up such a nice and detailed video for us to try WASM on C#:

https://www.youtube.com/watch?v=97yJtD5FKe4

## Create console app
```
dotnet new console -o hello-wasm
```

## Modify Program.cs
```
Console.WriteLine($"Hello, {Environment.OSVersion.Platform}");
```

## Build and run
```
cd .\hello-wasm\

dotnet build

dotnet run
--> Hello, Win32NT
```

## Make it wasm
```
dotnet add package wasi.sdk --prerelease

dotnet build

dotnet run
--> Hello, Other

wasmtime run bin\Debug\net7.0\hello-wasm.wasm
--> Hello, Other
```

## Try on webassembly.sh
Go to https://webassembly.sh/
Type in
```
wapm upload
-->
Module hello-wasm.wasm installed successfully!
→ Installed commands: hello-wasm

hello-wasm
--> Hello, Other
```

## Make it json
Modify Program.cs to
```
using System.Text.Json;

Console.WriteLine("Content-Type: application/json");
Console.WriteLine();

var message = new {message = "Hello WASM!"};
Console.WriteLine(JsonSerializer.Serialize(message));
```

Build and run
```
dotnet build

dotnet run
-->
Content-Type: application/json

{"message":"Hello WASM!"}
```

## Make it wagi
Add api.toml with this content
```
[[module]]
route="/api/awesome"
module="./bin/Debug/net7.0/hello-wasm.wasm"
```

## Install wagi
https://github.com/deislabs/wagi

## Run on wagi
```
wagi -c .\api.toml
--> 
No log_dir specified, using temporary directory C:\Users\ANDYNG~1\AppData\Local\Temp\.tmpwLtqab for logs
Ready: serving on http://127.0.0.1:3000
```
Go to http://127.0.0.1:3000/api/awesome and you will see the message in json