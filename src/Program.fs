// For more information see https://aka.ms/fsharp-console-apps
printfn "WebAssembly in F#"

printfn "\nAdding via .wat format:"
RunWasm.runAddWat()

printfn "\nAdding via .wasm format:"
RunWasm.runAddWasm()