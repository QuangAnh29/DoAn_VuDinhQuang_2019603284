using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DameNotTrigger : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health playerHealth = collision.collider.GetComponent<Health>();


        if (collision.collider.tag == "Player" && playerHealth != null && !playerHealth.IsInvulnerable())
        {
            playerHealth.TakeDamage(damage);

            SoundManager.instance.PlaySFX("Hurt");

        }
    }
}
