using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
            Debug.Log("Destroy arrow");
        }

        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    
}
