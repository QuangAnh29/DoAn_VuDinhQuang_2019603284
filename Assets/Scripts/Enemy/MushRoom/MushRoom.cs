using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer spriteRend;

    public float speed = 0.5f;

    private float waitTime;
    public float startWaitTime = 2;


    public Transform[] moveSpots;

    private int i = 0;

    private Vector2 actualPos;

    private void Start()
    {
        waitTime = startWaitTime;
    }

    private void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if(waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }


    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.05f);
        if(transform.position.x > actualPos.x)
        {
            spriteRend.flipX = true;
            anim.SetBool("idle", false);
        }
        else if(transform.position.x < actualPos.x)
        {
            spriteRend.flipX = false;
            anim.SetBool("idle", false);
        }
        else if(transform.position.x == actualPos.x)
        {
            anim.SetBool("idle", true);
        }
    }
}
