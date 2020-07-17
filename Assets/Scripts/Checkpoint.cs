using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //private GameMaster gm;
    private PlayerHealth ph;
    public float offset = 1;
    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        ph = GameObject.FindObjectOfType<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!activated)
            {
                activated = true;
                AudioManager.instance.Play("Checkpoint");
                Debug.Log("respawn pt set");
                ph.respawnPt.position = transform.position + new Vector3(0, offset, 0);
            }
        }
    }
}
