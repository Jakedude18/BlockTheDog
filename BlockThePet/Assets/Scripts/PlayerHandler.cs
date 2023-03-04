using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
// using MathF;


namespace GameHandler{
    public class PlayerHandler : MonoBehaviour
    {
        // fence prefab is set to "Top Layer" layer tag
        public GameObject fenceText;
        [SerializeField] GameObject fencePrefab;
        // public Text fenceKeeper;
        static double boardSize = 10;
        static double boardMultipler = boardSize/10;
        static double xOffset = 5;
        static double yOffset = 0;
        public int numFences = 6;

        // Start is called before the first frame update
        void Start()
        {
            Text fenceTextB = fenceText.GetComponent<Text>();
            fenceTextB.text = "Par: " + numFences;
            UpdateFences();
        }


        void UpdateFences() {
            Text fenceTextB = fenceText.GetComponent<Text>();
            fenceTextB.text = "Par: " + numFences;
            // fenceTextB.text = "Fences: " + numFences;
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


            // Debug.Log("numfences: " + numFences);
            if(board[row,col].GetType() != typeof(Grass)){
                throw new System.Exception("on boulder");
            }
            else if (numFences <= 0) {
                throw new System.Exception("no fences");
            }
            else{
                board[row,col] = new Fence();
                numFences -= 1;
                Debug.Log("fences left: " + numFences);
            }
            return board;
        }

    }
}