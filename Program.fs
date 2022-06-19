open System

[<EntryPoint>]
let main args =
    let getName path =
        try
            let path = System.IO.Path.GetFullPath path
            let asm = System.Reflection.Assembly.LoadFrom path
            asm.FullName
        with err -> $"Invalid path: '{path}' / {err}"
    match args |> List.ofArray with
    | [] -> printfn "Usage: getName <pathsToDlls>"
    | ["read"] ->
        let rec loop() =
            let line = Console.ReadLine()
            if (not (line = null)) && line.Length > 0 then
                printfn $"{line|>getName}"
                loop()
        loop()
    | paths ->
        for path in paths do
            printfn $"{getName path}"
    0