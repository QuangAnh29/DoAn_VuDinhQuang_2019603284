using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static Health healthPlayer;
    //private Health healthPlayer;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    public CinemachineVirtualCamera Vcam;
    public GameObject[] playerPrefabs;    
    int playerIndex;
    private void Awake()
    {
        playerIndex = PlayerPrefs.GetInt("selectedCharacter", 0);
        GameObject player =  Instantiate(playerPrefabs[playerIndex], new Vector2(-3,0), Quaternion.identity);
        Vcam.Follow = player.transform;

        healthPlayer = player.GetComponent<Health>();
    }
    
}
