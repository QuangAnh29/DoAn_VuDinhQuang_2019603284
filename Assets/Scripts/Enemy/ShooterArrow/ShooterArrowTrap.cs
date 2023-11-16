using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterArrowTrap : MonoBehaviour
{
    private float waitedTime;
    public float waitTimeToAttack = 3;
    private Animator animator;
    public GameObject Arrow;
    public Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = waitTimeToAttack;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAttack;
            animator.SetBool("isAttacking", true);
            ArrowTrap();
        }
        else
        {
            waitedTime -= Time.deltaTime;

            animator.SetBool("isAttacking", false);
        }
    }

    public void ArrowTrap()
    {
        GameObject newArrow;
        newArrow = Instantiate(Arrow, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
