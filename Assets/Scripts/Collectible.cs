using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score++;
            gameObject.SetActive(false);
        }
    }
}
