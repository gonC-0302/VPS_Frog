using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FrogMovementg : MonoBehaviour
{
    private float originRotY;
    private IEnumerator Start()
    {
        originRotY = transform.localEulerAngles.y;

        transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(Random.Range(10f, 15f));
        transform.DOScale(Random.Range(2f, 3f), 0.1f);

        var targetPos = transform.position + transform.forward * 2;
        transform.DOJump(targetPos, 1.8f, 1, 0.5f).OnComplete(() => StartCoroutine(Jump()));
        transform.DOLocalRotate(new Vector3(-30, originRotY, 0), 0.2f).OnComplete(() => transform.DOLocalRotate(new Vector3(10, originRotY, 0), 0.2f).OnComplete(() => transform.DOLocalRotate(new Vector3(0, originRotY, 0), 0.05f)));
    }

    private IEnumerator Jump()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3f,7f));
            transform.DOLocalRotate(new Vector3(-20, originRotY, 0),0.1f).OnComplete(() => transform.DOLocalRotate(new Vector3(5, originRotY, 0), 0.1f).OnComplete(() => transform.DOLocalRotate(new Vector3(0, originRotY, 0), 0.05f)));
            transform.DOJump(transform.position, 0.4f, 1, 0.25f);
        }
    }
}
