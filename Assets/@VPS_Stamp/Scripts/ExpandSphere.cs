using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExpandSphere : MonoBehaviour
{
    [SerializeField] private float _maxScale, _minScale;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Expand());
    }

    private IEnumerator Expand()
    {
        while(true)
        {
            gameObject.transform.DOScale(_maxScale, 0.25f).OnComplete(() => gameObject.transform.DOScale(_minScale, 0.25f));
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }
}
