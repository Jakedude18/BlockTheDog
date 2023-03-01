
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHandler{

    public class Animal                
    {
        public int row;
        public int col;
        static public int[] dRow;
        static public int[] dCol;
        public Animal(int r, int c) {
            row = r;
            col = c;
        }

    }
    
}