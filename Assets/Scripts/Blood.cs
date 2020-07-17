using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite[] blood;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, blood.Length);
        rend.sprite = blood[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
