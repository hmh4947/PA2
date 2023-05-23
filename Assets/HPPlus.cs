using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HPPlus : MonoBehaviour
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
        if (other.gameObject.tag == "HP" && 1>healthBarSlider.value &&
            healthBarSlider.value > 0)
        {
            healthBarSlider.value += .08f;
            Destroy(other.gameObject);
        }
       else
        {
          //  SceneManager.LoadScene("GameOver");
            // isGameOver = true;
            //  gameOverText.enabled = true;
        }

    }
}
