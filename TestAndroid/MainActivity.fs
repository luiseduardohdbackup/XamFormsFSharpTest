namespace TestAndroid

open System
open System.ComponentModel

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open Xamarin.Forms
open Xamarin.Forms.Platform.Android

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

[<Activity (Label = "TestAndroid", MainLauncher = true)>]
type MainActivity () =
    inherit AndroidActivity ()

    let mutable count:int = 1

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        Xamarin.Forms.Forms.Init(this, bundle);
        Xamarin.FormsMaps.Init(this, bundle);

        this.SetPage(App.GetMainPage());





