using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EyeRotator : MonoBehaviour
{
    void Update()
    {
        // 指定オブジェクトを中心に回転する
        this.transform.RotateAround(
            transform.position,
            transform.forward,
            360.0f * 0.75f * Time.deltaTime
            );
    }
}
