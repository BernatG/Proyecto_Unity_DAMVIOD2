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

    // Start is called before the first frame update
    void Start()
    {
        food = 0;
        needFood = 8;
        int bucle = 0;

        TextMeat.text = food + " / " + needFood;


        while (needFood > bucle)
        {
            Vector3 position = new Vector3(Random.Range(20.0f, 420.0f), 10, Random.Range(20.0f, 420.0f));
            Instantiate(meat, position, Quaternion.identity);
            bucle += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "meat")
        {
            food += 1;
            TextMeat.text = food + " / " + needFood;
            Destroy(other.gameObject);
        }
    }
}
