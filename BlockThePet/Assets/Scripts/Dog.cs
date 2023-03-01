
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHandler{
    
    public class Dog : Animal                
    {
        static public int[] dRow = { 0, 1, 0, -1 }; // The x-directions to move in (left, down, right, up)
        static public int[] dCol = { -1, 0, 1, 0 }; // The y-directions to move in (left, down, right, up)
        public Dog(int r, int c) : base(r,c)
        {
        
        }
        public void move(int direction){
            row += dRow[direction];
            col += dCol[direction];
            Debug.Log(row);
            Debug.Log(col);
        }
    }
}