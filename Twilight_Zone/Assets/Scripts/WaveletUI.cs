using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveletUI : MonoBehaviour
{
    public int TotalMaxHeight = 420;
    public int CurrentMaxHeight;

    public int height;

    private RectTransform lRectTransform;

    private void Awake() 
    {
        lRectTransform = gameObject.GetComponent<RectTransform>();        
    }

    public void addMaxHealth(float pPercentage)
     {
         if (TotalMaxHeight ==  CurrentMaxHeight)
         {
             return;
         }

        float newY = lRectTransform.sizeDelta.y + (lRectTransform.sizeDelta.y * pPercentage)/100f;
        // Do not go over max height
        newY = Mathf.Min(newY, TotalMaxHeight);
        CurrentMaxHeight = (int)newY;
     }

    public void setHealth(float pHealth)
    {

    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
         {
             addMaxHealth(14);
         }
    }
}
