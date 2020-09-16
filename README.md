# GTA Style 3rd Person Controller / Camera Example
Simple 3rd person controller example for Unity demonstrating camera-relative movement, root motion animation and the new Cinemachine 3rd Person Follow / Aim system

![ThirdPersonController](/Docs/ThirdPersonController.gif)

Full video

https://www.youtube.com/watch?v=e9YOstnzfKY

There are 2 core scripts:

**CharController.cs**

This is the main character controller. Using a super simple 1D linear animation controller and root motion for the character movement, this script provides camera-relative movement and animation for a character (similar to GTA).

![CharacterController](/Docs/CharacterController.png)

The Animation Controller is very simple and only requires 2 animations, Idle & Walk.

This may get extended to add more animations (run etc), but I wanted to keep it as simple as possible.

**ThirdPersonCameraController.cs**

This script wraps the new 3rd person follow camera extension that ships with Cinemachine 2.6.x and higher.

Supports toggling which side the camera is on (ala Ghost Recon Wildlands) and also exposes inverting for vertical and horizontal camera rotations.

![CameraController](/Docs/CameraController.png)

# Usage, etc #
Project is setup for 2019.4.5f1, and this repo uses Git LFS.

Licensed under the MIT License
