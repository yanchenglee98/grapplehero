using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainToggle : MonoBehaviour
{

    public GameObject rain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("hree");
            rain.SetActive(!rain.activeSelf);
            Debug.Log(rain.activeSelf);

        }
/*    if (collision.tag == "Player")
        {
            if (rain.activeSelf)
            {
                rain.SetActive(false);

            } else
            {
                rain.SetActive(true);
            }
            Debug.Log(rain.activeSelf);

        }*/
    }
}
