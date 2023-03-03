
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHandler{
    
    public class Dog : Animal                
    {
        public override int[] dRow { get; set; } = {0,1,0,-1};
        public override int[] dCol { get; set; } = {-1,0,1,0};

        public Dog(int r, int c) : base(r,c)
        {
        
        }
        public override void move(int direction){
            row += dRow[direction];
            col += dCol[direction];
            Debug.Log(row);
            Debug.Log(col);
        }
    }
}