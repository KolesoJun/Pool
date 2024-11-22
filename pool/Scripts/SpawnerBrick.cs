using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBrick : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnSectorMin;
    [SerializeField] private Vector3 _spawnSectorMax;
    [SerializeField] private float _delay;
    [SerializeField] private Pooler _pooler;

    private bool _canWork = true;

    private void Start()
    {
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_canWork)
        {
            Shape shape = _pooler.Get(transform);

            if (shape != null)
            {
                shape.transform.position = new Vector3(Random.Range(_spawnSectorMin.x, _spawnSectorMax.x),
                    Random.Range(_spawnSectorMin.y, _spawnSectorMax.y), Random.Range(_spawnSectorMin.z, _spawnSectorMax.z));
            }
                      
            yield return wait;
        }
    }
}
