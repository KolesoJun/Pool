using UnityEngine;

public class SpawnerBomb : MonoBehaviour
{
    [SerializeField] private Pooler _pooler;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Spawn(Vector3.zero);
    }

    private void OnEnable()
    {
        _pooler.ReleasedNotBomb += Spawn;
    }

    private void OnDisable()
    {
        _pooler.ReleasedNotBomb -= Spawn;
    }

    protected void Spawn(Vector3 position)
    {
        Shape shape = _pooler.Get(transform);

        if (shape != null)
            shape.transform.position = position;
    }
}
