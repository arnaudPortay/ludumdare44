using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FioleUI : MonoBehaviour
{
    public int minHeight = 130;
    public int maxHeight = 440;

    private RectTransform lRectTransform;

    private void Awake() 
    {
        lRectTransform = gameObject.GetComponent<RectTransform>();        
    }

    // Start is called before the first frame update
     public void addMaxHealth(float pPercentage)
     {
         if (lRectTransform.sizeDelta.y ==  maxHeight)
         {
             return;
         }

        float newY = lRectTransform.sizeDelta.y + (lRectTransform.sizeDelta.y * pPercentage)/100f;
        // Do not go over max height
        newY = Mathf.Min(newY, maxHeight);
        lRectTransform.sizeDelta = new Vector2(lRectTransform.sizeDelta.x, newY);
     }

     private void Update() {
         if (Input.GetMouseButtonDown(0))
         {
             addMaxHealth(14);
         }
     }
}
