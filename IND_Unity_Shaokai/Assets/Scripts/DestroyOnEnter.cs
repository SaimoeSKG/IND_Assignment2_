using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyOnEnter : MonoBehaviour {

    private AudioSource source;
    public GameObject Beach;
    public GameObject Field;
    public GameObject Maze;
    public float xcore;
    [SerializeField] private AudioClip placesSound;
    // Use this for initialization
    void Start () {
		gameObject.GetComponent<Renderer>().enabled = false;

        xcore = 0;
	}
	
	// Update is called once per frame



    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Beach")
        {
            xcore++;
            Debug.Log("You've entered " + gameObject.name + " place.");
            Beach.SetActive(true);
            source = col.GetComponent<AudioSource>();
            source.PlayOneShot(placesSound, 1f);
            Destroy(gameObject);
 
        }

        if (col.tag == "Field")
        {
            xcore++;
            Debug.Log("You've entered " + gameObject.name + " place.");
            Field.SetActive(true);
            source = col.GetComponent<AudioSource>();
            source.PlayOneShot(placesSound, 1f);
            Destroy(gameObject);

        }

        if (col.tag == "Maze")
        {
            xcore++;
            Debug.Log("You've entered " + gameObject.name + " place.");
            Maze.SetActive(true);
            source = col.GetComponent<AudioSource>();
            source.PlayOneShot(placesSound, 1f);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        xcore.ToString("F0");
    }
}
