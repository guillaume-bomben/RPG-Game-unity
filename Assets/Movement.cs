using UnityEngine;

public class Movement : MonoBehaviour{

    public float speed = 1.0f;
    private Rigidbody2D rb;
    private Vector2 input;

    Animator anim;
    private Vector2 LastMoveDircetion;
    private
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        ProccessImput();
        Animate();
    }

    private void FixedUpdate(){
        rb.linearVelocity = input * speed;
    }

    void ProccessImput(){
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0)){
            LastMoveDircetion = input;
        }   

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        input.Normalize();
    }


    void Animate(){
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetFloat("MoveMagnitude", input.magnitude);
        anim.SetFloat("LastMoveX", LastMoveDircetion.x);
        anim.SetFloat("LastMoveY", LastMoveDircetion.y);
    }

}
