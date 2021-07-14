#!/usr/bin/env -S dotnet fsi
#r "nuget: Wasmtime, 0.28.0-preview1"
open System
open Wasmtime
let engine = new Engine()
let modu = Module.FromTextFile(engine, "hello.wat")
let linker = new Linker(engine)
let store = new Store(engine)
let printHello () = printfn "Hello from F#, WebAssembly!"
let callBackAction = Action printHello
let callBack = Function.FromCallback(store, callBackAction)
linker.Define ("", "hello", callBack)
let instance = linker.Instantiate (store, modu)
let run = instance.GetFunction(store, "run")
if run = null then printfn "Error: Run export is missing!"
else run.Invoke (store) |> ignore
