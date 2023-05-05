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
    [SerializeField]
    GameObject button;
    [SerializeField]
    Image endPanel;

    [SerializeField] GameObject orihimeBody;
    // Start is called before the first frame update
    void Start()
    {
        float weight = EndingManager.Instance.lastWeight;
        orihimeBody.transform.localScale = new Vector3(weight / 40f, weight / 40f, weight / 40f);
        if (EndingManager.Instance)
        {
            endingNumber = (EndingNumber)EndingManager.Instance.endingNum;
        }
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
            StartCoroutine(propose(8, 5));
            StartCoroutine(showButton(14));
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
                StartCoroutine(EndFadeIn(20));
                break;
            case EndingNumber.reject:
                StartCoroutine(HeartStart(5));
                StartCoroutine(propose(3, 0));
                StartCoroutine(propose(10, 2));
                StartCoroutine(showButton(14));
                break;
            case EndingNumber.fall:
                StartCoroutine(HeartStart(2));
                StartCoroutine(propose(0, 3));
                fallRb.useGravity = true;
                StartCoroutine(propose(10, 4));
                StartCoroutine(showButton(14));
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

    private IEnumerator showButton(float time)
    {
        yield return new WaitForSeconds(time);
        button.SetActive(true);
    }

    IEnumerator EndFadeIn(float time)
    {
        yield return new WaitForSeconds(time);
        endPanel.gameObject.SetActive(true);
        float speed = 0.005f;
        while (endPanel.color.a < 1)
        {
            endPanel.color = new Color(endPanel.color.r, endPanel.color.g, endPanel.color.b, endPanel.color.a + speed);
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(showButton(0));
        yield return null;
    }
}
