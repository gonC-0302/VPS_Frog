using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectSpawner_Sample : MonoBehaviour
{
    public enum TouchInfo
    {
        /// <summary>
        /// タッチなし
        /// </summary>
        None = 99,

        // 以下は UnityEngine.TouchPhase の値に対応
        /// <summary>
        /// タッチ開始
        /// </summary>
        Began = 0,
        /// <summary>
        /// タッチ移動
        /// </summary>
        Moved = 1,
        /// <summary>
        /// タッチ静止
        /// </summary>
        Stationary = 2,
        /// <summary>
        /// タッチ終了
        /// </summary>
        Ended = 3,
        /// <summary>
        /// タッチキャンセル
        /// </summary>
        Canceled = 4,
    }

    [SerializeField]
    GameObject objectPrefab;

    private static Vector3 TouchPosition = Vector3.zero;

    public TrackableType type;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastManager.Raycast(GetTouchPosition(), hitResults, type))
            {

                Instantiate(objectPrefab, hitResults[0].pose.position, Quaternion.identity);
            }
        }
    }

    public static TouchInfo GetTouch()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0)) { return TouchInfo.Began; }
            if (Input.GetMouseButton(0)) { return TouchInfo.Moved; }
            if (Input.GetMouseButtonUp(0)) { return TouchInfo.Ended; }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                return (TouchInfo)((int)Input.GetTouch(0).phase);
            }
        }
        return TouchInfo.None;
    }
    public static Vector3 GetTouchPosition()
    {
        if (Application.isEditor)
        {
            TouchInfo touch = GetTouch();
            if (touch != TouchInfo.None)
            {
                return Input.mousePosition;
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                TouchPosition.x = touch.position.x;
                TouchPosition.y = touch.position.y;
                return TouchPosition;
            }
        }
        return Vector3.zero;
    }
}
