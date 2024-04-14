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
            uiManager.GameOver();
            gameObject.SetActive(false);
            return;
        }
        transform.position = currentCheckpoint.position;
        playerHeath.Respawn();
        RestartLevel();
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
