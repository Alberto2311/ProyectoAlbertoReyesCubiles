using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    public float runSpeed=2;

    public float jumpSpeed = 3;

    Rigidbody2D rb2D;

    public SpriteRenderer SpriteRenderer;

    public Animator animator;
 
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // movimientos del personaje
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y); 
            //girar al personaje o no tras pulsar la tecla
            SpriteRenderer.flipX=false;
            //para que la animación de movimiento run nos detecte cuando pulsamos la tecla
            //y así se activa dicha animación
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            SpriteRenderer.flipX=true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }
        //detectar el collider de los pies si está hundido o no
        if (Input.GetKey("space") && ColliderPies.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        //detectar si está en el suelo para cuando salte, que haga la animación de salto
        if (ColliderPies.isGrounded==false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (ColliderPies.isGrounded==true)
        {
            animator.SetBool("Jump", false);
        }
          if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Escape key was released");
            SceneManager.LoadScene(0);
        }
    }
}
