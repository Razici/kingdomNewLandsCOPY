using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb2d;
    public int direction;

    private Animator anim;

	// Use this for initialization
	void Start () {
        direction = 1;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal != 0)
        {

            if (moveHorizontal < 0 && direction== 1)
            {
                direction = -1;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }else
                if (moveHorizontal > 0 && direction == -1)
            {
                direction = 1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            Vector2 movement = new Vector2(moveHorizontal, 0);
            transform.Translate(movement * speed * direction);

            if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) )
            {
                anim.SetTrigger("gallop");
            }
            if (!Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetTrigger("idle");
            }

            
        }
        
    }
}
