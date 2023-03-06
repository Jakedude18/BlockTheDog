using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



namespace GameHandler{
    public class PetHandler : MonoBehaviour
    {
        public int petSpeed;
        private List<Vector3> targets;
        private bool moving;
        List<Animal> animals = new List<Animal>();
        public List<Transform> animalArt;

        public void addAnimals(List<Animal> animals){
            this.animals = animals;
            targets = new List<Vector3>(new Vector3[animals.Count]);
        }

        public bool moveAnimals(Tile[,] tiles){
            List<bool> escapes = new List<bool>(new bool[animals.Count]);
            for(int i = 0; i < animals.Count; i++){
                escapes[i] = moveAnimal(tiles, animals[i], animalArt[i], i);
            }
            foreach(bool escape in escapes){
                if(!escape) return false;
            }
            return true;
        }
        //returns if dog has escaped
        private bool moveAnimal(Tile[,] tiles, Animal animal, Transform animalArt, int i){
            DogMover dogMover = new DogMover(animal.dRow,animal.dCol);
            int direction = dogMover.BPSDirectionToMove(tiles, animal.row, animal.col);
            if(direction == -1){
                targets[i] = animalArt.position;
                return true;
            }
            else{
                targets[i] = animalArt.position + Vector3.right * (float) animal.dCol[direction] + Vector3.down * (float) animal.dRow[direction];
                animal.move(direction);
                moving = true;
                //check if dog has escaped 
                if(tiles[animal.row,animal.col].GetType() == typeof(Escape)){
                    SceneManager.LoadScene("Scenes/SWGameOver");
                }
            }
            return false;
        }

        void FixedUpdate(){
            if(moving){
                for(int i = 0; i < animals.Count; i++){
                    Transform movingAnimal = animalArt[i];
                    Vector3 target = targets[i];
                    Vector2 pos = Vector2.Lerp ((Vector2)movingAnimal.position, (Vector2)target, petSpeed * Time.fixedDeltaTime);
                    movingAnimal.position = new Vector3 (pos.x, pos.y, movingAnimal.position.z);    
                }
                moving = false;
                for(int i = 0; i < animals.Count; i++){
                    if(animalArt[i].position != targets[i]){
                        moving = true;
                        break;
                    }
                }
            }
        }
    }
}
