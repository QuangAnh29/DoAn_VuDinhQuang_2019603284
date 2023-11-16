using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBird : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float fallSpeed = 3f;
    public float idleSpeed = 1f;

    private Animator animator;
    private bool isMovingToB = true;

    public LayerMask groundLayer;  
    public Transform groundCheck;
    public float groundCheckDistance = 0.1f;
    private bool isGrounded;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MoveBetweenPoints());
    }

    private void Update()
    {
        isGrounded = CheckGround();

        animator.SetBool("isGrounded", isGrounded);
    }
    IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            if (isMovingToB)
            {
                // Di chuyển từ A xuống B với animation fall
                animator.SetBool("isFalling", true);
                while (transform.position.y > pointB.position.y)
                {
                    transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
                    yield return null;
                }
                isMovingToB = false;
            }
            else
            {
                // Di chuyển từ B lên A với animation idle
                animator.SetBool("isFalling", false);
                while (transform.position.y < pointA.position.y)
                {
                    transform.Translate(Vector2.up * idleSpeed * Time.deltaTime);
                    yield return null;
                }
                isMovingToB = true;
            }

            // Ngắn nghỉ giữa hai chuyển động
            yield return new WaitForSeconds(1f);
        }
    }

    bool CheckGround()
    {
        // Tạo một raycast từ dưới đối tượng
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        // Nếu raycast chạm vào layer của "đất", đối tượng được coi là đang chạm đất
        return hit.collider != null;
    }

}
