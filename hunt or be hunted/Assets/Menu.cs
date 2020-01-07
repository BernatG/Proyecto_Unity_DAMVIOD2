using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasWolf;
    public GameObject canvasDialgue;
    public GameObject cinemachine;
    public GameObject wolf;


    // Start is called before the first frame update
    void Start()
    {
        canvasMenu.SetActive(true);
        canvasWolf.SetActive(false);
        canvasDialgue.SetActive(false);
        cinemachine.SetActive(false);
        wolf.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        canvasMenu.SetActive(false);
        canvasWolf.SetActive(true);
        canvasDialgue.SetActive(true);
        cinemachine.SetActive(true);
        wolf.SetActive(true);
    }

}
