using System.Collections;
using UnityEngine;

public class Bomb : Shape
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    public override void Init(Pooler pooler)
    {
        base.Init(pooler);
        MeshRenderer.material.color = Color.black;
        Exploade();
    }

    private void Exploade()
    {
        if (CoroutineSave != null)
            StopCoroutine(CoroutineSave);

        CoroutineSave = StartCoroutine(Work());
    }

    private float CalculateTime()
    {
        float erorRandom = 1f;
        float timeMin = 2f;
        float timeMax = 5f;
        return Random.Range(timeMin, timeMax + erorRandom);
    }

    private IEnumerator Work()
    {
        float delay = 1f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        float time = CalculateTime();
        float step = MeshRenderer.material.color.a / time;

        while (time > 0)
        {
            MeshRenderer.material.color = new Color(MeshRenderer.material.color.r, MeshRenderer.material.color.g, MeshRenderer.material.color.b, Mathf.MoveTowards(MeshRenderer.material.color.a, 0f, step));
            time--;
            yield return wait;
        }

        RigidbodyObject.AddExplosionForce(_force, transform.position, _radius);
        Pooler.Release(this);
    }
}
