# AR-Books
This application is for reading books using the Hololens 1.

The idea behind this project was that instead of reading books on your phone, or with a paperback in your hand, 
you put on a pair of glasses (or in this case a Hololens), select a book, and start reading. 
The application would use the [Google Books API][1] to retrieve your books so you could start reading.

## Setup
In order to start working on this project, the following things have to be installed:
* Windows 10
* Visual Studio 2017
* Unity (version 2017.4.27.f1 was used in this project)

A list of where you can get these can be found in the [Microsoft documentation][2].

These are optionally to install:
* Windows 10 SDK (required when developing for Hololens 2)
* Hololens (1st gen) Emulator (very usefull when you don't have a Hololens)

Before you start, please take some time to follow [this guide][3] to get used to working with Unity for the Hololens.

For some extra documentation regarding gaze, geztures, audio and spatial mapping for the Hololens, use [this guide][4]. 
Only gaze was attempted in this project.

## Build and deploy instructions
Unity:
1. In Unity go to `File > Build Settings`
2. Click `Add Open Scenes`
3. Change platform to `Universal Windows Platform` if it isn't on that already.
4. Check that the build settings correspond with the image called `Build_Settings` that is in this repo.
5. Click Build, and select the `App` folder. If this folder doesn't exist create a new folder called `App`.
6. When Unity is done, open the Visual Studio solution that is in the `App` folder.

Visual Studio:
In the top toolbar in Visual Studio, change the target from `Debug` to `Release` and from `ARM` to `X86`.

When deploying over WIFI:
(make sure the hololens and the development machine are on the same network)
1. Click on the arrow next to `Local Machine`, and change it to `Remote Machine`.
2. Enter the IP adress of the Hololens and change authentication mode to `Universal (Unencrypted Protocol`.
(IP of HoloLens can be found by asking Cortana: "What's my IP adress?")
3. Click `Debug > Start without debugging`

When deploying over USB:
1. Change `Local Machine` to `Device`.
2. Click `Debug > Start without debugging`.

## How it works
During development it was decided to add an extra step between opening and reading, and that was opening a shelf. 
After a shelf was opened, the user would be able to open a book, and start reading.
So first a user's shelves had to be loaded in, then the books on that shelf and then the actual book.

This is where problems started to arise. At first the Unity project and the Google Books API wouldn't work together. 
As a workaround it was decided to create a [Console app][5] that calls the API, and stores the data in a JSON file, 
which the Unity project should be able to read. 
Unfortunately, this wasn't the case either, since the API's datatypes were required. 
This setback did result in a fix for the previous problem, since all that was required for Unity to be able to work with the API, was that the `.dll` files had to be in the Assets folder in Unity. So now it was possible to read the `JSON` files and load in the data. 
This was done in the script `ShelfLoader.cs` (located in the `scripts` folder inside the `Assets` folder). 

This script worked fine in Unity, until you started building it for the Hololens. Then the build process fails
and throws a bunch of reference rewriter errors. Unfortunately a fix for this problem couldn't be found.



[1]: https://developers.google.com/books/docs/overview
[2]: https://docs.microsoft.com/en-us/windows/mixed-reality/install-the-tools
[3]: https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-100#chapter-1---create-a-new-project
[4]: https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101#chapter-1---holo-world
[5]: *add link to repo*
