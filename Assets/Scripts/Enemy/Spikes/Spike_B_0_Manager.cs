using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_B_0_Manager : MonoBehaviour
{
    public float attackDelay = 3f; // Thời gian giữa các lần tấn công
    public float attackDuration = 1f; // Thời gian mà trap tấn công

    private Animator animator;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackDelay); // Đợi 3 giây trước khi tấn công

            // Bắt đầu hoạt động tấn công
            isAttacking = true;
            animator.SetBool("isAttacking", true);

            // Đợi trong thời gian tấn công
            yield return new WaitForSeconds(attackDuration);

            // Kết thúc hoạt động tấn công
            isAttacking = false;
            animator.SetBool("isAttacking", false);
        }
    }
}
