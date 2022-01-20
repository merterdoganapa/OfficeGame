using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hitInfos = Physics.RaycastAll(ray);
            for (int i = hitInfos.Length - 1; i >= 0 ; i--)
            {
                IClickable clickable = hitInfos[i].transform.gameObject.GetComponent<IClickable>();
                if (clickable != null) { 
                    clickable.Click();
                    break;
                }
            }
        }
    }
}
