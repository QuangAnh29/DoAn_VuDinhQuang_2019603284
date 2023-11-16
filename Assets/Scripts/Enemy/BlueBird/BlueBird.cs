using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : MonoBehaviour
{
    public Transform[] movePoints;
    public float moveSpeed = 2f;

    private int currentPoint = 0;
    private bool isMovingRight = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSpriteDirection();
    }

    void Update()
    {
        MoveEnemy();
        CheckPointReached();
    }

    void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[currentPoint].position, moveSpeed * Time.deltaTime);
    }

    void CheckPointReached()
    {
        if (Vector2.Distance(transform.position, movePoints[currentPoint].position) < 0.1f)
        {
            // Change direction when reaching the end points
            if (currentPoint == 0 || currentPoint == movePoints.Length - 1)
            {
                isMovingRight = !isMovingRight;
                UpdateSpriteDirection();
            }

            // Move to the next point
            if (isMovingRight)
                currentPoint = (currentPoint + 1) % movePoints.Length;
            else
                currentPoint = (currentPoint - 1 + movePoints.Length) % movePoints.Length;
        }
    }

    void UpdateSpriteDirection()
    {
        spriteRenderer.flipX = !isMovingRight;
    }
}
