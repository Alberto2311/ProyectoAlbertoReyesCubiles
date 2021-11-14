using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPies : MonoBehaviour
{
    //añadir static es para poder usar isGrounded en otro script
    public static bool isGrounded;

    //para detectar cuando esté en el suelo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    //para detectar cuando no esté en el suelo
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
