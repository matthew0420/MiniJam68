using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScript : MonoBehaviour
{
    public GameObject selectObject;

    private void Start()
    {
        selectObject.SetActive(false);
    }
    private void OnMouseOver()
    {
        selectObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        selectObject.SetActive(false); 
    }
}
