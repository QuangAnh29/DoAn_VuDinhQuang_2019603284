using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : MonoBehaviour
{
    public float speed = 5.0f; // Tốc độ bay của enemy
    public float detectionRange = 10.0f; // Phạm vi phát hiện người chơi
    private Transform player; // Người chơi
    private Vector3 initialPosition; // Vị trí ban đầu
    private bool isReturning = false; // Biến kiểm tra khi Enemy đang bay về vị trí ban đầu

    private Animator animator;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Tìm và lưu trữ người chơi
        initialPosition = transform.position; // Lưu trữ vị trí ban đầu
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.position.x, player.position.y));

        if (distanceToPlayer < detectionRange && !isReturning)
        {
            // Enemy bay tới người chơi
            Vector2 direction = (new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
            transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
            animator.SetTrigger("Flying"); // Kích hoạt animation bay

            // Điều chỉnh hướng nhìn của enemy để hướng về người chơi
            if (player.position.x > transform.position.x)
            {
                // Enemy quay về phía người chơi
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                // Enemy quay về phía nguyên vị trí ban đầu
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            // Enemy bay về vị trí ban đầu
            Vector2 direction = (new Vector2(initialPosition.x, initialPosition.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
            transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(initialPosition.x, initialPosition.y)) < 0.1f)
            {
                isReturning = false;
                animator.SetTrigger("Idle"); // Kích hoạt animation idle
            }
            else
            {
                isReturning = true;
            }

            // Điều chỉnh hướng nhìn của enemy để hướng ngược lại vị trí ban đầu
            if (initialPosition.x > transform.position.x)
            {
                // Enemy quay về phía nguyên vị trí ban đầu
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                // Enemy quay về phía người chơi
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Đặt màu Gizmos là đỏ
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
