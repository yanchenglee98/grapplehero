using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPF : MonoBehaviour
{
    public Seeker seeker;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponentInParent<Seeker>();
        seeker.enabled = false; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("enabled");
            seeker.enabled = true;
        }
    }
}
