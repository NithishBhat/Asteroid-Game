# Asteroids (Unity 2D)

My take on the classic arcade game Asteroids, built in Unity with C#. You fly a small ship, shoot rocks that break into smaller pieces when hit, and try to stay alive as long as you can; a timer on screen shows how long you lasted. The repo has the full Unity project and a build that runs in the browser.

## How it works

The ship moves with real 2D physics: rotating and thrusting apply forces, so it drifts like it would in space. Left Ctrl fires a bullet in the direction you're facing, and bullets disappear after two seconds. Big asteroids split into two smaller rocks when shot; small ones are destroyed. Anything that flies off one edge of the screen comes back on the opposite side.

Asteroids spawn from the four screen edges with random directions and speeds. There are explosion animations and sound effects for shooting, hits and dying.

## Running it

**In the browser:** `Asteroid game (Final Build)/` is a Unity WebGL build. Serve that folder with any static web server and open `index.html` (browsers usually block Unity WebGL builds opened straight from disk).

**From source:** open `Asteroid game (SourceCode and Assets)/` in Unity Hub with Unity 2019.2.x, load `Assets/scenes/scene0.unity`, and press Play.

## Layout

```
Asteroid game (Final Build)/            WebGL build
Asteroid game (SourceCode and Assets)/
  Assets/
    scripts/      Ship, asteroid, smallrock, bullet, spawner, HUD, Timer,
                  ScreenUtils, AudioManager, Explosion, ...
    prefabs/      ship, bullet, rock variants, explosion
    sprites/      art
    audio/        sound effects
    animations/   explosion animation
    scenes/       scene0.unity
```
