# 🎲 Ludo Board Game (VB.NET)

A fully functional multiplayer Ludo board game built with VB.NET and Windows Forms. This project simulates the classic Ludo experience with animated dice rolling, step-by-step pawn movement, collision-based capture mechanics, and a dedicated winning path system for each player color.

## 🌟 Key Features

* **Multiplayer Support**: Playable by 2 to 4 players (Blue, Red, Green, Yellow).
* **Classic Ludo Mechanics**:
  * You need to roll a **6** to bring a piece out of the base.
  * Turn-based logic with automatic turn rotation to the next active player.
  * **Capturing Opponents**: Landing exactly on an opponent's piece captures it and sends it back to their base.
* **Winning Paths**:
  * Each color has its own safe zone (winning path) leading to the finish.
  * Requires an exact dice roll to move to the final finish tile.
* **Match Progression & Ranking**:
  * Tracks player progress. Once a player gets all 4 pieces to the finish line, they win.
  * The game continues for the remaining players to determine 2nd, 3rd, and 4th place rankings.
* **Save / Load Game System**:
  * Save your current game state to a local text file and resume playing later without losing progress.
* **Animated UI**:
  * Smooth step-by-step piece movement and animated dice rolls.

## 🛠️ Technology Stack

* **Language**: Visual Basic .NET (VB.NET)
* **Framework**: Windows Forms (WinForms), .NET Framework
* **Architecture**: Object-Oriented Programming (OOP) utilizing dedicated classes (`Pemain`, `Pion`, `Ludo`) for separating game logic from UI representation.

## 📂 Project Structure

* **`FormUtama.vb`**: The main game board UI and event handler (dice rolling, clicking pieces, handling turns).
* **`Ludo.vb`**: Core game manager class that tracks players, scores, and board layout.
* **`Pemain.vb`**: Represents a player, storing their color, active status, name, and their collection of pieces.
* **`Pion.vb`**: Represents an individual piece (pawn), handling its specific location on the board, movement path, and status (in base, on board, finished).
* **`setting.vb` / `langkah.vb`**: Stores board coordinates, specific step paths for each color, and global game variables.

## 🚀 How to Run

1. Clone or download this repository.
2. Open **`Projek_Final.sln`** using Microsoft Visual Studio.
3. Make sure the Startup Project is set to `Projek_Final`.
4. Press `F5` or click **Start** to build and run the game.

## 📝 License

This project was created as a final project. Feel free to explore, learn from, and modify the code!
