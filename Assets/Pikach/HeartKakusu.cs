using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartKakusu : MonoBehaviour
{
    public float velocity = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //座標を書き換える
        transform.position += new Vector3(0, velocity, 0) * Time.deltaTime;
    }
}
