using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    //para cambiar la animación
   public Animator animator;
//para cambiar si mira a la izquierda o derecha
   public SpriteRenderer spriteRenderer;

   //velocidad enemigo
   public float speed = 0.5f;

//cuando el enemigo llega a tal punto, el tiempo que espera para volver a moverse
   private float waitTime;

//decir el inicio y donde debe llegar el enemigo
   public Transform[] moveSpots;
   public float startWaitTime = 2;
//gestionar donde debe ir
   private int i = 0;
   private Vector2 actualPos;

    void Start()
    {
        waitTime=startWaitTime;
    }

   //movimiento del personaje 
    void Update()
    {
        //rutina para el movimiento
        StartCoroutine(CheckEnemyMoving());

        transform.position=Vector2.MoveTowards(transform.position, moveSpots[i].transform.position,speed*Time.deltaTime);
        
        //preguntar para ver en que punto se encuentra
        if (Vector2.Distance(transform.position,moveSpots[i].transform.position)<0.1f)
        {
            //hemos pasado el tiempo de espera
            if (waitTime<=0)
            {
                //preguntar si hay más puntos a los que ir y aumentamos el waypoint
                if (moveSpots[i]!=moveSpots[moveSpots.Length-1])
                {
                    i++;
                }
                //si ya no hay más, se vuelve al array 0 (waypoint 1)
                else{
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else{
                waitTime -= Time.deltaTime;
            }
        }
    }
    //para cambiar si mira a la izquierda o derecha parte 2 
    //comparando si está yendo a izquierda o derecha y lo invierte
    IEnumerator CheckEnemyMoving()
    {
        actualPos=transform.position;
        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);
        
        }
        else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX=false;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x==actualPos.x)
        {
            animator.SetBool("Idle", true);
        }
    }
}
