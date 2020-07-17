 using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class Grapple : MonoBehaviour
{
    private Vector3 _mousePos;
    private Camera _camera;

    private bool _check; // check if player is currently grappling or not
    private DistanceJoint2D _distanceJoint;
    private LineRenderer _lineRenderer;
    private Vector3 _tempPos; // position of anchor pt
    public LayerMask grappleMask;
    public Transform player;
    public float ropeLength = 5f; // length of grapple hook

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main; // get the main camera
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _distanceJoint.enabled = false;
        _check = true;
        _lineRenderer.positionCount = 0; // set initial count position to 0
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();
        //RaycastHit2D hit2D = Physics2D.Raycast(transform.position, _mousePos - transform.position, Vector3.Distance(transform.position, _mousePos), grappleMask);  use this for unlimited grapple hook length
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, _mousePos - transform.position, ropeLength, grappleMask);

        if (Input.GetMouseButtonDown(0) && _check && hit2D.collider != null)
        {
            _distanceJoint.enabled = true;
            Vector3 anchorpt = hit2D.point; // convert Vector2 to Vector3
            _distanceJoint.connectedAnchor = anchorpt;
            _lineRenderer.positionCount = 2;
            _tempPos = anchorpt;
            _check = false; 
        } else if (Input.GetMouseButtonDown(0))
        {
            _distanceJoint.enabled = false;
            _check = true;
            _lineRenderer.positionCount = 0;
        }
        DrawLine();
    }

    private void DrawLine()
    {
        if (_lineRenderer.positionCount <= 0) return;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _tempPos);
    }

    private void GetMousePos()
    {
        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition); // get the world point of mouse position
        _mousePos.z = 0f; // set z to 0
    }

}
