module Bolero.AntDesign.Example.Server.Index

open Bolero
open Bolero.Html
open Bolero.Server.Html
open Bolero.AntDesign.Example

let page = doctypeHtml [] [
    head [] [
        meta [attr.charset "UTF-8"]
        meta [attr.name "viewport"; attr.content "width=device-width, initial-scale=1.0"]
        title [] [text "Bolero Application"]
        ``base`` [attr.href "/"]
        link [attr.rel "stylesheet"; attr.href "https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.4/css/bulma.min.css"]
        link [attr.rel "stylesheet"; attr.href "css/index.css"]
        link [attr.href "_content/AntDesign/css/ant-design-blazor.css"; attr.rel "stylesheet" ]
        script [attr.src "_content/AntDesign/js/ant-design-blazor.js"] []
        
    ]
    body [] [
        nav [attr.classes ["navbar"; "is-dark"]; "role" => "navigation"; attr.aria "label" "main navigation"] [
            div [attr.classes ["navbar-brand"]] [
                a [attr.classes ["navbar-item"; "has-text-weight-bold"; "is-size-5"]; attr.href "https://fsbolero.io"] [
                    img [attr.style "height:40px"; attr.src "https://github.com/fsbolero/website/raw/master/src/Website/img/wasm-fsharp.png"]
                    text "  Bolero"
                ]
            ]
        ]
        div [attr.id "main"] [rootComp<Client.Main.MyApp>]
        boleroScript
    ]
]
