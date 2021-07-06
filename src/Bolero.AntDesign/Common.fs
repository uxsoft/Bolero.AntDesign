module Bolero.AntDesign.Common

open Bolero

type DSLElement =
    { Attributes: Attr list
      Children: Node list }
    
    member inline x.set (name: string) value =
        { x with Attributes = x.Attributes @ [ Attr(name, box value) ] }
        
//    member inline x.get<'t> (name: string) =
//        x.Attributes
//        |> List.tryFind (fun (k, _) -> k = name)
//        |> Option.map (fun (_, v) -> v :?> 't)
//        
//    member inline x.getOrDefault<'t> (name: string) (fallback: 't) =
//        x.get<'t> name |> Option.defaultValue fallback

type DSLAttribute =
    { Name: string; Value: obj }

type BoleroBuilder() =
    member inline _.Zero() = { Attributes = []; Children = [] }
    member inline _.Delay(f) = f ()

    member inline x.Yield() = x.Zero()

    member inline _.Yield(attr: DSLAttribute) =
        { Attributes = [ Attr(attr.Name, box attr.Value) ]
          Children = [ ] }

    member inline _.Yield(child: string) =
        { Attributes = []
          Children = [ Html.text child ] }
    
    member inline _.Yield(child: Node) =
        { Attributes = []
          Children = [ child ] }
        
    member inline _.Yield(children: Node list) =
        { Attributes = []
          Children = children }

    member inline x.Yield _ = x.Zero()

    member inline _.Combine(a: DSLElement, b: DSLElement) =
        { Attributes = a.Attributes @ b.Attributes
          Children = a.Children @ b.Children }

    member inline x.For(s: DSLElement, f) =
        x.Combine(s, f ())
        
    member inline x.For(list: 'a seq, f: 'a -> DSLElement) =
        let elements = Seq.map f list
        { Attributes = elements |> Seq.map (fun i -> i.Attributes) |> List.concat
          Children =  elements |> Seq.map (fun i -> i.Children) |> List.concat }
    
    // Common Attributes
    [<CustomOperation("attr")>]
    member inline _.attr(s: DSLElement, n: string, v) = s.set n v

//    [<CustomOperation("style")>]
//    member inline _.style(s: DSLElement, css: CSSProp list) =
//        s.set "style" (keyValueList CaseRules.LowerFirst css)

    [<CustomOperation("id")>]
    member inline _.id(s: DSLElement, v: string) = s.set "id" v

    [<CustomOperation("key")>]
    member inline _.key(s: DSLElement, v: string) = s.set "key" v

    [<CustomOperation("className")>]
    member inline _.className(s: DSLElement, v: string) = s.set "className" v