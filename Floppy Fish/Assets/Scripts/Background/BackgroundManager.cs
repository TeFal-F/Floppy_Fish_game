using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject front1;
    public GameObject middle1;
    public GameObject front2;
    public GameObject middle2;
    private float deadZone = -29.53846f;
    private float lifeZone = 29.53846f;

    private void Start()
    {
        front1.transform.position = new Vector3(0, 0, 0);
        middle1.transform.position = new Vector3(0, 0, 0);
        front2.transform.position = new Vector3(lifeZone, 0, 0);
        middle2.transform.position = new Vector3(lifeZone, 0, 0);
    }
    void Update()
    {
        if (front1.transform.position.x <= deadZone)
        {
            front1.transform.position = new Vector3(lifeZone, 0, 0);
        }
        if (front2.transform.position.x <= deadZone)
        {
            front2.transform.position = new Vector3(lifeZone, 0, 0);
        }
        if (middle2.transform.position.x <= deadZone)
        {
            middle2.transform.position = new Vector3(lifeZone, 0, 0);
        }
        if (middle1.transform.position.x <= deadZone)
        {
            middle1.transform.position = new Vector3(lifeZone, 0, 0);
        }
    }
}
