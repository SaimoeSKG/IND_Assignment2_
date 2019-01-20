using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;






public class MenuController : MonoBehaviour {
	public AudioSource musicSource;

    public InputField nameenter;

    public Text FName;
    public float bounes;
    private float roll;
    public Text screenscore;
    void Start()
    {
        bounes = 0;
        roll = 0;
    }
    public void setget()
    {
        FName.text = "" + nameenter.text;

    }
    public void piked()
    {
        float roll = (Random.Range(0, 2) == 0) ? 50 : -50;
        bounes.ToString("F0");
        bounes = (bounes + roll);
        screenscore.text = "Your final score is " + bounes;

    }
    public void PlayGame() 
	{
        CallInputName.playername = FName.text;
        Time.timeScale = 1;
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void LaunchGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void OnClick()
    {
        Time.timeScale = 1;
    }
    public void QuitGame() 
	{
		Application.Quit ();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.QuitGame();
		#endif
	}
	public void PlayMusic() {
		if (musicSource.isPlaying)
			musicSource.Pause ();
		else
			musicSource.Play ();
	}

	// Use this for initialization
	
    private void Update()
    {
        
    }

    // Update is called once per frame

}
