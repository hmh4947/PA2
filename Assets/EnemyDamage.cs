using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    public Slider healthBarSlider;
    
    
    void Start()
    {
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= .008f;
        }
        if (other.gameObject.tag == "Enemy" && healthBarSlider.value <= 0)
        {
            SceneManager.LoadScene("GameOver");
            
        }

    }
}
