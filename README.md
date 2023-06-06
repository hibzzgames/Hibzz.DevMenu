# Hibzz.DevMenu
![LICENSE](https://img.shields.io/badge/LICENSE-CC--BY--4.0-ee5b32?style=for-the-badge) [![Twitter Follow](https://img.shields.io/badge/follow-%40hibzzgames-1DA1f2?logo=twitter&style=for-the-badge)](https://twitter.com/hibzzgames) [![Discord](https://img.shields.io/discord/695898694083412048?color=788bd9&label=DIscord&style=for-the-badge)](https://discord.gg/tZdZFK7) ![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white) ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)

***A tool used to add custom commands to a developer menu for quick testing and debugging***

<img src="https://user-images.githubusercontent.com/37605842/207492699-a693aaed-2001-472b-ba25-3a73cd92b3af.png" width="960"></img>

## Installation
**Via Github**
This package can be installed in the Unity Package Manager using the following git URL.
```
https://github.com/hibzzgames/Hibzz.DevMenu.git
```

Alternatively, you can download the latest release from the [releases page](https://github.com/hibzzgames/Hibzz.DevMenu/releases) and manually import the package into your project. The dependencies will also have to be imported manually from the respective releases page.

### Dependencies
The package manager unfortunately doesn't support dependencies automatically. Hopefully 2023 is the year that Unity fixes this. So, until then, you will have to install the following packages manually:

```
https://github.com/hibzzgames/Hibzz.Singletons.git
```


## How to access?
The DevMenu is a singleton that can be accessed from anywhere in your project. By the default, the DevMenu is hidden and you must manually open it from somewhere in your project. The DevMenu can be opened by calling the `DevMenu.Open()` method and closed by calling the `DevMenu.Close()` method.

```csharp
using Hibzz.DevMenu;

// in update
if(Input.GetKeyDown(KeyCode.BackQuote))
{
    if(DevMenu.IsOpen) 
    { 
        DevMenu.Close(); 
    }
    else 
    { 
        DevMenu.Open();
    }
}
```

## How to add commands?
The DevMenu uses a card system to display commands. Each card can have a title and the action to be performed when the card is clicked. The DevMenu can be populated with cards by calling the `DevMenu.Add(string title)` function. This function returns a card object which can be used to add the callback function to be called when the card is clicked.

```csharp
// create the card
Card invincibleCard = DevMenu.Add("Invincible");

// add the callback
invincibleCard.OnApply = () =>
{
    // invincible code goes here
}
```

## How to add fields to a card?
The DevMenu also supports adding fields to a card. This can be used to get input from the user and to use that input in the callback function. A card can be populated with fields by calling the `Card.Add<T>(string title)` function where `T` is the type of the field. The DevMenu currently supports the following field types and more will be added in the future (feel free to suggest more field types if you have a use case for them).

- int
- float
- string
- bool
- enum (any enum type works!)

Here's an example of how to add a field to a card and access the value of the field in the callback function:
```csharp
// create the card
Card healthCard = DevMenu.Add("Set Health");

// add the fields
healthCard.Add<int>("Health");
healthCard.Add<float>("TimeToHeal");

// add the callback
healthCard.OnApply = () =>
{
    // get the values of the fields
    int health = healthCard.Get<int>("Health");
    float timeToHeal = healthCard.Get<float>("TimeToHeal");

    // some code to set the health of the player in the given time goes here
}
```

## API Reference
For more details on what's possible, here's the link to the [API reference](https://github.com/hibzzgames/Hibzz.DevMenu/wiki/API-Reference).

## Conclusion
That's all for now and I hope you find this tool useful. It's pretty flexible and can be used anywhere in your script to dynamically add commands and remove them depending on context.

## Have a question or want to contribute?
If you have any questions or want to contribute, feel free to join the [Discord server](https://discord.gg/tZdZFK7) or [Twitter](https://twitter.com/hibzzgames). I'm always looking for feedback and ways to improve this tool. Thanks!

Additionally, you can support the development of these opensource projects via [GitHub Sponsors](https://github.com/sponsors/sliptrixx) and gain early access to the projects.

