using System;
using System.Collections.Generic;
using UnityEngine;


class DFS
{
    static int[] dx = { -1, 0, 1, 0 }; // The x-directions to move in (left, down, right, up)
    static int[] dy = { 0, 1, 0, -1 }; // The y-directions to move in (left, down, right, up)

    static bool[,] visited; // A boolean array to keep track of which cells have been visited
    static int[,] dist; // A 2D array to keep track of the distance to the starting cell
    static int rows, cols; // The number of rows and columns in the boolean array

    static void Main(string[] args)
    {
        bool[,] maze = { // The boolean array representing the maze
            {true, true, true, true},
            {true, false, true, true},
            {true, false, true, false},
            {true, true, true, true}
        };

        rows = maze.GetLength(0); // Get the number of rows
        cols = maze.GetLength(1); // Get the number of columns

        visited = new bool[rows, cols]; // Initialize the visited array
        dist = new int[rows, cols]; // Initialize the distance array

        int shortestPath = DFSFindShortestPath(maze, 0, 0, rows - 1, cols - 1); // Find the shortest path

        Debug.Log(shortestPath); // Print the shortest path
    }

    static int DFSFindShortestPath(bool[,] maze, int startX, int startY, int endX, int endY)
    {
        Stack<int[]> stack = new Stack<int[]>(); // A stack to store the current cell and its distance
        stack.Push(new int[] { startX, startY, 0 }); // Push the starting cell onto the stack with a distance of 0

        while (stack.Count > 0)
        {
            int[] current = stack.Pop(); // Pop the top cell off the stack
            int x = current[0]; // Get the x-coordinate of the current cell
            int y = current[1]; // Get the y-coordinate of the current cell
            int distance = current[2]; // Get the distance to the current cell

            visited[x, y] = true; // Mark the current cell as visited
            dist[x, y] = distance; // Store the distance to the current cell

            if (x == endX && y == endY) // If we've reached the end cell, return the distance
            {
                return distance;
            }

            // Otherwise, push all unvisited neighboring cells onto the stack
            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i]; // Get the x-coordinate of the neighboring cell
                int ny = y + dy[i]; // Get the y-coordinate of the neighboring cell

                // Check if the neighboring cell is within the bounds of the maze and is unvisited and is not blocked
                if (nx >= 0 && nx < rows && ny >= 0 && ny < cols && !visited[nx, ny] && maze[nx, ny])
                {
                    stack.Push(new int[] { nx, ny, distance + 1 }); // Push the neighboring cell onto the stack with a distance of 1 more than the current cell
                }
            }
        }
        return 0;
    }
}
