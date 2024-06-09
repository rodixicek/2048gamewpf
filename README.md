Sure! Here is the documentation formatted for a `.md` (Markdown) file:

---

# Projekt WPF 2048 - Documentation

## Overview

This project implements the popular 2048 game using Windows Presentation Foundation (WPF) in C#. The game consists of a 4x4 grid where the player moves tiles in four directions (up, down, left, right). When two tiles with the same number touch, they merge into one tile with the combined value. The objective is to reach the 2048 tile.

## Known Issues

In the current implementation of the 2048 game, a new tile with the value '2' spawns on the grid whenever the player presses any key. This behavior is incorrect because a new tile should only spawn when the player makes a valid move by pressing one of the arrow keys (Up, Down, Left, Right).
## Main Components

### MainWindow.xaml.cs

This is the main file that handles the game logic and user interactions.

#### Fields

- `public int[,] GameGrid`: A 2D array representing the game grid.
- `public SquareBox[,] Squares`: A 2D array of `SquareBox` objects for the UI.
- `public bool isEnd`: A flag indicating if the game has ended.
- `public int Score`: The player's current score.
- `public string ScoreText`: A dependency property for binding the score to the UI.

#### Dependency Properties

- `public static readonly DependencyProperty ScoreTextProperty`: Defines the `ScoreText` dependency property.

#### Methods

- `public MainWindow()`: Constructor that initializes the game.
- `public void LoadGame()`: Initializes a new game.
- `public void MakeTwo()`: Places a '2' tile on a random empty spot on the grid.
- `public void UpdateScreen()`: Updates the UI to reflect the current state of `GameGrid`.
- `public Brush GetColor(int number)`: Returns the color for a tile based on its value.
- `public void MoveUp()`: Moves tiles up and merges them if needed.
- `public void MoveDown()`: Moves tiles down and merges them if needed.
- `public void MoveRight()`: Moves tiles to the right and merges them if needed.
- `public void MoveLeft()`: Moves tiles to the left and merges them if needed.
- `public void Window_KeyDown(object sender, KeyEventArgs e)`: Handles keypress events to move the tiles.
- `public void CheckForWin()`: Checks if the player has won the game.
- `public void CheckForLoss()`: Checks if the player has lost the game.
- `private void NewGameClick(object sender, RoutedEventArgs e)`: Handles the "New Game" button click event.

### SquareBox

Represents an individual tile in the game grid. 

## Game Initialization

The game is initialized in the `MainWindow` constructor, which calls the `LoadGame` method. This method sets up the game grid, initializes the score, and places two '2' tiles randomly on the grid.

## Tile Movements

Tile movements are handled by the `MoveUp`, `MoveDown`, `MoveRight`, and `MoveLeft` methods. Each method performs three main actions:

1. Moves tiles in the specified direction.
2. Merges tiles with the same value.
3. Moves tiles again to fill any gaps created by the merges.

## User Input

User input is handled in the `Window_KeyDown` method. Depending on the key pressed (Up, Down, Left, Right), the corresponding move method is called. After each move, the game checks for win or loss conditions and updates the UI accordingly.

## Win and Loss Conditions

- `CheckForWin()`: Checks if any tile has the value 2048. If so, the game ends and a win message is displayed.
- `CheckForLoss()`: Checks if there are no more valid moves left. If so, the game ends and a loss message is displayed.

## UI Update

The `UpdateScreen()` method updates the visual representation of the game grid by setting the number and color of each `SquareBox` based on the current state of `GameGrid`.

## Starting a New Game

The `NewGameClick` method resets the game state, hides any endgame messages, and starts a new game by calling `MakeTwo` twice and updating the screen.

