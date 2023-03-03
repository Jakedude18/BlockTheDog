using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



namespace GameHandler{
    public class PetHandler : MonoBehaviour
    {
        public Transform DogArt;
        public Transform CatArt;
        private Dog dog = new Dog(4, 4);
        private Cat cat = new Cat(4,5);

        //returns if dog has escaped
        public bool moveDog(Tile[,] tiles){
            DogMover dogMover = new DogMover(Dog.dRow,Dog.dCol);
            int direction = dogMover.BPSDirectionToMove(tiles, dog.row, dog.col);
            if(direction == -1){
                return true;
            }
            else{
                DogArt.position += Vector3.right * (float) Dog.dCol[direction] + Vector3.down * (float) Dog.dRow[direction];
                dog.move(direction);
                //check if dog has escaped 
                if(tiles[dog.row,dog.col].GetType() == typeof(Escape)){
                    SceneManager.LoadScene("Scenes/SWGameOver");
                }
            }
            return false;
        }

        public bool moveCat(Tile[,] tiles){
            DogMover dogMover = new DogMover(Cat.dRow,Cat.dCol);
            int direction = dogMover.BPSDirectionToMove(tiles, cat.row, cat.col);
            if(direction == -1){
                return true;;
            }
            else{
                CatArt.position += Vector3.right * (float) Cat.dCol[direction] + Vector3.down * (float) Cat.dRow[direction];
                cat.move(direction);
                //check if cat has escaped 
                if(tiles[cat.row,cat.col].GetType() == typeof(Escape)){
                    SceneManager.LoadScene("Scenes/SWGameOver");
                }
            }
            return false;
        }
    }
}
