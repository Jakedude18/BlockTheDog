using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimate : MonoBehaviour {

       //public float speed = 3f; // player movement speed
       //private Vector3 change; // player movement direction
       //private Rigidbody2D rb2d;
       private Animator anim;
       //private Renderer rend;

       void Start () {
              anim = GetComponentInChildren<Animator>();
              /*
              rend = GetComponentInChildren<Renderer> ();
              if (gameObject.GetComponent<Rigidbody2D>() != null) {
                     rb2d = GetComponent<Rigidbody2D>();
              }
              */
       }
    /*
       void Update() {
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            UpdateAnimationAndMove();

            if (Input.GetAxis ("Horizontal") > 0){
                Vector3 newScale = transform.localScale;
                newScale.x = 1.0f;
                transform.localScale = newScale;
            }
            else if (Input.GetAxis ("Horizontal") < 0){
                    Vector3 newScale =transform.localScale;
                    newScale.x = -1.0f;
                    transform.localScale = newScale;
            }

       }
    */

       void UpdateAnimationAndMove(bool moving) {
            if (moving) {
                //rb2d.MovePosition(transform.position + change * speed * Time.deltaTime);
                anim.SetBool("Walk", true);
                //if (!audioWalk.isPlaying){ audioWalk.Play(); }
            } else {
                anim.SetBool("Walk", false);
                //audioWalk.Stop();
            }
       }
        /*
        IEnumerator ChangeColor(){
                // color values are R, G, B, and alpha, each 0-255 divided by 100
                rend.material.color = new Color(2.0f, 1.0f, 0.0f, 0.5f);
                yield return new WaitForSeconds(0.5f);
                rend.material.color = Color.white;
        }
        */
}
