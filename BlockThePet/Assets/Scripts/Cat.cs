
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHandler{
    
    public class Cat : Animal                
    {
        static public int[] dRow = { -1, 1, 1, -1 }; // The x-directions to move in (left, down, right, up)
        static public int[] dCol = { -1, 1, -1, 1 }; // The y-directions to move in (left, down, right, up)
        public Cat(int r, int c) : base(r,c)
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