using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 2;
    public float lifeTime = 2;
    public GameObject explosionPrefab; // Trường để lưu Prefab hiệu ứng nổ

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // Di chuyển mũi tên từ trên xuống
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Khi va chạm, khởi tạo Prefab hiệu ứng nổ và hủy mũi tên
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    
}
