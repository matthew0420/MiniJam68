using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeScript : MonoBehaviour
{
    public GameObject topLids;
    public GameObject bottomLids;
    public GameObject darkener;

    public float step;

    public Vector3 topTarget;
    public Vector3 bottomTarget;

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

    void FixedUpdate()
    {
        Eyes();

        if (topLids.transform.position.y > topLidStart.y)
        {
            topLids.transform.position = topLidStart;
            bottomLids.transform.position = bottomLidStart;
            sleepSlider.value = 0;
        }

        if (sleepSlider.value >= 255)
        {
            GameObject.Find("DeathPit").GetComponent<SceneManagerScript>().LoadAScene();
        }
    }

    void Eyes()
    {
        if (sleepSlider.value < sleepSlider.maxValue)
        {
            sleepSlider.value += 0.5f;
            darkener.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)sleepSlider.value);
            topLids.transform.position = Vector3.MoveTowards(topLids.transform.position, topTarget, Time.deltaTime);
            bottomLids.transform.position = Vector3.MoveTowards(bottomLids.transform.position, bottomTarget, Time.deltaTime);
        }
    }
}
