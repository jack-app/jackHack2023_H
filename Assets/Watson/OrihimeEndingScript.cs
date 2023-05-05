using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrihimeEndingScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float frontVecX;
    [SerializeField]
    EndingManagerScript endingManagerScript;

    bool isMove = false;
    bool isOrihime = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            rb.position += new Vector3(0, 0, frontVecX) * Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BridgeCenter")
        {
            if (isOrihime && isMove)
            {
                endingManagerScript.ExitWalk();
            }
            isMove = false;
        }
    }

    public void setMove()
    {
        isMove = true;
    }
}