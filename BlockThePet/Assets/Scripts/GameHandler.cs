using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace GameHandler{
    public class GameHandler : MonoBehaviour
    {   
        public static int curScene = 0;
        public GameObject grassPrefab;
        public GameObject boulderPrefab;
        public GameObject escapePrefab;
        public GameObject fencePrefab;
        public GameObject PlayerHandler;
        public GameObject PetHandler;
        // public GameObject PauseHandlerScript;
        private PetHandler PetHandlerScript;
        private PlayerHandler playerHandlerScript;
        public Transform boardTopLeft;
        public TextAsset mapTextFile;
        public TextAsset animalsTextFile;
        private static int size = 10;
        public bool isPlayerTurn = true;
        Tile[,] tiles = new Tile[size,size];

        
        // Start is called before the first frame update
        void Start()
        {
            playerHandlerScript = PlayerHandler.GetComponent<PlayerHandler>();
            PetHandlerScript = PetHandler.GetComponent<PetHandler>();
            // PauseHandlerScript = PauseHandler.GetComponent<PauseHandler>();
            readInMap();
            renderMap();
            readInAnimals();   
        }


        void readInAnimals(){
            List<Animal> animals = new List<Animal>();
            string text = animalsTextFile.text;
            text = text.Replace("\n", "").Replace("\r", "");
            for(int i = 1; i < text[0] - '0'; i++){
                char type = text[i*3];
                Debug.Log("iteration " + i);
                int row = text[i*3+1] - '0';
                int col = text[i*3+2] - '0';
                if(type == 'd'){
                    animals.Add(new Dog(row, col));
                }
                if(type == 'k'){
                    animals.Add(new Cat(row, col));
                }
                if(type == 'c'){
                    animals.Add(new Chicken(row, col));
                }
                if(type == 'b'){
                    animals.Add(new Bunny(row, col));
                }
            }
            PetHandlerScript.addAnimals(animals);

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
        
  
        void Update() //make a turn handler so that it alternates between dog and fence
        {
            if(Input.GetMouseButtonDown(0)){
                try{
                    isPlayerTurn = false;
                    tiles = playerHandlerScript.placeFence(tiles);
                }
                catch(System.Exception e){
                    if (e.Message == "on boulder") {
                        Debug.Log("Can't put fence on boulder");
                        isPlayerTurn = true;
                    }
                    else if (e.Message == "no fences")  {
                        //SceneManager.LoadScene("Scenes/SWGameOver");
                        Debug.Log("No more fences");
                    }
                    isPlayerTurn = true;

                }

                renderMap();
            }
            if(!isPlayerTurn)
            {
                bool animalEscape;
                //move Dog
                
                animalEscape = PetHandlerScript.moveAnimals(tiles);

                if(animalEscape){
                    SceneManager.LoadScene("Scenes/success");
                }
                isPlayerTurn = true;
            }

            // pause and resume
            //PauseHandlerScript.Update();
            // if (Input.GetKeyDown(KeyCode.Space)){
            //         if (PauseHandlerScript.GameisPaused){
            //             PauseHandlerScript.Resume();
            //         }
            //         else{
            //             PauseHandlerScript.Pause();
            //         }
            // }
            

            if (Input.GetKey("escape")){
                //This is capturing the escape key correctly but Application.Quit isn't doing anything ig
                //Apparently, this is ignored in the unity editor but will work after exported
                Application.Quit();
            }
       
        }
        
        //TODO: will update in pausehandler script later


        public void StartGame(){
            SceneManager.LoadScene("start_scene");
        }

        public void RulesGame() {
            SceneManager.LoadScene("rules_scene");
        }

        public void OpenGame(){
            curScene = 0;
            SceneManager.LoadScene("dog_lvl");
        }

        public void nextGame(){
            curScene++;
            SceneManager.LoadScene(curScene);
        }

        public void RestartGame(){
            Time.timeScale = 1f;
            OpenGame();
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
