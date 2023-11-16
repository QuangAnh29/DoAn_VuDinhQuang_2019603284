using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_Bullet : MonoBehaviour
{
    public float speed = 2;
    public float liftTime = 2;

    private void Start()
    {
        Destroy(gameObject, liftTime);
        
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
