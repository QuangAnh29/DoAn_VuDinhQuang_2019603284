using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySFX("Hurt");
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
