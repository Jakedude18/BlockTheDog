using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            if(Input.GetMouseButtonDown(0)){
                Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                double newX = System.Math.Floor((spawnPosition.x - 5)*boardMultipler);
                double newY = System.Math.Floor((spawnPosition.y) *boardMultipler);

                // getting array indices 
                int row = (int)(5*boardMultipler - newY - 1);
                int col = (int)(newX + 10*boardMultipler);
                Debug.Log("row: " + row);
                Debug.Log("col: " + col);

                // get new x and y coords based on fence index later
                newX = ((newX+0.5)/boardMultipler) + xOffset;
                newY = ((newY+0.5)/boardMultipler) + yOffset;

                Vector2 centeredSpawn = new Vector2((float)newX, (float)newY);
                GameObject fence = Instantiate(fencePrefab, centeredSpawn, Quaternion.identity);
                fence.transform.localScale = new Vector3((float)(3.2/boardMultipler), (float)(3.2/boardMultipler), 1);
            }
        }

        public Tile[,] placeFence(Tile[,] board) {
            // TO DO
            // once can edit gamehandler, make it so fences can only be placed on empty spaces
            return board;
        }

        public void test() {
            Debug.Log("test");
        }
    }
}