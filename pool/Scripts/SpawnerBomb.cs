using UnityEngine;

public class SpawnerBomb : MonoBehaviour
{
    [SerializeField] private Pooler _poolerBrick;
    [SerializeField] private Pooler _poolerBomb;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Spawn(Vector3.zero);
    }

    private void OnEnable()
    {
        _poolerBrick.ReleasedNotBomb += Spawn;
    }

    private void OnDisable()
    {
        _poolerBrick.ReleasedNotBomb -= Spawn;
    }

    protected void Spawn(Vector3 position)
    {
        Shape shape = _poolerBomb.Get(transform);

        if (shape != null)
            shape.transform.position = position;
    }
}
