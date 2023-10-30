using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false;
    private float fallSpeed = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallAfterDelay(1.0f));
        }


        if (isFalling)
        {
            // Kiểm tra va chạm với bẫy spike (Tag "Trap") và biến mất
            if (collision.gameObject.CompareTag("Trap"))
            {
                Destroy(gameObject);
            }
            // Kiểm tra va chạm với Tilemap có Layer "Ground" và biến mất
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator FallAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false;
        isFalling = true;
    }

    private void Update()
    {
        if (isFalling)
        {
            // Tăng tốc độ rơi dần theo thời gian (ví dụ: mỗi giây tăng 2 đơn vị)
            fallSpeed += Time.deltaTime * 5.0f;
            Vector2 fallVelocity = new Vector2(0, -fallSpeed);
            rb.velocity = fallVelocity;
        }
    }
}
