# Unity Smooth Follow Camera System

A lightweight, robust, and reusable smooth follow camera system for both 3D and 2D games in Unity.

---

## ✨ Features

### 3D Version
* **Smooth Interpolation:** Predictable and buttery smooth Lerp tracking.
* **Spherical Dead Zone:** Target can move freely within a defined radius before the camera begins tracking, preventing rigid, motion-sickness-inducing movement.
* **Target-based Tracking:** Automatically calculates focus points and offsets.
* **Auto LookAt:** Dynamically updates rotation to always face the active focus point.
* **Editor Gizmos:** Visualizes the dead zone radius in the Scene View.

### 2D Version
* **Orthographic-Friendly:** Preserves Z-depth completely to prevent 2D sprite snapping or rendering errors.
* **Rectangular Dead Zone:** Allows classic platformer-style movement where the player can walk back and forth in the center of the screen without the camera shaking.
* **Axis Locking:** Independently lock the X or Y axis (perfect for vertical jumpers or endless runners).
* **Editor Gizmos:** Visualizes the dead zone box directly in the Scene View.

---

## 📦 Included Scripts

* "SmoothFollowCamera3D.cs"
* "SmoothFollowCamera2D.cs"

---

## 🎮 How to Use (3D)

1. Attach "SmoothFollowCamera3D" to your Camera.
2. Assign a target Transform (like your Player).
3. Adjust the offset and smoothing speed.
4. Set the "Dead Zone Radius" (Use the Scene View to see the green wire sphere representing the zone).
5. The Camera will automatically track and look at the target once it leaves the dead zone.

---

## 🎮 How to Use (2D)

1. Attach "SmoothFollowCamera2D" to your Camera.
2. Assign a target Transform.
3. Adjust the 2D offset.
4. Set your "Dead Zone Size" (X and Y dimensions). Use the Scene View to visualize the green bounding box.
5. Optionally lock the X or Y axis if your game requires it.

---

## 🧠 Design Notes

* **LateUpdate Implementation:** Camera logic strictly runs in "LateUpdate()" to ensure it follows the target **after** all physics and character movement have been processed for the frame. This completely eliminates camera jitter.
* **Focus Point Architecture:** Instead of snapping directly to the player's exact transform, the camera tracks a virtual "Focus Point". This point is dragged along by the player only when they hit the boundaries of the Dead Zone.
* **No Rigidbody Dependency:** The system does not rely on physics components, ensuring flawless compatibility with "CharacterController", Rigidbody movement, or simple Transform-based movement.

The system prioritizes clarity, modularity, and extensibility.

---

## 🚀 Possible Extensions

* **Camera Bounds:** Add min/max Vector clamps to prevent the camera from showing areas outside the level geometry.
* **Damping Curves:** Swap the linear "Mathf.Lerp" for an AnimationCurve or SmoothDamp to allow easing in and out of camera stops.
* **Shake Effect:** Add a public method to temporarily apply random Perlin Noise offsets to the camera for explosions or damage impacts.
* **ScriptableObject Presets:** Store different camera angles and dead zones in SOs to easily swap perspectives (e.g., changing from a wide exploration view to a tight combat view).

---

## 🛠 Unity Version

Tested in Unity6+ (should work without any problems in newer versions)

---

## 📜 License

MIT
