using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardRenderer{
    public class BoardRenderer : MonoBehaviour
    {   
        public GameObject grassPrefab;
        public Transform boardTopLeft;
        private static int size = 10;
        int[,] tiles = new int[size,size];
        
        // Start is called before the first frame update
        void Start()
        {
            Vector3 position;
            for(int j = 0; j < size; j++){
                position = boardTopLeft.position + Vector3.down * (float)j;
                for(int k = 0; k < size; k++){
                    Instantiate(grassPrefab, position + Vector3.right * (float)k, Quaternion.identity);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}   
