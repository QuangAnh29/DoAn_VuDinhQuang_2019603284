using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_Attack : MonoBehaviour
{
    public Animator animator;
    public float distanceRayCast = 5f;
    private float cooldownAttack = 0.5f;
    private float actualCooldownAttack;
    public GameObject beeBullett;

    private void Start()
    {
        actualCooldownAttack = 0;
    }

    private void Update()
    {
        actualCooldownAttack -= Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, distanceRayCast);

        if(ray.collider != null)
        {
            if (ray.collider.CompareTag("Player"))
            {
                if(actualCooldownAttack < 0)
                {
                    Invoke("LaunchBullet", 0.5f);
                    animator.Play("Bee_Attack");
                    actualCooldownAttack = cooldownAttack;
                }
            }
        }
    }

    void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(beeBullett, transform.position, transform.rotation);
    }

}
