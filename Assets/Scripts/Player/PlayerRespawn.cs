using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip finishAudio;
    private Transform currentCheckpoint;
    private Health playerHeath;
    private bool levelCompleted = false;
    private UIManager uiManager;


    private void Awake()
    {
        playerHeath = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();

    }
    private void Respawn()
    {
        if (currentCheckpoint == null)
        {
            //Debug.Log("player die");
            uiManager.GameOver();
            gameObject.SetActive(false);
            return;
        }
        transform.position = currentCheckpoint.position;
        playerHeath.Respawn();
        RestartLevel();
    }
    /*private void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHeath.Respawn();
        RestartLevel();
    }*/
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*if (col.transform.tag == "Checkpoint" && !levelCompleted)
        {
            currentCheckpoint = col.transform;
            SoundManager.instance.PlaySound(finishAudio);
            levelCompleted = true;
            Invoke("CompleteLevel", 1.5f);
        }*/
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
