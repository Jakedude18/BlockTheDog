using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// using MathF;


namespace GameHandler{
    public class PlayerHandler : MonoBehaviour
    {
        // fence prefab is set to "Top Layer" layer tag
        [SerializeField] GameObject fencePrefab;
        static double boardSize = 10;
        static double boardMultipler = boardSize/10;
        static double xOffset = 5;
        static double yOffset = 0;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(boardMultipler);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public Tile[,] placeFence(Tile[,] board) {
            Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            double newX = System.Math.Floor((spawnPosition.x - 5)*boardMultipler);
            double newY = System.Math.Floor((spawnPosition.y) *boardMultipler);

            // getting array indices 
            int row = (int)(5*boardMultipler - newY - 1);
            int col = (int)(newX + 10*boardMultipler);
            Debug.Log("row: " + row);
            Debug.Log("col: " + col);



            if(board[row,col].GetType() != typeof(Grass)){
                throw new System.Exception("Hello");
            }
            else{
                board[row,col] = new Fence();
            }
            return board;
        }

        public void test() {
            Debug.Log("test");
        }
    }
}