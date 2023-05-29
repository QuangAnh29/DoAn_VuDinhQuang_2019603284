using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRend;
    public GameObject brockenParts;

    public float jumpforce = 4f;
    public int lifes = 2;

    public GameObject boxCollider;
    public Collider2D col2D;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SoundManager.instance.PlaySFX("JumpDamage");
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpforce;
            LosseLifeAndHit();
        }
    }

    public void LosseLifeAndHit()
    {
        lifes--;
        animator.Play("Hit");
        CheckLife();
    }

    public void CheckLife()
    {
        if(lifes <= 0)
        {
            boxCollider.SetActive(false);
            col2D.enabled = false;
            brockenParts.SetActive(true);
            spriteRend.enabled = false;
            Invoke("DestroyBox", 0.5f);
        }
    }

    public void DestroyBox()
    {
        Destroy(gameObject);
    }
}
