using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeatController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed = 2f;
    public float accelerateSpeed = 10f;

    private bool movingToEnd = true;

    private void Update()
    {
        if (movingToEnd)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPoint.position, accelerateSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, endPoint.position) < 0.01f)
        {
            movingToEnd = false;
        }
        else if (Vector2.Distance(transform.position, startPoint.position) < 0.01f)
        {
            movingToEnd = true;
        }
    }
}
