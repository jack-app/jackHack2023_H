using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManagerScript : MonoBehaviour
{
    public enum EndingNumber
    {
        father = 0,
        fall = 1,
        reject = 2,
        good = 3
    }

    public enum EndingState
    {
        walk,
        heart,
        good,
        fall

    }

    public EndingState endingState;
    [SerializeField]
    public EndingNumber endingNumber = (EndingNumber)1;
    [SerializeField]
    GameObject orihime;
    [SerializeField]
    OrihimeEndingScript orihimeScript;
    [SerializeField]
    GameObject hikoboshi;
    [SerializeField]
    OrihimeEndingScript hikoboshiScript;
    [SerializeField]
    Rigidbody fallRb;
    [SerializeField]
    HeartKakusu heartKakusu;
    [SerializeField]
    TalkData talkData;
    [SerializeField]
    Text talkText;
    // Start is called before the first frame update
    void Start()
    {
        if (endingNumber != EndingNumber.father)
        {
            orihimeScript.setMove();
            hikoboshiScript.setMove();
            endingState = EndingState.walk;
        }
        else
        {
            orihime.SetActive(false);
            hikoboshi.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(EndingState nowState)
    {
        switch (endingNumber)
        {

        }
    }

    public void ExitWalk()
    {
        switch (endingNumber)
        {
            case EndingNumber.good:
                StartCoroutine(HeartStart(10000));
                StartCoroutine(propose(3, 0));
                StartCoroutine(propose(15, 1));
                break;
            case EndingNumber.reject:
                StartCoroutine(HeartStart(5));
                StartCoroutine(propose(3, 0));
                StartCoroutine(propose(10, 2));
                break;
            case EndingNumber.fall:
                StartCoroutine(HeartStart(2));
                StartCoroutine(propose(0, 3));
                fallRb.useGravity = true;
                break;
            default:
                break;
        }
    }

    private IEnumerator HeartStart(float time)
    {
        heartKakusu.velocity = 1.2f;
        yield return new WaitForSeconds(time);
        heartKakusu.velocity = 0;
    }

    private IEnumerator propose(float time, int talkIndex)
    {
        yield return new WaitForSeconds(time);
        talkText.text = talkData.talks[talkIndex];
    }
}
