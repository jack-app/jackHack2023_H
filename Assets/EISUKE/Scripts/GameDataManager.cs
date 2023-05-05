using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{ 
    public int weight{ get; set; }
    public int hikoValue{ get; set; }
    public int fatherValue{ get; set; }
    public int bridgeValue{ get; set; }
    public int staminaValue{ get; set; } 
    public static GameDataManager Instance { get; private set; }
    private void Awake() 
    {
        weight = 40;
        hikoValue = 0; 
        fatherValue = 3; 
        bridgeValue = 0; 
        staminaValue = 100; 
        Instance = this;
    }
}
