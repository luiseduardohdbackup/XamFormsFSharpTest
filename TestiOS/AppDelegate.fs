namespace TestiOS

open System
open MonoTouch.UIKit
open MonoTouch.Foundation

open System
open System.ComponentModel
open Xamarin.Forms
open Xamarin.Forms.Platform.iOS


type ButtonCodePage() as this =
    inherit ContentPage()
    [<Core.DefaultValue>] val mutable actt:Action<int>
    let mutable count = 0
    let button = new Button(Text = String.Format("Tap for click count!"))

    do
        button.Clicked.Add(fun _ ->
                count <- count + 1
                button.Text <- String.Format("{0} click{1}!", count, if count = 1 then "" else "s")
            )

        this.Content <- button

type App() =
    static member GetMainPage() =
        new ButtonCodePage()

[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit UIApplicationDelegate ()

    [<Core.DefaultValue>] val mutable window:UIWindow

    // This method is invoked when the application is ready to run.
    override this.FinishedLaunching (app, options) =
        Forms.Init()
        this.window <- new UIWindow(UIScreen.MainScreen.Bounds)
        this.window.RootViewController <- App.GetMainPage().CreateViewController()
        this.window.MakeKeyAndVisible()
        true

type TestIt() =
    interface IDisposable with
        member x.Dispose(): unit = 
            raise (System.NotImplementedException())



module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main (args, null, "AppDelegate")
        0

