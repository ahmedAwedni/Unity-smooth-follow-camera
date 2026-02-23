# Unity Smooth Follow Camera System

A lightweight and reusable smooth follow camera system for both 3D and 2D games in Unity.

---

## ✨ Features

### 3D Version
- Smooth position interpolation
- Adjustable follow offset
- Target-based tracking
- Automatic LookAt behavior
- Clean LateUpdate-based implementation

### 2D Version
- Orthographic-friendly follow
- Adjustable 2D offset
- Axis locking (X or Y)
- Z-depth preservation
- Smooth interpolation

---

## 📦 Included Scripts

- SmoothFollowCamera3D.cs
- SmoothFollowCamera2D.cs

---

## 🎮 How to Use (3D)

1. Attach 'SmoothFollowCamera3D' to your Camera.
2. Assign a target Transform.
3. Adjust offset and smoothing speed.
4. Camera will automatically look at the target.

---

## 🎮 How to Use (2D)

1. Attach 'SmoothFollowCamera2D' to your Camera.
2. Assign a target Transform.
3. Adjust 2D offset.
4. Optionally lock X or Y axis.
5. Works best with Orthographic camera.

---

## 🧠 Design Notes

- Camera logic runs in 'LateUpdate()' to ensure it follows the target **after** movement has been processed.
- 'Vector3.Lerp()' is used for predictable and smooth interpolation.
- The 2D version preserves Z depth to prevent camera snapping.
- Axis locking allows platformer-style behavior.
- No rigidbody dependency ensures compatibility with:
  - CharacterController
  - Rigidbody movement
  - Transform-based movement

The system prioritizes clarity, modularity, and extensibility.

---

## 🚀 Possible Extensions

- Dead zones
- Camera bounds
- Damping curves
- Dynamic zoom
- Shake effect
- ScriptableObject presets

---

## 🛠 Unity Version

Tested in Unity6+ (should work without any problems in newer versions)

---

## 📜 License

MIT
