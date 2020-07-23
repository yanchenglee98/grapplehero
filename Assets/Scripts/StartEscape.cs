using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEscape : MonoBehaviour
{
    public PlayerRunning player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("startRun");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator startRun()

    {
        yield return new WaitForSeconds(3f);
        player.moveAxis = 1;
    }
}
