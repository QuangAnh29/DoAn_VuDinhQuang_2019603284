using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    //[SerializeField] private GameObject finishScreen;

    public Text ScoreText;
    [SerializeField] private AudioClip finishAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*Finish.UnlockNewLevel();*/
            Finish.finish.FinishMenu(ScoreText.text);
            //SoundManager.instance.PlaySound(finishAudio);
        }
        
    }



}
