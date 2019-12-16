using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    float Limit = 15.0f;         // 回転の限界値
    float x, y, z;               // それぞれの回転を記憶する値
    // Start is called before the first frame update
    void Start()
    {
        GyroManager.Instance.EnableGyro();

    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = (GyroManager.Instance.GetGyroRotation());
        
    }

    //private bool isLimit()
    //{
    //    if() { return false; }
    //    return true;
    //}
}
