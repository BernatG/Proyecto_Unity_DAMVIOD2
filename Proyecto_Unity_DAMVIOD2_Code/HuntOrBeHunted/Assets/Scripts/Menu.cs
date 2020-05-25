using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasMenuJugar;
    public GameObject canvasMenuCredit;
    public GameObject canvasMenuExit;
    public GameObject canvasWolf;
    public GameObject canvasDialgue;
    public GameObject canvasCredits;
    public GameObject cinemachine;
    public GameObject wolf;

    private AudioSource ambient;

    // Start is called before the first frame update
    void Start()
    {
        canvasMenu.SetActive(true);
        canvasMenuJugar.SetActive(true);
        canvasMenuCredit.SetActive(true);
        canvasMenuExit.SetActive(true);
        canvasWolf.SetActive(false);
        canvasDialgue.SetActive(false);
        canvasCredits.SetActive(false);
        cinemachine.SetActive(false);
        wolf.SetActive(false);
        Time.timeScale = 1;
        ambient = GetComponent<AudioSource>();
        ambient.Stop();
        Cursor.visible = true;
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
        ambient.Play();
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OnClickCredits()
    {
        canvasMenuJugar.SetActive(false);
        canvasMenuCredit.SetActive(false);
        canvasMenuExit.SetActive(false);
        canvasCredits.SetActive(true);
    }

    public void OnClickExitCredits()
    {
        canvasMenuJugar.SetActive(true);
        canvasMenuCredit.SetActive(true);
        canvasMenuExit.SetActive(true);
        canvasCredits.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
