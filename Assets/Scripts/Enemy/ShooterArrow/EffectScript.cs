using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    public float lifeTime = 0.5f;

    void Start()
    {
        // Gọi hàm tự động hủy sau thời gian lifeTime
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        // Đợi delay giây
        yield return new WaitForSeconds(lifeTime);

        // Hủy đối tượng hiệu ứng nổ
        Destroy(gameObject);
    }
}
