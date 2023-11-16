using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health playerHealth = collision.GetComponent<Health>();

        
        if (collision.tag == "Player" && playerHealth != null && !playerHealth.IsInvulnerable())
        {
            playerHealth.TakeDamage(damage);

            SoundManager.instance.PlaySFX("Hurt");

        }
    }
}
