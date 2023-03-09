# Duck Adventures

## Development

* Do NOT commit directly on main.

* Create a branch for each issue.


## Steps:

1. Download [Unity Hub](https://unity.com/download) 

2. When opening Unity Hub for the first time, it will prompt you to install the latest version of Unity, _skip installation_ and proceed to connect your account for your /personal license in the next step.

3.  Go to **Installs** > **Install Editor** > Install Unity 2021.3.20f1 with :exclamation:Android Build Support:exclamation: and it's complementary modules.
    - If anything fails, restart Unity Hub as administrator.

    - Keep Visual Studio 2019 checked.

4. Clone the git repository onto your local machine.

5. You can now open the cloned project from Unity Hub.


## Testing
0. If you want a video with all the steps, you cand find it [here](https://youtu.be/CGleQZVgdN4).

1. Download [Unity Remote 5](https://play.google.com/store/apps/details?id=com.unity3d.mobileremote&hl=en_US&pli=1) on your phone. (It is unavailable on Android 13).

2. Activate Developer options on your phone (**Settings** > **About phone** > **Software information** > **Build number** (tap 5 times)).

3. In **Settings** > **Developer options**, activate USB Debugging.

4. Connect yout phone to your PC with an USB Cable. Open Unity Remote 5 on your phone and the project in Unity (PC).

5. In Unity, go to Build Settings **(Ctrl + Shift + B)** and press Switch platform.

6. In Unity, go to **Edit** > **Project Settings** > **Editor**, and change the Device setting to Any Android Device.

7. Now, when you run the project, you can test it on your phone. If you are encountering errors, restart Unity.


## Preparing
1. Set the Aspect Ratio (from the Game tab) to 16:9 Landscape.

2. Go to **Edit** > **Project Settings** > **Editor**, and change the Resolution setting to Normal.

3. Go to **Edit** > **Project Settings** > **Player** > **Android(tab)**, and in the Resolution and Presentation tab check off the Portrait and Portrait Upside Down.
