using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManagerScript : MonoBehaviour
{
    enum EndingNumber
    {
        good = 0,
        fall = 1
    }

    [SerializeField]
    GameObject orihime;
    [SerializeField]
    OrihimeEndingScript orihimeScript;
    [SerializeField]
    GameObject hikoboshi;
    [SerializeField]
    OrihimeEndingScript hikoboshiScript;
    // Start is called before the first frame update
    void Start()
    {
        orihimeScript.setMove();
        hikoboshiScript.setMove();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
