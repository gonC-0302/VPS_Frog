using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CylinderMovement : MonoBehaviour
{
    private bool isStartRotate;
    [SerializeField] private ParticleSystem _smoke;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        _smoke.Play();
        gameObject.transform.DOShakePosition(1.5f, 0.1f, 5, 90).OnComplete(() => isStartRotate = true);
        yield return new WaitForSeconds(2f);
        MoveUpCylinder();
    }

    private void MoveUpCylinder()
    {
        gameObject.transform.DOMoveY(gameObject.transform.position.y + 1, 5f);
    }

    private void Update()
    {
        if (!isStartRotate) return;
        // 指定オブジェクトを中心に回転する
        this.transform.RotateAround(
            transform.position,
            transform.up * -1,
            360.0f * 0.05f * Time.deltaTime
              );
    }
}
