using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
{
//preguntar si quedan frutas aún     
    private void Update()
    {
        AllFruitsCollected();
    }  
//averiguar si dentro del empty tenemos las frutas o no    
    public void AllFruitsCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("Has Recogido las Frutas");
            //carga una escena nueva que tengamos en Build Settings dentro de Unity
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }


}
