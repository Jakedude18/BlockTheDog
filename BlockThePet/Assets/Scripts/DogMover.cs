using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameHandler{
    class DogMover
    {
        
        static public int[] dRow = { 0, 1, 0, -1 }; // The x-directions to move in (left, down, right, up)
        static public int[] dCol = { -1, 0, 1, 0 }; // The y-directions to move in (left, down, right, up)

        static bool[,] visited; // A boolean array to keep track of which cells have been visited
        static int[,] dist; // A 2D array to keep track of the distance to the starting cell
        static int rows, cols; // The number of rows and columns in the boolean array

        public int BPSDirectionToMove(Tile[,] maze, int startRow, int startCol)
        {
            rows = maze.GetLength(0); // Get the number of rows
            cols = maze.GetLength(1); // Get the number of columns


            int[] distances = new int[4];
            //find distances from each cardinal direction
            for (int i = 0; i < 4; i++)
            {
                int nRow = startRow + dRow[i]; // Get the x-coordinate of the neighboring cell
                int nCol = startCol + dCol[i]; // Get the y-coordinate of the neighboring cell
                // Check if the neighboring cell is within the bounds of the maze and is unvisited and is not blocked
                //Debug.Log(maze[nRow, nCol].isEmpty);
                if (nRow >= 0 && nRow < rows && nCol >= 0 && nCol < cols && maze[nRow, nCol].isEmpty)
                {
                    distances[i] = BFSFindShortestPath(maze, nRow, nCol);
                }
                else{
                    distances[i] = int.MaxValue;
                }
            }
            //find shortest distance
            int minDistance = int.MaxValue;
            int minIndex = 0;
            for(int i = 0; i < 4; i++){
                if(distances[i] < minDistance){
                    minIndex = i;
                    minDistance = distances[i];
                }
            }
            if(minDistance == int.MaxValue){
                return -1;
            }
             
            return minIndex;
        }

        private int BFSFindShortestPath(Tile[,] maze, int startRow, int startCol)
        {
            Queue<int[]> stack = new Queue<int[]>(); // A stack to store the current cell and its distance
            stack.Enqueue(new int[] { startRow, startCol, 0 }); // Push the starting cell onto the stack with a distance of 0
            visited = new bool[rows, cols]; // Initialize the visited array

            while (stack.Count > 0)
            {
                int[] current = stack.Dequeue(); // Pop the top cell off the stack
                int row = current[0]; 
                int col = current[1]; 
                int distance = current[2]; // Get the distance to the current cell

                visited[row, col] = true; // Mark the current cell as visited

                if (maze[row,col].GetType() == typeof(Escape)) // If we've reached the end cell, return the distance
                {
                    return distance;
                }

                // Otherwise, push all unvisited neighboring cells onto the stack
                for (int i = 0; i < 4; i++)
                {
                    int nRow = row + dRow[i]; // Get the x-coordinate of the neighboring cell
                    int nCol = col + dCol[i]; // Get the y-coordinate of the neighboring cell

                    // Check if the neighboring cell is within the bounds of the maze and is unvisited and is not blocked
                    if (nRow >= 0 && nRow < rows && nCol >= 0 && nCol < cols && !visited[nRow, nCol] && maze[nRow, nCol].isEmpty)
                    {
                        stack.Enqueue(new int[] { nRow, nCol, distance + 1 }); // Push the neighboring cell onto the stack with a distance of 1 more than the current cell
                    }
                }
            }
            
            return 0;
        }
    }
}