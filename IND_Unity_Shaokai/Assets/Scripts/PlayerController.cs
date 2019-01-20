using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Camera camera;
    public NavMeshAgent agent;
    public Text stepcount;
    public GameObject WinPopup;
    public GameObject BinPopup;
    public Text FinalScore;
    public Text highestscore;

    public float callrand;
    public float callmap;
    public float callcoll;
    public float finalscoreshell;
    public float higscore;

    RaycastHit hit;
    private Text endscore;
    public Image healthBar;
    Animator myAnim;
    float dist;
    Quaternion newRotation;
    float rotSpeed = 4f;
    private float lastUpdate;

    MenuController cc;
    DestroyOnEnter cd;
    Collectable_New ce;

    public float steps;
    // Use this for initialization
    void Start()
    {
        myAnim = GetComponent<Animator>();
        steps = 0;
        higscore = 999;
        GameObject cccc = GameObject.Find("Replay_List");
        cc = cccc.GetComponent<MenuController>();
        GameObject cccd = GameObject.Find("Character");
        cd = cccd.GetComponent<DestroyOnEnter>();
        GameObject ccce = GameObject.Find("Character");
        ce = ccce.GetComponent<Collectable_New>();


    }


    // Update is called once per frame
    void Update()
    {
        stepcount.text = steps.ToString("F0");

        healthBar.fillAmount -= 0.01f * Time.deltaTime;

        finalscoreshell.ToString("F0");


        if (healthBar.fillAmount == 0)
        {
            WinPopup.SetActive(true);
            callrand = cc.bounes;
            callmap = cd.xcore;
            callcoll = ce.Diamond + ce.Star + ce.Heart;
            finalscoreshell = callrand + callmap * 100 + callcoll * 10 - steps;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        if (finalscoreshell <= 0)
        {
            finalscoreshell = 0;
            FinalScore.text = "You've scored: " + finalscoreshell;
            highestscore.text = "Highest score: " + higscore + " by Moe";
        }
        else if (finalscoreshell >= 0)
        {
            FinalScore.text = "You've scored: " + finalscoreshell;
            highestscore.text = "Highest score: " + higscore + " by Moe";
        }
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Mouse click");
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        }//Stop Nav and UI from interacting.

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                myAnim.SetBool("isRunning", true);
            } 
            {
                Vector3 relativePos = hit.point - transform.position;
                newRotation = Quaternion.LookRotation(relativePos, Vector3.up);
                newRotation.x = 0.0f;
                newRotation.z = 0.0f;

            }
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotSpeed * Time.deltaTime);
        dist = Vector3.Distance(hit.point, transform.position);
        Debug.Log("Distance:" + dist);
        if (dist < 1f)
        {
            myAnim.SetBool("isRunning", false);
        }
        //do something
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            if (Time.time - lastUpdate >= 1f)
            {
                steps = (steps + 2f);
                lastUpdate = Time.time;
                stepcount.text = "" + steps;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bin")
        {
            BinPopup.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
}
