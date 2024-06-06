using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorCircleController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ChangeScale());
    }
    private IEnumerator ChangeScale()
    {
        while(true)
        {
            var _randomScale = Random.Range(1.25f, 2.5f);
            gameObject.transform.DOScale(_randomScale, 0.25f).SetEase(Ease.OutBounce).OnComplete(() => gameObject.transform.DOScale(1, 0.5f));
            var intervalTime = Random.Range(1f, 2f);
            yield return new WaitForSeconds(intervalTime);
        }
    }
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
