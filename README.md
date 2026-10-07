# Asteroids (Unity 2D)

A 2D Asteroids-style arcade game built in Unity with C#. Fly a ship, shoot asteroids that break apart on impact, and survive as long as you can. The repo includes the full Unity project and a WebGL build.

## Tech Stack

- Unity 2019.2.8f1 (2D physics: `Rigidbody2D`, `CircleCollider2D`)
- C#
- WebGL build target

## Features

- **Physics-based ship movement**: rotation and thrust applied as forces on a `Rigidbody2D`
- **Shooting**: Left Ctrl fires bullets in the ship's facing direction; bullets expire after 2 seconds via a reusable `Timer` component
- **Splitting asteroids**: large asteroids spawn two smaller rocks when hit; small rocks are destroyed outright
- **Screen wrapping**: the ship, bullets and asteroids wrap around screen edges (`ScreenUtils` caches screen bounds in world coordinates)
- **Randomized spawning**: asteroids of three types spawn at the four screen edges with random direction and impulse
- **Explosions and audio**: animated explosion prefab plus a static `AudioManager` for shoot, hit and death sounds
- **HUD**: survival timer that stops when the ship is destroyed

## Running It

**WebGL build:** `Asteroid game (Final Build)/` contains a Unity WebGL export. Serve that folder with any static web server and open `index.html` (browsers generally block Unity WebGL builds opened directly from the file system).

**From source:** open `Asteroid game (SourceCode and Assets)/` in Unity Hub with Unity 2019.2.x, load `Assets/scenes/scene0.unity`, and press Play.

## Project Structure

```
Asteroid game (Final Build)/            WebGL build (index.html, Build/, TemplateData/)
Asteroid game (SourceCode and Assets)/
  Assets/
    scripts/      Ship, asteroid, smallrock, bullet, spawner, HUD, Timer,
                  ScreenUtils, AudioManager, Explosion, ...
    prefabs/      ship, bullet, rock variants, explosion
    sprites/      ship, rock, bullet and explosion art
    audio/        shoot / hit / die sound effects
    animations/   explosion animation + controller
    scenes/       scene0.unity
  ProjectSettings/, Packages/
```
