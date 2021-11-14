using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //este apartado es para que detecte al jugador
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //lamar al Fruit manager antes de "destruir" las frutas
            Destroy(gameObject, 0.5f);
        }
    }
}
