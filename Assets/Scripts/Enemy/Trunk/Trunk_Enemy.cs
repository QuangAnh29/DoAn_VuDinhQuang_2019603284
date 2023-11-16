using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk_Enemy : MonoBehaviour
{
    private Transform player; // Tham chiếu đến nhân vật
    public float detectionRange_Hight = 5f; // Khoảng cách theo dõi theo chiều cao
    public float detectionRange_Width = 10f; // Khoảng cách theo dõi theo chiều rộng
    public float attackRange = 5f; // Khoảng cách để tấn công
    public float moveSpeed = 1f; // Tốc độ di chuyển
    public GameObject bulletPrefab; // Prefab của viên đạn
    public Transform bulletSpawnPoint;
    private Animator animator;

    private float waitedTime;
    public float waitTimeToAcctack = 2;

    private bool isPlayerInRange = false;

    private SpriteRenderer spriteRend;


    private void Start()
    {
        waitedTime = 0;
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Direction();
        float distanceToPlayer = Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(player.position.x, 0));

        if (distanceToPlayer <= detectionRange_Width && Mathf.Abs(player.position.y - transform.position.y) <= detectionRange_Hight)
        {
            // Người chơi nằm trong khoảng theo dõi theo chiều rộng và chiều cao
            isPlayerInRange = true;

            if (distanceToPlayer > attackRange)
            {
                // Người chơi nằm trong khoảng tấn công
                Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                animator.SetBool("isRunning", true);
                animator.SetBool("isAttacking", false);
            }
            else
            {
                // Người chơi nằm trong khoảng tấn công
                if (waitedTime <= 0)
                {
                    // Thực hiện tấn công
                    Invoke("TrunkBullet", 1f);
                    animator.SetBool("isAttacking", true);
                    animator.SetBool("isRunning", false);
                    waitedTime = waitTimeToAcctack;

                    float xOffset = spriteRend.flipX ? 1f : -1f;
                    bulletSpawnPoint.localPosition = new Vector3(xOffset, 0f, 0f);
                }
                else
                {
                    // Đang chờ, không thực hiện tấn công
                    waitedTime -= Time.deltaTime;
                    animator.SetBool("isAttacking", false);
                    animator.SetBool("isRunning", false);
                }
            }
        }
        else
        {
            // Người chơi không trong khoảng theo dõi
            if (isPlayerInRange)
            {
                isPlayerInRange = false;
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttacking", false);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        DrawWireRectangle(transform.position, detectionRange_Width, detectionRange_Hight);

        // Vẽ khoảng cách tấn công
        Gizmos.color = Color.red;
        DrawWireRectangle(transform.position, attackRange * 2, attackRange * 2);
    }

    void DrawWireRectangle(Vector3 center, float width, float height)
    {
        Vector3 halfSize = new Vector3(width * 0.5f, 0.1f, height * 9f);
        Matrix4x4 cubeTransform = Matrix4x4.TRS(center, transform.rotation, halfSize);
        Gizmos.matrix = cubeTransform;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        Gizmos.matrix = Matrix4x4.identity;
    }
    void Direction()
    {
        if (player)
        {
            Vector3 Direction = player.position - transform.position;

            if(Direction.x < 0)
            {
                spriteRend.flipX = false;
            }
            else if(Direction.x > 0)
            {
                spriteRend.flipX = true;
            }
        }
    }
    public void TrunkBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Trunk_Bullet bulletScript = newBullet.GetComponent<Trunk_Bullet>();
        if (spriteRend.flipX)
        {
            bulletScript.SetDirection(true);
        }
        else
        {
            bulletScript.SetDirection(false);
        }
    }
}
