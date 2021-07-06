module Bolero.AntDesign.Button

open Bolero
open Bolero.AntDesign.Common

type ButtonBuilder() =
    inherit BoleroBuilder()
    
    member _.Run(x: DSLElement) = Html.comp<AntDesign.Button> x.Attributes x.Children
    
    [<CustomOperation("danger")>]
    member _.Danger(x: DSLElement) = x.set "danger" true