[<EntryPoint>]
let main args =
    printfn "Arguments passed to function : %A" args
    printfn "Press any key ♔♚"
    System.Console.ReadLine() |> ignore
    // Return 0. This indicates success.
    0