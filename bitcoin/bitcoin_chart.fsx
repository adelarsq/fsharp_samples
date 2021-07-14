#!/usr/bin/env -S dotnet fsi
// Using CoinDesk API by Adelar da Silva Queiróz - 2021
#r "nuget: FSharp.Data, 4.1.1"
#r "nuget: Plotly.NET, 2.0.0-beta9"
open FSharp.Data
open Plotly.NET
let query = $"https://api.coindesk.com/v1/bpi/historical/close.json"
let result = Http.RequestString query
type Provider = JsonProvider<"""{"bpi":{"a":1.1},"disclaimer":"a","time":{"updated":"a","updatedISO":"a"}}""">
let parsed = Provider.Parse(result) // Parse request result
let xData = [|for k, v in parsed.Bpi.JsonValue.Properties() -> k |]
let yData = [|for k, v in parsed.Bpi.JsonValue.Properties() -> v.AsDecimal() |]
let myChart = Chart.Line(xData,yData)
myChart |> Chart.Show
