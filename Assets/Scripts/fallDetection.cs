using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallDetection : MonoBehaviour
{
    public HealthBar healthBar2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = Move.getStartPosition();
            healthBar2.Damage(0.125f);
        }
    }

}
