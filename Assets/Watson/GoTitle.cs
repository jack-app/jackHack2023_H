using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoTitle : MonoBehaviour
{
    public void GoTitleScene()
    {
        FadeManager.Instance.LoadScene("Daburu", 3.0f);//Endingシーンへ遷移
    }
}
