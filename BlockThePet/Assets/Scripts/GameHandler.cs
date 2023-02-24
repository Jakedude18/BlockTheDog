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
        public GameObject PlayerHandler;
        public Transform boardTopLeft;
        public TextAsset mapTextFile;
        private static int size = 10;
        Tile[,] tiles = new Tile[size,size];
        
        // Start is called before the first frame update
        void Start()
        {
            readInMap();
            renderMap();
            PlayerHandler playerHandlerScript = PlayerHandler.GetComponent<PlayerHandler>();
            playerHandlerScript.test();
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
                }
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("escape")){
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
