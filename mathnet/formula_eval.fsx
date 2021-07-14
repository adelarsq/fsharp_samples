#!/usr/bin/env -S dotnet fsi
#r "nuget: MathNet.Symbolics, 0.24.0"
// References: https://symbolics.mathdotnet.com - @adelarsq - 2021
open System
open MathNet.Symbolics

let formula1 = "a+b"  
let formula2 = "1/(a*b"  
let formula3 = "1/(a*b)"  
let a = 0.5
let b = 0.5

let evaluate parsed a b formula =
    let values = Map.ofList ["a", FloatingPoint.Real a; "b", FloatingPoint.Real b]
    let result = Evaluate.evaluate values parsed
    printfn "🟢 %s = %f" formula result.RealValue

let parse formula a b =
    let parsed = Infix.tryParse formula
    match parsed with
    | Some(parsed) -> evaluate parsed a b formula
    | None -> printfn "🔴 Error"

parse formula1 a b
parse formula2 a b
parse formula3 a b
