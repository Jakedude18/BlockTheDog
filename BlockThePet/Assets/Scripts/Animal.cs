
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHandler{

    public class Animal                
    {
        public int row;
        public int col;
        public virtual int[] dRow { get; set; } = {0,0,0,0};
        public virtual int[] dCol { get; set; } = {0,0,0,0};

        public Animal(int r, int c) {
            row = r;
            col = c;
        }

        public virtual void move(int direction){

        }
    }
    
}