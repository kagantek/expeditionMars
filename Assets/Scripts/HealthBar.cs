using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<RectTransform>();
        SetSize(Health.totalHealth);
    }

    public void Damage(float damage)
    {
        if ((Health.totalHealth -= damage) >= 0f)
        {
            Health.totalHealth -= damage;
        }
        else
        {
            Health.totalHealth = 0;
            Health.totalHealth = 1;
            Scoring.totalScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        SetSize(Health.totalHealth);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
