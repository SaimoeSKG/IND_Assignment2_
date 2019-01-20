using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallInputName : MonoBehaviour {
    public static string playername;

    public Text NameDis;
    public Text Finalname;
    // Use this for initialization

    void Start () {
        NameDis.text = playername;
        Finalname.text = "Hi, " + playername;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
