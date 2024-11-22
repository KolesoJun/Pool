using System.Collections;
using UnityEngine;

public class Brick : Shape
{
    [SerializeField] private BrickColorManager _colorManager;
    
    private bool _isFirstEnter;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isFirstEnter == false)
        {
            if (collision.gameObject.TryGetComponent<BorderPlane>(out _))
            {
                _isFirstEnter = true;
                MeshRenderer.material.color = _colorManager.ChangeColor();
                StartCoroutine(CountdownLife());
            }
        }
    }

    public override void Init(Pooler pooler)
    {
        base.Init(pooler);
        MeshRenderer.material.color = Color.white;
        _isFirstEnter = false;
    }

    private IEnumerator CountdownLife()
    {
        float lifeTimeMin = 2f;
        float lifeTimeMax = 5f;
        float erorRandom = 1f;
        yield return new WaitForSeconds(Random.Range(lifeTimeMin, lifeTimeMax + erorRandom));
        Pooler.Release(this);
    }
}
