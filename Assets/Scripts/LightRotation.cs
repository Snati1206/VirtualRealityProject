using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    public GameObject sun;
    public GameObject targetObject;
    public float rotationSpeed = 10f;
    Vector3 sunPos;
    Vector3 targetPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!sun )
        {
            Debug.LogError("sun not assigned");
            return;
        }

        if (!targetObject)
        {
            Debug.LogError("no target to turn around");
        }

        else
        {
            sunPos = sun.transform.position;
            targetPos = targetObject.transform.position;  
   
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EventCoroutine.transition == true)
        {
            Rotation(sun, targetPos, rotationSpeed);
        }
        else
        {
            return;
        }
    }
    void Rotation(GameObject sun, Vector3 target, float rotationSpeed)
    {
            sun.transform.RotateAround(target, Vector3.up, XboxController.yButtonValue/20f + rotationSpeed * Time.deltaTime);
            sun.transform.LookAt(target);
    }
}
