using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class eat : MonoBehaviour
{
    public TextMeshProUGUI TextMeat;
    private int food;
    private int needFood;
    public GameObject meat;

    public GameObject textHome;
    public GameObject ImageWine;
    public GameObject buttonRestartGame;

    private AudioSource sound;
    public AudioClip comer;

    // Start is called before the first frame update
    void Start()
    {
        food = 0;
        needFood = 8;
        int bucle = 0;

        TextMeat.text = food + " / " + needFood;

        sound = GetComponent<AudioSource>();

        while (needFood > bucle)
        {
            Vector3 position = new Vector3(Random.Range(70.0f, 380.0f), 10, Random.Range(150.0f, 400.0f));
            Instantiate(meat, position, Quaternion.identity);
            bucle += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(food == needFood)
        {
            textHome.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "meat")
        {
            food += 1;
            TextMeat.text = food + " / " + needFood;
            sound.clip = comer;
            sound.Play();
            Destroy(other.gameObject);            
        }

        if(food == needFood)
        {
            if (other.gameObject.tag == "home")
            {
                ImageWine.SetActive(true);
                buttonRestartGame.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
            }
        }
    }
}
