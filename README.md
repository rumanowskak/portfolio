# Katarzyna Rumanowska - Portfolio

## Table of Contents
1. [Flowchart Editor](#flowchart-editor)
1. [2048 Clone](#2048-clone)
1. [Function Approximator](#function-approximator)
1. [Lotka-Volterra Equations](#lotka-volterra-equations)

## Flowchart Editor
Flowchart editor made using Windows Forms. The functionality includes:

- Block functionality
    + Adding/deleting blocks of different types
    + Selecting and editing blocks
    + Moving blocks around the canvas
    + Connecting block nodes (Connecting output nodes to input nodes)
- Localisation (Polish and English languages are supported)
- Saving/Loading

Various edge cases are covered. The application is written with memory efficiency in mind.

---
## 2048 Clone
Clone of the popular game 2048 written using C++ and WinApi.
The clone implements all rules of the original game. The target value can be changed using menu items. Some additional changes are possible when modyfing the code (e.g. board size, smallest block value).

Upon exiting the current game state is saved and when user reopens the game the previous state is loaded.

---
## Function Approximator
MATLAB application that approximates functions using Legendre's polynomials. In order to do that the application also approximates value of integrals and uses numerical methods to optimise parameters.


---
## Lotka-Volterra Equations
MATLAB application that reads predator and prey population data from a given file and approximates the coefficients in the Lotka-Volterra equation that describes the population changes.

The application solves differential equations iteratively using a few different methods. It also uses ```fmincon``` to find optimal parameters for the equations. 


