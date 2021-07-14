#!/usr/bin/env -S dotnet fsi
// Using CoinDesk API by Adelar da Silva Queiróz - 2021
#r "nuget: FSharp.Data, 4.1.1";;
open System
open FSharp.Data
let icons = [ "USD","🇺🇸"; "GBP","🇬🇧"; "EUR","🇪🇺" ] |> Map.ofList
let query = $"https://api.coindesk.com/v1/bpi/currentprice.json"
let result = Http.RequestString query
// JsonProvider receives a sample result to know about the types
type Provider = JsonProvider<"""{"time":{"updated":"a","updatedISO":"a","updateduk":"a"},"disclaimer":"a","chartName":"a","bpi":{"USD":{"code":"a","symbol":"a","rate":"a","description":"a","rate_float":1.1},"GBP":{"code":"a","symbol":"a","rate":"a","description":"a","rate_float":1.1},"EUR":{"code":"a","symbol":"a","rate":"a","description":"a","rate_float":1.1}}}""">
let parsed = Provider.Parse(result) // Parse request result
let coinName = parsed.ChartName
let usd = parsed.Bpi.Usd
let gbp = parsed.Bpi.Gbp
let eur = parsed.Bpi.Eur
printfn $"💰 {coinName}"
printfn $"{icons.[usd.Code]}  {usd.RateFloat}"
printfn $"{icons.[gbp.Code]}  {gbp.RateFloat}"
printfn $"{icons.[eur.Code]}  {eur.RateFloat}"
