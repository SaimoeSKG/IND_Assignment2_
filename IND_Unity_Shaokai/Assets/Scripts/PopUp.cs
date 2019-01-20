using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{

    public GameObject LosePopup;
    public GameObject WinPopup;
    public GameObject BinPopup;
    public Text FinalScore;
    private float endscore;
    public Image healthBar;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bin")
        {
            BinPopup.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }

    }

    void Update()
    {
        healthBar.fillAmount -= 0.02f * Time.deltaTime;

        FinalScore.text = endscore.ToString("F0");


        if (healthBar.fillAmount == 0)
        {
            WinPopup.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
}