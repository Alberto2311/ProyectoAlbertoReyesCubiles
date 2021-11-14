using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//recarga la misma escena
using UnityEngine.SceneManagement;

public class playerspawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;
//referencia a animación hit
    public Animator animator;
    
    //si tuvieramos un checkpoint aparecemos en él
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionX")));
        }
    }


    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

//cuando reciba daño
    public void PlayerDamaged()
    {
        animator.Play("hit");
        //recarga la misma escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
