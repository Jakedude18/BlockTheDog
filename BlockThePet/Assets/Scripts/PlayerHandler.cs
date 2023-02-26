using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameHandler{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] GameObject fencePrefab;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0)){
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject g = Instantiate(fencePrefab, (Vector2)spawnPosition, Quaternion.identity);
            }
        }

        public void test() {
            Debug.Log("bum bum");
        }
    }
}