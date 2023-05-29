using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;
    public float waitTimeToAcctack = 3;
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = waitTimeToAcctack;
    }

    private void Update()
    {
        if(waitedTime <= 0)
        {
            waitedTime = waitTimeToAcctack;
            animator.Play("Attack");
            Invoke("LauchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime; 
        }
    }

    public void LauchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
