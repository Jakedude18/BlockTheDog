
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHandler{
    
    public class Bunny : Animal                
    {

        public override int[] dRow { get; set; } = {0, 2, 0, -2};
        public override int[] dCol { get; set; } = {2, 0, -2, 0};
 
        public Bunny(int r, int c) : base(r,c)
        {
        
        }
        public override void move(int direction){
            row += dRow[direction];
            col += dCol[direction];
        }
    }
}