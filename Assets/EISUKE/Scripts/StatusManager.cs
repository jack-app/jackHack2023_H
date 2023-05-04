using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [SerializeField] Eating eating; 
    [SerializeField] Weaving weaving; 
    [SerializeField] Writing writing; 
    [SerializeField] GrantWish grantWish; 

    public void WeavingButtonActive()
    {
        weaving.weavingButton.interactable = true;
    }
    public void WeavingButtonInActive()
    {
        weaving.weavingButton.interactable = false;
    }
    public void WritingButtonActive()
    {
        writing.writingButton.interactable = true;
    }
    public void WritingButtonInActive()
    {
        writing.writingButton.interactable = false;
    }
    public void GrantWishButtonActive()
    {
        grantWish.grantWishButton.interactable = true;
    }
    public void GrantWishButtonInActive()
    {
        grantWish.grantWishButton.interactable = false;
    }
}
