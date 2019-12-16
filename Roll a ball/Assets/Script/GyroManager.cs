using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    #region Instance
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if(instance == null)
                {
                    instance = new GameObject("Spawned,GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;
    private float limitRot = 0.3f;     // 回転の限界値±0.5

    public void EnableGyro()
    {
        // Already activated
        if (gyroActive) return;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        }
        else
        {
            Debug.Log("Gyro is not supported on this device");
        }
    }

    void Update()
    {
        if (gyroActive)
        {  
            rotation = gyro.attitude;
            Debug.Log(rotation);
        }
    }

    public Quaternion GetGyroRotation()
    {
        float t;
        t = rotation.y;
        rotation.y = rotation.z*-1;
        rotation.z = t;
        rotation.w *= 0;

        if (rotation.x >= limitRot) rotation.x = 0.3f;
        if (rotation.x <= limitRot * -1) rotation.x = -0.3f;

        return rotation;
    }
}


