using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk_Bullet : MonoBehaviour
{
    public float speed = 2;
    public float lifeTime = 5;


    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(bool isLeft)
    {
        if (isLeft)
        {
            speed = Mathf.Abs(speed);
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else
        {
            speed = -Mathf.Abs(speed);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Update()
    {
        // Di chuyển đạn theo hướng đã được đặt
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

}
