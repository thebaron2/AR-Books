# AR-Books
This application is for reading books using the Hololens (1st gen).

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


## The Plan
The idea was that shelf information would be loaded in from the Books API, this didn't work with Unity though. A workaround was a seperate project called [Books API][5], which called the API and stored the data in JSON files. This project would then read these files and display the information. This code worked in Unity, but couldn't be build. 

Because of that, it was decided to add 3 shelves manually.

The next step would have been to click on a shelf and see the books on that shelf. Originally this also would have come either directly from the API or from the JSON files. Since this didn't work, it was decided to manually create 3 books, put them in an array, and load either all, 2, or 1 of the books, dependant on the number of books on a shelf. 

In Unity, the loading of the books worked fine, but when building and deploying on the HoloLens, the cursor is unable to click on a shelf to load the books on that shelf. I have been unable to fix this problem. It might have to do with the code that allows parameters to be passed, but it could also be a HoloLens issue.

The plan would have been to be able to click on a book, and read it. Unfortunately, the reading part requires a seperate API, [Embedded Viewer API][6], which needs Javascript and only shows a preview, not the entire book. Since it requires Javascript, I decided to not use this API, and instead of reading, show more information about the book. Unfortunately I have not been able to get this far.

## Problems that arose
The problems that arose in order of occurence:
* Couldnt get the Unity project (with C# Scripting code) to call the API. 
_**Workaround:**_ Decided to use a seperate project to call the API and have it stored in JSON files. This project is called [Books API][5]. _**Fix:**_ Eventually figured out how to get the API call to work, needed the `.dll` files of the nuget packages in the `Asset` folder in Unity.
* Unity stops responding when entering play mode using code that calls the API. This doesn't occur when using code that read from JSON file (still needed API datatypes when reading file), _**Workaround:**_ so I decided to keep using file reading.
* Had build errors when building Unity project that had references (`.dll` files) to the Books API and Newtonsoft (installed with API, for reading JSON files) Tried this [potential solution][7], but couldn't get it to work. _**Workaround:**_ Decided on adding shelf and book information manually.
* Needed a way of switching to the next scene that allowed for parameters to pe bassed to the next scene (to know how many books were on the shelf that was clicked on). _**Fix:**_ Used [flashmandv's][8] answer which allows this parameter passing when switching scenes.
* The cursor that was added to be able to click on a shelf didn't show. First tried this [Tutorial by Microsoft][9], but that didn't work in this project. _**Fix:**_ Followed this [Tutorial/guide][10], and managed to get it to show.
* Tried to add the select gesture to be able to click on a shelf by following this [Tutorial by Microsoft][11] multiple times, but couldn't get it to work. Eventually tried this [Guide][12] a couple of times, but coulnd't get that to work either. As of yet, I have been unable to fix this problem.

## Improvements and expansion options
Stuff that can be added or improved to get this project working
* Fix or find a workaround for the gesture problem to allow switching scene on the HoloLens.
* Manually create datatypes that mimmick the API's datatypes. This way file reading might work on the HoloLens and the problem of manually adding shelves and books is fixed.
* Add an animation that shows the next couple of shelves, since 3 shelves has the right size according to testers
* Add a similair animation for showing the next couple of books on a shelf.
* Show specific information about 1 book, after selecting a shelf and a book on that shelf.
* Add an animation to go to the next book when showing details on 1 book.





[1]: https://developers.google.com/books/docs/overview
[2]: https://docs.microsoft.com/en-us/windows/mixed-reality/install-the-tools
[3]: https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-100#chapter-1---create-a-new-project
[4]: https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101#chapter-1---holo-world
[5]: https://github.com/thebaron2/BooksAPI
[6]: https://developers.google.com/books/docs/viewer/developers_guide
[7]: https://stackoverflow.com/questions/52868572/failed-to-run-reference-rewriter-with-command-error-with-unity-error-when-adding
[8]: https://forum.unity.com/threads/unity-beginner-loadlevel-with-arguments.180925/
[9]: https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101#chapter-2---gaze
[10]: https://abhijitjana.net/2016/05/19/adding-a-gaze-input-cursor-to-your-unity-3d-holographic-app/
[11]: https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101#chapter-3---gestures
[12]: https://abhijitjana.net/2016/05/29/understanding-the-gesture-and-adding-air-tap-gesture-into-your-unity-3d-holographic-app/
