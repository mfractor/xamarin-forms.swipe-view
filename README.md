# Introducing the Xamarin.Forms SwipeView Control

**Use SwipeView to create intuitive context actions in your app**

## Introduction
Take a moment and think about your favourite email app; it's likely you can swipe on emails to archive or delete them. These swipe actions feel natural and are intuitive... so natural, in fact, you probably do it without even thinking about it!

In Xamarin.Forms 4.4, the `SwipeView` control was introduced, giving Xamarin.Forms developers the ability to provide swipe-actions to any control. With relatively little work, we can now add rich context actions that our users can execute simply by swiping left or right.

In this article, we'll explore the ins and outs of the new `SwipeView` control with a series of real-world examples. We'll make an app to display the top movies of 2019 and then use `SwipeView` to create swipe actions so our users sort films and star their favourite films.

We'll learn:

 * The core APIs of the new SwipeView layout.
 * How to execute a command automatically on swipe.
 * How to add a swipe menu to provide multiple context actions.

Let's get started!

## Setup
As SwipeView is only available in Xamarin.Forms 4.4 and above, you'll first need to upgrade Xamarin.Forms to **4.4**.

Next, enable SwipeView by setting the `SwipeView_Experimental` feature flag before `Forms.Init()` in each platform:

**Android: MainActivity.cs**
```
protected override void OnCreate(Bundle savedInstanceState)
{
    Forms.SetFlags("SwipeView_Experimental");

    // ...

    global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
}
```

**iOS: AppDelegate.cs**
```
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
    Forms.SetFlags("SwipeView_Experimental");

    // ...

    global::Xamarin.Forms.Forms.Init()
}
```

## Apply SwipeView To Our Movies App
2019 has been a dang good year for movies, so let's make an app for film buffs to browse and record their favourite films 🎬

We'll use leverage `SwipeView` to create intuitive swipe actions for our users to track their favourite films and to sort the films released throughout the year.

Our movies app will be composed of the following sections:

 * A top `CollectionView` to show the users favourite films.
 * A title that shows the current sorting of the films; users can swipe on this to reveal a context menu to sort the films.
 * A grid `CollectionView` to show the top films of 2019; users can swipe on each film card to mark it as a favourite.

[For reference, the full source code for this app can be found here.](https://github.com/mfractor/xamarin-forms.swipe-view/tree/master/src)

### Executing Commands On Swipe (Favourite Action)
Let's start by giving our film connoisseurs an easy way to record their favourite films; we'll define a `MovieCard` with a swipe action to toggle the `IsFavourite` state of each film.

We can create this like so:

**MovieCard with swipe actions**
```
<SwipeView>
    <SwipeView.LeftItems>
        <SwipeItems Mode="Execute">
            <SwipeItem Text="{Binding FavouriteLabel}"
                        BackgroundColor="{StaticResource backgroundColor}"
                        Command="{Binding Source={x:Reference root}, Path=BindingContext.ToggleFavouriteCommand}"
                        CommandParameter="{Binding .}"/>
        </SwipeItems>
    </SwipeView.LeftItems>

    <controls:MovieCard/>
</SwipeView>
```

Here we declare a new `SwipeView` to wrap our `MovieCard` and expose a left to right swipe action. 

When our users swipe left to right, the swipe view reveals the favourite action and automatically triggers the `Command` when the swipe is released. This is achieved by setting `Mode="Execute"` on `SwipeItems`.

This lets our users swipe left-to-right on a movie to intuitively star or unstar their favourite films:

![Using left to right swipe actions to implement a favourite feature](/img/swipe-favourites-action.gif)

Let's further explore what each property on the `SwipeItem` does:

 * `Text`: This sets the label displayed when the swipe action is revealed. As it's bindable, we show either `Star` or `Unstar` based on the `IsFavourite` property on the movie model.
 * `BackgroundColor`: Sets the background color of the swipe item. Here we use the `{StaticResource backgroundColor}` expression to set the background color to be the same as our pages background.
 * `Command`: The command to execute on our `MoviesViewModel` when the left to right swipe is completed. As each movie card is inside a `CollectionView`, we bind to our pages ViewModel and then specify the `ToggleFavouriteCommand` as the command to execute.
 * `CommandParameter`: The parameter to provide to the `Command`. By using `{Binding .}`, we provide the current binding context (the swiped movie) that the `ToggleFavouriteCommand` can then change the favourite state.

### Creating A Muli-Action Menu (Sort Menu)
To make it easier to browse the films, we'll expose a context menu for our users to sort the films in the collection.

We can define a multi-item context menu by creating a `SwipeView` with multiple `SwipeItem` instances:
```
<SwipeView Grid.Row="5">
    <SwipeView.LeftItems>
        <SwipeItems Mode="Reveal">
            <SwipeItem BackgroundColor="{StaticResource backgroundColor}"
                        Text="↓"
                        Invoked="SortDescending"/>
            <SwipeItem BackgroundColor="{StaticResource backgroundColor}"
                        Text="↑"
                        Invoked="SortAscending"/>
            <SwipeItem BackgroundColor="{StaticResource backgroundColor}"
                        Text="╳"
                        Invoked="SortNone"/>
        </SwipeItems>
    </SwipeView.LeftItems>
    <Label Text="{Binding SortModeDescription}" FontSize="Large" FontAttributes="Bold"/>
</SwipeView>
```

This declares a new `SwipeView` to give the `SortModeDescription` label three context menu items. When a user swipe left to right, the swipe view reveals three context actions (`↓`, `↑` and `╳`) that trigger different sorting filters on the movie collection.

Also, as we have set `Mode="Reveal"`, the swipe view will reveal all `SwipeItem`s and then require the user to tap on an item to execute it.

Lastly, we initialise the `Invoked` event with a method from our code-behind class. When the user taps on the item, the `SwipeView` will execute this method.

## Summary

SwipeView is a powerful addition to Xamarin.Forms that enables developer to attach swipe actions to any control.

We've learnt how to create add actions that our users can execute on swipe and how to attach context menus to any UI control using SwipeItems.

This article only scratches the surface of `SwipeView`, to learn more visit the official [SwipeView documentation](https://docs.microsoft.com/en-gb/xamarin/xamarin-forms/user-interface/swipeview).

--------

Matthew is the founder of www.mfractor.com, a powerful productivity tool for Xamarin developers.

Learn more about MFractor at [www.mfractor.com](https://www.mfractor.copm).
