
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHandler{
    
    public class Chicken : Animal                
    {

        public override int[] dRow { get; set; } = {0, 0, 0, 0};
        public override int[] dCol { get; set; } = { 1, 0, -1, 0};
 
        public Chicken(int r, int c) : base(r,c)
        {
        
        }
        public override void move(int direction){
            row += dRow[direction];
            col += dCol[direction];
 
        }
    }
}