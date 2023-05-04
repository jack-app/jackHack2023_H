using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] GameObject foodsPanel; 
    [SerializeField] GameObject weavingPanel; 
    [SerializeField] GameObject writingPanel; 
    [SerializeField] GameObject negaiPanel; 
    [SerializeField] GameObject commands; 
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClickExit()
    {
        ToSelect();
    }
    public void ToSelect()
    {
        gameObject.SetActive(false);
        weavingPanel.SetActive(false);
        foodsPanel.SetActive(false);
        writingPanel.SetActive(false);
        negaiPanel.SetActive(false);
        commands.SetActive(true);
    }
}
