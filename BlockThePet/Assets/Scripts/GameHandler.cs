using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace GameHandler{
    public class GameHandler : MonoBehaviour
    {   
        public GameObject grassPrefab;
        public GameObject boulderPrefab;
        public GameObject escapePrefab;
        public GameObject fencePrefab;
        public GameObject PlayerHandler;
        private PlayerHandler playerHandlerScript;
        public Transform Dog;
        public Transform boardTopLeft;
        public TextAsset mapTextFile;
        private static int size = 10;
        public bool isPlayerTurn = true;
        Tile[,] tiles = new Tile[size,size];
        
        // Start is called before the first frame update
        void Start()
        {
            playerHandlerScript = PlayerHandler.GetComponent<PlayerHandler>();
            readInMap();
            renderMap();
        }

        void readInMap(){
            string text = mapTextFile.text;  //this is the content as string
            text = text.Replace("\n", "").Replace("\r", "");
            // Store each line in array of strings
            for(int i = 0; i < size; i++){
                for(int j = 0; j < size; j++){
                    char curr = text[i*(size)+j];
                    if(curr == '0'){
                        tiles[i,j] = new Boulder();
                    }
                    else if(curr == '2'){
                        tiles[i,j] = new Escape();
                    }
                    else if(curr == '1'){
                        tiles[i,j] = new Grass();
                    }
                }
            }
        }

        void renderMap(){
            Vector3 position;
            for(int j = 0; j < size; j++){
                position = boardTopLeft.position + Vector3.down * (float)j;
                for(int k = 0; k < size; k++){
                    if(tiles[j,k].GetType() == typeof(Grass)){
                        Instantiate(grassPrefab, position + Vector3.right * (float)k, Quaternion.identity);
                    }
                    if(tiles[j,k].GetType() == typeof(Boulder)){
                        Instantiate(boulderPrefab, position + Vector3.right * (float)k, Quaternion.identity);
                    }
                    if(tiles[j,k].GetType() == typeof(Escape)){
                        Instantiate(escapePrefab, position + Vector3.right * (float)k, Quaternion.identity);
                    }
                    if(tiles[j,k].GetType() == typeof(Fence)){
                        Instantiate(fencePrefab, position + Vector3.right * (float)k, Quaternion.identity);
                    }
                }
            }
        }

        // COMMENTED OUT 2/26
        // Update is called once per frame
        
        public float moveInterval = 2;
        private int dogRow = 4;
        private int dogCol = 4;
        void Update() //make a turn handler so that it alternates between dog and fence
        {
            if(Input.GetMouseButtonDown(0)){
                try{
                    isPlayerTurn = false;
                    tiles = playerHandlerScript.placeFence(tiles);
                }
                catch(System.Exception e){
                    Debug.Log("Can't put fence on boulder");
                    isPlayerTurn = true;
                }
                renderMap();
            }
            if(!isPlayerTurn)
            {
                //timer to let dog think

                DogMover dogMover = new DogMover();
                int direction = dogMover.BPSDirectionToMove(tiles, dogRow, dogCol);
                //move dog 
                Dog.position += Vector3.right * (float) DogMover.dCol[direction] + Vector3.down * (float)DogMover.dRow[direction];
                dogRow += DogMover.dRow[direction];
                dogCol += DogMover.dCol[direction];
                moveInterval = 2;
                isPlayerTurn = !isPlayerTurn;
                //check if dog has gotten a language 
                if(tiles[dogRow,dogCol].GetType() == typeof(Escape)){
                    SceneManager.LoadScene("SWGameOverScene");
                }
            }
            
            if (Input.GetKey("escape")){
                //This is capturing the escape key correctly but Application.Quit isn't doing anything ig
                //Apparently, this is ignored in the unity editor but will work after exported
                Application.Quit();
            }
        }
        

        public void StartGame(){
            SceneManager.LoadScene("Scene1");
        }

        public void OpenGame(){
            SceneManager.LoadScene("Jake_scene");
        }

        public void RestartGame(){
            SceneManager.LoadScene("Scene1");
        }

        public void QuitGame(){
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

    }
}   
