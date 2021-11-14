using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañospike : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //comprobar si ha colisionado con el jugador
        if (collision.transform.CompareTag("Player"))
        {
            //Cuando colisione el jugador, lo elimina
            Debug.Log("Player Damaged");
           collision.transform.GetComponent<playerspawn>().PlayerDamaged();
        }
    }
}
