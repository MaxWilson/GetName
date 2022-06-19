open System

[<EntryPoint>]
let main args =
    let getName path =
        try
            let path = System.IO.Path.GetFullPath path
            let asm = System.Reflection.Assembly.ReflectionOnlyLoadFrom path
            Console.WriteLine $"{asm.FullName} from {path}"
        with err -> $"Invalid path: '{path}' / {err.GetType().Name} {err.Message}" |> Console.Error.WriteLine
    match args |> List.ofArray with
    | [] -> printfn "Usage: getName <pathsToDlls>"
    | ["read"] ->
        let rec loop() =
            let line = Console.ReadLine()
            if (not (line = null)) && line.Length > 0 then
                line|>getName
                loop()
        loop()
    | paths ->
        for path in paths do
            getName path
    0