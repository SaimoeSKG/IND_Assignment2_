using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collectable_New : MonoBehaviour {

    public float Diamond;
    public float Star;
    public float Heart;
    public float Score;
    private bool hasKey;

    public Text DiamondCount;
    public Text StarCount;
    public Text HeartCount;
    public Text keysCount;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            Diamond++;
            DiamondCount.text = "" + Diamond;
            Instantiate(Resources.Load("Pick"), other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.tag == "Heart")
        {
            Heart++;
            HeartCount.text = "" + Heart;
            Instantiate(Resources.Load("Pick"), other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.tag == "Star")
        {
            Star++;
            StarCount.text = "" + Star;
            Instantiate(Resources.Load("Pick"), other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }


    }
    void Update()
    {
        Diamond.ToString("F0");
        Star.ToString("F0");
        Heart.ToString("F0");
    }
}
