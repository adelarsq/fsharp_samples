#r "nuget: FSharp.Configuration, 2.0.0-alpha3"
open System
open FSharp.Configuration
type TestConfig = YamlConfig<"/tmp/Config.yaml">
let config = TestConfig()
printfn $"Host: {config.Mail.Smtp.Host}"
printfn $"Port: {config.Mail.Smtp.Port}"
printfn $"User: {config.Mail.Smtp.User}"
printfn $"Password: {config.Mail.Smtp.Password}"
