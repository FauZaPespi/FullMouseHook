

# GlobalMouseHook

**Author:** FauZaPespi  
**Date:** 13.11.2024  

Tired of having to rehook for each project? Use this already pre-made hook to call events at the right time, everything is perfect, use us

---

## Description

A .NET library designed to globally hook mouse events, providing real-time monitoring and simulation of mouse actions. This library enables developers to intercept, track, and simulate mouse clicks programmatically.

[Github repo](https://github.com/FauZaPespi/FullMouseHook)

[Discord profile](https://discord.com/users/1172167256470474775)

---

## Features

- **Global Mouse Hooking:**
  - Tracks mouse button events globally across the system.
  - Monitors cursor position during mouse events.

- **Mouse Button State Tracking:**
  - Detects and stores the state of the left and right mouse buttons (`IsKeepingLeftDown`, `IsKeepingRightDown`).

- **Mouse Click Simulation:**
  - Simulate left and right mouse button presses and releases (`SendLeftDown`, `SendLeftUp`, `SendRightDown`, `SendRightUp`).

- **Customizable Event Handling:**
  - Raises a `GlobalMouseClick` event when a mouse button is pressed or released, with details of the button and cursor position.

---

## Getting Started

### Prerequisites
- .NET Framework or .NET Core compatible runtime.
- Administrative privileges to hook global system events.

### Installation
Clone or download the repository and include the `GlobalMouseHook` class in your project.

---

## Usage

### 1. Set Up Global Mouse Hook
Instantiate the `GlobalMouseHook` class to start monitoring mouse events globally.

```csharp
var mouseHook = new GlobalMouseHook();
mouseHook.GlobalMouseClick += (button, position) =>
{
    Console.WriteLine($"Button: {button}, Position: {position}");
};
```
### 2. Check Mouse Button States
Use these methods to check the current state of the mouse buttons:

```csharp

bool isLeftButtonPressed = mouseHook.IsLeftDown();
bool isRightButtonPressed = mouseHook.IsRightDown();

bool isLeftHeld = mouseHook.IsKeepingLeftDown();
bool isRightHeld = mouseHook.IsKeepingRightDown();
```
### 3. Simulate Mouse Actions
Simulate mouse clicks programmatically:

```csharp
mouseHook.SendLeftDown();
mouseHook.SendLeftUp();

mouseHook.SendRightDown();
mouseHook.SendRightUp();
```
### 4. Clean Up Resources
Unhook the mouse hook when it is no longer needed:

```csharp
mouseHook.Unhook();
```

## Functionality

| Functionality                                         | Description                                                                                   |
| ----------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| [`SetHook()`](#sethook)                               | Sets up a global mouse hook using `SetWindowsHookEx`.                                         |
| [`Unhook()`](#unhook)                                 | Releases the global mouse hook using `UnhookWindowsHookEx`.                                   |
| [`HookCallback()`](#hookcallback)                     | Processes mouse events and raises the `GlobalMouseClick` event.                               |
| [`GlobalMouseClick`](#globalmouseclick-event) (event) | Raised when a mouse button is pressed or released, providing button name and cursor position. |
| [`IsLeftDown()`](#isleftdown)                         | Checks if the left mouse button is currently pressed.                                         |
| [`IsRightDown()`](#isrightdown)                       | Checks if the right mouse button is currently pressed.                                        |
| [`IsKeepingLeftDown()`](#iskeepingleftdown)           | Checks if the left mouse button is being held down.                                           |
| [`IsKeepingRightDown()`](#iskeepingrightdown)         | Checks if the right mouse button is being held down.                                          |
| [`SendLeftDown()`](#sendleftdown)                     | Simulates a left mouse button press.                                                          |
| [`SendLeftUp()`](#sendleftup)                         | Simulates a left mouse button release.                                                        |
| [`SendRightDown()`](#sendrightdown)                   | Simulates a right mouse button press.                                                         |
| [`SendRightUp()`](#sendrightup)                       | Simulates a right mouse button release.                                                       |

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
