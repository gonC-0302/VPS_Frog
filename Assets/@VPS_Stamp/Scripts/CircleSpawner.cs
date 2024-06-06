using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _circlePrefabsList = new List<GameObject>();

    private int _currentColorID= 0;
    private int _maxColorID;
    // Start is called before the first frame update
    void Start()
    {
        _maxColorID = _circlePrefabsList.Count - 1;
        StartCoroutine(SpawnCircle());

    }

    private IEnumerator SpawnCircle()
    {
        while(true)
        {
            var circle = Instantiate(_circlePrefabsList[_currentColorID], transform);
            circle.transform.localScale = Vector3.zero;
            circle.transform.DOMoveY(transform.position.y -  0.0005f, 4f).SetEase(Ease.Linear).OnComplete(() => Destroy(circle));
            circle.transform.DOScale(1f, 3f).SetEase(Ease.InOutSine);

            _currentColorID++;
            if (_currentColorID > _maxColorID) _currentColorID = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
