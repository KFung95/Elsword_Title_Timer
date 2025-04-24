# Photon Tracker
![](https://github.com/KFung95/Photon-Tracker/blob/6621e82df2c0ad23737a321416234d47b113b7c1/.github/DOCUMENTS/PhotonTracker_VZnHqh8Zie.png)

# Table of contents
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [How to Use](#how-to-use)
- [Future Planned Work](#future-planned-work)
- [FAQ](#faq)
- [Contributing](#contributing)

# Prerequisites
1. You need to have .NET 8.0.X Desktop Runtime installed. You can search for it or download it [here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.11-windows-x64-installer?cid=getdotnetcore).

# Installation
1. Download the latest [release](https://github.com/KFung95/Photon-Tracker/releases).
2. Extract it.
3. Run PhotonTracker.exe.

# How to Use
1. If you have multiple characters you'd like to configure, go into the presets folder and create a new text file for each character.
2. Check the Show settings box and in the 2nd dropdown menu, select the text file that represents the character you'd like to configure.
3. Configure your keycodes. If you have a passive like Lithia's CD reset you'd like to add to the timer, fill in the Passive Cooldown textbox with the cooldown duration.

# Future Planned Work
1. The UI is pretty basic and elementary. We plan on improving the UI and making it more intuitive.
   1. Some of the elements overlap when the window is shrunk. We'll improve the top right group of buttons and dropdowns.
   2. For some people who use only one monitor, the title bar, the settings, and the overall window can take up a significant amount of screen real estate. We're planning on making the entire background transparent, hide the title bar, and hide the settings when the window is shrunk enough.
   3. The profile dropdown is just a way to load profiles. There's no way to create a new profile from the application. We're planning on baking that in.
2. Specific Character Timers and key bindings are in the works.

# FAQ
> Sometimes there are situations that trigger the timers to start ticking but I haven't used my titles or items. Can the program be made more accurate?

The way the program works is that it tracks when you hit the title switch key, the current timer to see if it's already ticking, and the button required to trigger the timer (i.e: Awakening, Night Parade skill, Passive, etc.). The program is generally accurate but there are times where you press the keys but it doesn't register in game. This causes the timer to start ticking. There's unfortunately no way to make it 100% accurate as that would require the program to hook into the game which would trigger anti-cheat. We added a reset button so you can reset your timers and this is currently the only workaround.

> Will I be banned for using this?

To my knowledge, no as the program doesn't interact with the game whatsoever. Just like keyboard and mouse profile programs, this is meant to run in the background. However, use at your own risk.

# Contributing
This was built off of Hi-Yong-KR's Elsword Title Timer so a big thank you to them.

If you have any issue or any idea that could make the project better, feel free to open an [issue](https://github.com/KFung95/Photon-Tracker/issues).
