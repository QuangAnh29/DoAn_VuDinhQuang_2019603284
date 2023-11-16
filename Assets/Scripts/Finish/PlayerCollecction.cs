using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerCollecction : MonoBehaviour
{
    public Text ScoreText;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            EndGame.endGame.EndGamehMenu(ScoreText.text);
            
        }

    }
}
