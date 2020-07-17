using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject NPC;
    public GameObject Player;
    public GameObject text;
    public float radius = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(NPC.transform.position, Player.transform.position) <= radius)
        {
            text.SetActive(true);
        } else
        {
            text.SetActive(false);
        }
    }
}
