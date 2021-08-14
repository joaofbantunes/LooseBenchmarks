namespace MaybeAndEitherAcrossLanguages.FSharp

module Scenarios =

    let maybeChain (value : System.Nullable<int>) =
        Option.ofNullable value
        |> Option.map (fun v -> v + 1)
        |> Option.map (fun v -> v + 1)
        |> Option.map (fun v -> v + 1)
        |> Option.map (fun v -> v + 1)

    let maybeChainWithClosure (value : System.Nullable<int>,  anotherValue : int) =
        Option.ofNullable value
        |> Option.map (fun v -> v + anotherValue)
        |> Option.map (fun v -> v + anotherValue)
        |> Option.map (fun v -> v + anotherValue)
        |> Option.map (fun v -> v + anotherValue)

    let eitherChain (value : int) =
        if value > 0 then Ok value else Error "error"
        |> Result.bind (fun v -> Ok (v + 1))
        |> Result.bind (fun v -> Ok (v + 1))
        |> Result.bind (fun v -> Ok (v + 1))
        |> Result.bind (fun v -> Ok (v + 1))

    let eitherChainWithClosure (value : int, anotherValue : int) =
        if value > 0 then Ok value else Error "error"
        |> Result.bind (fun v -> Ok (v + anotherValue))
        |> Result.bind (fun v -> Ok (v + anotherValue))
        |> Result.bind (fun v -> Ok (v + anotherValue))
        |> Result.bind (fun v -> Ok (v + anotherValue))
