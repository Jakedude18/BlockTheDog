using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



namespace GameHandler{
    public class PetHandler : MonoBehaviour
    {
        List<Animal> animals = new List<Animal>();
        public List<Transform> animalArt;

        public void addAnimals(List<Animal> animals){
            this.animals = animals;
        }

        public bool moveAnimals(Tile[,] tiles){
            Debug.Log("Count is " + animals.Count);
            List<bool> escapes = new List<bool>(new bool[animals.Count]);
            for(int i = 0; i < animals.Count; i++){
                Debug.Log("animal art count is " + animalArt.Count);
                Debug.Log(animalArt[0]);
                Debug.Log(animalArt[i]);
                escapes[i] = moveAnimal(tiles, animals[i], animalArt[i]);
            }
            foreach(bool escape in escapes){
                if(!escape) return false;
            }
            return true;
        }
        //returns if dog has escaped
        private bool moveAnimal(Tile[,] tiles, Animal animal, Transform animalArt){
            DogMover dogMover = new DogMover(animal.dRow,animal.dCol);
            int direction = dogMover.BPSDirectionToMove(tiles, animal.row, animal.col);
            if(direction == -1){
                return true;
            }
            else{
                animalArt.position += Vector3.right * (float) animal.dCol[direction] + Vector3.down * (float) animal.dRow[direction];
                animal.move(direction);
                //check if dog has escaped 
                if(tiles[animal.row,animal.col].GetType() == typeof(Escape)){
                    SceneManager.LoadScene("Scenes/SWGameOver");
                }
            }
            return false;
        }
    }
}
