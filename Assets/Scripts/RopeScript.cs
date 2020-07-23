using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RopeScript : MonoBehaviour { // can think of this script as the "bullet"

	public Vector2 destiny;

	public float speed = 1;

	public float distance = 2;

	public GameObject nodePrefab;

	public GameObject player;

	public GameObject playerwep;

	public GameObject lastNode;

    public List<GameObject> Nodes = new List<GameObject>();

    public LineRenderer lr;

    int vertexCount = 2;

	bool done = false;

	public GameObject sparksEffect;

	public GameObject hitEnemySparksEffect;

	public int damage = 1;

	public float hookPushForce = 1000f;
	public float hookPullForce = 1500f;

	// Use this for initialization
	void Start() {

        lr = GetComponent<LineRenderer>();

		player = GameObject.FindGameObjectWithTag("Player");

		lastNode = transform.gameObject;

        Nodes.Add(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update() {
	
		transform.position = Vector2.MoveTowards(transform.position, destiny, speed);

		if ((Vector2) transform.position != destiny) {

			if (Vector2.Distance(player.transform.position, lastNode.transform.position) > distance) {
				CreateNode();
			}
		} else if (!done) {
			done = true;

            while (Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }

			lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
		}

        RenderLine();
	}

    void RenderLine()
    {
        lr.positionCount = vertexCount;

        int i;
        for (i = 0; i < Nodes.Count; i++)
        {
            lr.SetPosition(i, Nodes[i].transform.position);

        }

        lr.SetPosition(i, player.transform.position);
    }

	void CreateNode()
	{
		Vector2 pos2Create = player.transform.position - lastNode.transform.position;
		pos2Create.Normalize ();
		pos2Create *= distance;
		pos2Create += (Vector2)lastNode.transform.position;

		GameObject go = (GameObject) Instantiate(nodePrefab, pos2Create, Quaternion.identity);

		go.tag = "Grappling Hook";

		go.transform.SetParent (transform);

		lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();

		lastNode = go;

        Nodes.Add(lastNode);

        vertexCount++;
	}

    private void DestroySelf()
    {
		Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
		Debug.Log(hitInfo.name);
		Enemy1 enemy = hitInfo.GetComponent<Enemy1>();
		if (enemy != null)
        {
			enemy.TakeDamage(damage);
			Instantiate(hitEnemySparksEffect, transform.position, transform.rotation);
			//Destroy(player.GetComponent<throwhook>().curHook);
			//player.GetComponent<throwhook>().ropeActive = false;
			Invoke("resetRope", 0.25f);
			Vector2 directionOfObj = (Vector2)transform.position - (Vector2)hitInfo.GetComponent<Transform>().position;
			hitInfo.GetComponent<Rigidbody2D>().AddForce(directionOfObj.normalized * -enemy.knockbackFromWep);

		}
		Instantiate(sparksEffect, transform.position, transform.rotation);


		if (hitInfo.gameObject.tag == "Can Interact" && hitInfo.gameObject.GetComponent<Rigidbody2D>().mass < 10)
		{
			//Destroy(player.GetComponent<throwhook>().curHook);
			//player.GetComponent<throwhook>().ropeActive = false;
			Invoke("resetRope", 0.05f);
			GameObject hookedItem = hitInfo.gameObject;
			Vector2 directionOfObj = (Vector2)transform.position - (Vector2)hookedItem.transform.position;

			if (player.GetComponent<PlayerMovement>().crouch) // crouch to pull object to player
            {
				//hookedItem.GetComponent<Transform>().position = Vector2.MoveTowards((Vector2)hookedItem.transform.position, (Vector2)transform.position, 10);
				hookedItem.GetComponent<Rigidbody2D>().AddForce(directionOfObj.normalized * hookPullForce);
			} else // else push object away from player
            {
				hookedItem.GetComponent<Rigidbody2D>().AddForce(directionOfObj.normalized * -hookPushForce);
				//hookedItem.GetComponent<Transform>().position = Vector2.MoveTowards((Vector2)hookedItem.transform.position, (Vector2)transform.position, 10);
			}


		}

		if (hitInfo.gameObject.tag == "Collectibles" || hitInfo.gameObject.tag == "Enemy")
        {
			Invoke("resetRope", 0.1f);

		}

		if (hitInfo.gameObject.tag == "Can Fall")
		{
/*			transform.position = Vector2.MoveTowards(transform.position, hitInfo.gameObject.GetComponent<Transform>().position, 10);
			Debug.Log(transform.position);*/
			Invoke("resetRope", hitInfo.gameObject.GetComponent<FallingRock>().timeb4Fall + 0.1f);

		}

	}

	void resetRope()
	{
		Destroy(player.GetComponent<throwhook>().curHook);
		player.GetComponent<throwhook>().ropeActive = false;
	}
}

