using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//elegir el nivel
using UnityEngine.SceneManagement;

public class Puertas : MonoBehaviour
{
 //referenciar al texto pulsar e para entrar
    public Text text;
    public string levelName;
 //saber si estás en la puerta
    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            inDoor = true;
        }
   }
    private void OnTriggerExit2D(Collider2D collision)
    {
            text.gameObject.SetActive(false);
            inDoor = false;  
    }

//comprobar a que nivel quieres ir
    private void Update()
    {
        if (inDoor && Input.GetKey("e"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
