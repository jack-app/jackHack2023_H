using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TalkData : ScriptableObject
{

    [SerializeField]
    string testString = "これはScriptableObjectのテストです。";
    public List<string> talks;
    public string TestString { get { return testString; } }

}

