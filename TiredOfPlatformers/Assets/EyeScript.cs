using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeScript : MonoBehaviour
{
    public GameObject topLids;
    public GameObject bottomLids;
    public GameObject darkener;
    public float darkenerValue;
    public float step;

    public Vector3 topTarget;
    public Vector3 bottomTarget;

    public float distance;

    public Slider sleepSlider; //max 255

    public Vector3 topLidStart;
    public Vector3 bottomLidStart;


    Vector2 p1, p2;
    void Start()
    {
        topLidStart = topLids.transform.position;
        bottomLidStart = bottomLids.transform.position;
        sleepSlider.value = 0;
        p1 = new Vector2(topLids.transform.position.x, topLids.transform.position.y);
        p2 = new Vector2(topLids.transform.position.x, topLids.transform.position.y - 5);
        topTarget = new Vector3(topLids.transform.position.x, topLids.transform.position.y - 10, topLids.transform.position.z);
        bottomTarget = new Vector3(bottomLids.transform.position.x, bottomLids.transform.position.y + 10, bottomLids.transform.position.z);
    }

    void Update()
    {
        Debug.Log(step);
        Eyes();

        if(topLids.transform.position.y > topLidStart.y)
        {
            topLids.transform.position = topLidStart;
            sleepSlider.value = 0;
        }
    }

    void Eyes()
    {
        if (sleepSlider.value < sleepSlider.maxValue)
        {
            sleepSlider.value += 0.2f;
            darkener.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)sleepSlider.value);
            topLids.transform.position = Vector3.MoveTowards(topLids.transform.position, topTarget, Time.deltaTime);
            bottomLids.transform.position = Vector3.MoveTowards(bottomLids.transform.position, bottomTarget, Time.deltaTime);
        }
    }
    /*
    void CloseEyes()
    {
        step = 1 * Time.deltaTime;
        topLids.transform.position = Vector3.MoveTowards(topLids.transform.position, topTarget, step);
        bottomLids.transform.position = Vector3.MoveTowards(bottomLids.transform.position, bottomTarget, step);

        distance = Vector3.Distance(topLids.transform.position, bottomLids.transform.position);
        darkenerValue += distance / 16;
        Debug.Log("darkenervalue: " + darkenerValue);
        Debug.Log("distance divided: " + distance / 16);
        darkener.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)darkenerValue);
        sleepSlider.value = darkenerValue;
    }

    void OpenEyes()
    {
        step = 1 * Time.deltaTime;
        topLids.transform.position = -Vector3.MoveTowards(topLids.transform.position, topTarget, step);
        bottomLids.transform.position = -Vector3.MoveTowards(bottomLids.transform.position, bottomTarget, step);

        distance = -Vector3.Distance(topLids.transform.position, bottomLids.transform.position);
        darkenerValue -= distance / 16;
        darkener.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)darkenerValue);
        sleepSlider.value = darkenerValue;
    }
    */
}
