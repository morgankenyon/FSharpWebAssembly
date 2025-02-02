module RunWasm

open Wasmtime

let private loadAddWat () =
    System.IO.File.ReadAllText "./wasm/add.wat"

let private loadAddWasm () =
    System.IO.File.ReadAllBytes "./wasm/add.wasm"
    
let runAddWat () =
    let text = loadAddWat()

    let engine = new Engine()

    let modd =
        Module.FromText(
            engine,
            "test",
            text
        )

    let linker = new Linker(engine)
    let store = new Store(engine)

    let instance = linker.Instantiate(store, modd)

    let main = instance.GetFunction<int32>("main")

    let result = main.Invoke()

    printfn "%d" result
    
let runAddWasm () =
    let bytes = loadAddWasm()

    let engine = new Engine()

    let modd =
        Module.FromBytes(
            engine,
            "test",
            bytes
        )

    let linker = new Linker(engine)
    let store = new Store(engine)

    let instance = linker.Instantiate(store, modd)

    let main = instance.GetFunction<int32>("main")

    let result = main.Invoke()

    printfn "%d" result