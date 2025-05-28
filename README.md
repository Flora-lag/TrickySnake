# 🐍 TrickySnake

**TrickySnake** is a classic yet challenging snake game built with **C# (.NET Framework 4.8)** using **Windows Forms**.  
Your goal is to collect as many points as possible while navigating tricky fruit effects and increasing speed.

---

## 🎮 Gameplay Instructions

### Controls
- Use **W, A, S, D** keys to control the snake's direction.

### Scoring System & Fruits

| Fruit      | Appearance                    | Effect                                        |
|------------|-------------------------------|-----------------------------------------------|
| 🍎 Apple    | Red Circle                    | +1 point, +1 body segment                     |
| 🍓 Strawberry | Salmon Triangle              | +2 points, +2 body segments                   |
| 🥭 Mango    | Dark Gold Polygon             | Doubles score and snake length               |
| 🍋 Lemon    | Light Lemon Half-Circle       | Halves score and snake length                |
| 🪨 Rock     | Dark Grey Rectangle          | Shrinks snake to only the head – **Game Over** |

---

## ⏱️ Timed Fruit Effects

- **All fruits** disappear after **20 seconds** if not eaten.
- If a **Lemon** or **Rock** is generated, a **positive fruit** (Apple, Strawberry, or Mango) also appears.
- If a fruit disappears:
  - Snake loses **1 segment**
  - Score decreases by **1**
  - If only the snake's head remains – **Game Over**

---

## ⚡ Speed Increase

- Snake speed increases every **25 points** scored.
- A **"Speed Increase"** label is displayed each time the game speeds up.

---

## 💻 Requirements

- .NET Framework **4.8**
- Windows OS
- Visual Studio (recommended for building/running)

---

## 🚀 Getting Started

1. Clone or download the repository.
2. Open the `.sln` file in Visual Studio.
3. Build and run the project.
4. Use `Start` to begin the game.

---

## 📷 Screenshot Feature

Click the **"Screenshot"** button to save an image of your current game board along with your score.

---

## 📜 License

This project is open-source. Feel free to use, modify, or contribute.

---

## 👨‍💻 Author

Created by ****Flora-lag****

