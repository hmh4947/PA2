using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Slider healthBarSlider;
    public Text gameOverText;
    private bool isGameOver = false;
    void Start()
    {
        gameOverText.enabled = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= .008f;
        }
        else
        {
            isGameOver = true;
            gameOverText.enabled = true;
        }

    }
}
