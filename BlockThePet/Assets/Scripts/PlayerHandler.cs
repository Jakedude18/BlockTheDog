using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using MathF;


namespace GameHandler{
    public class PlayerHandler : MonoBehaviour
    {
        // fence prefab is set to "Top Layer" layer tag
        [SerializeField] GameObject fencePrefab;
        static double boardSize = 10.0;
        static double boardMultipler = boardSize/10.0;
        static double xOffset = 5.0;
        static double yOffset = 0.0;

        
        // fencePrefab.transform.localScale = new Vector3(3.2*boardMultipler, 3.2*boardMultipler, 1);

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0)){
                Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                double newX = System.Math.Floor((spawnPosition.x - 5)*boardMultipler);
                double newY = System.Math.Floor((spawnPosition.y) *boardMultipler);

                newX = ((newX+0.5)/boardMultipler) + xOffset;
                newY = ((newY+0.5)/boardMultipler) + yOffset;

                Vector2 centeredSpawn = new Vector2((float)newX, (float)newY);
                // GameObject g = Instantiate(fencePrefab, (Vector2)spawnPosition, Quaternion.identity);
                GameObject fence = Instantiate(fencePrefab, centeredSpawn, Quaternion.identity);
                fence.transform.localScale = new Vector3((float)(3.2/boardMultipler), (float)(3.2/boardMultipler), 1);

                // getting array indices
                int row = (int)(4*boardMultipler - newY);
                int col = (int)(newX + 10*boardMultipler);
                Debug.Log("row: " + row);
                Debug.Log("col: " + col);
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