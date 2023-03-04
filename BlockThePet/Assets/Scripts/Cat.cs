
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHandler{
    
    public class Cat : Animal                
    {

        public override int[] dRow { get; set; } = { -1, 1, 1, -1};
        public override int[] dCol { get; set; } = { -1 ,1, -1, 1};

        public Cat(int r, int c) : base(r,c)
        {
        
        }
        public override void move(int direction){
            row += dRow[direction];
            col += dCol[direction];
            Debug.Log("new row " + row);
            Debug.Log("new col " + col);
        }
    }
}