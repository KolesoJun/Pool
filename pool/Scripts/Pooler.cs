using System;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] private Shape _prefab;
    [SerializeField] private int _countObjects = 10;

    private List<Shape> _shapesPool;
    private Stack<Shape> _shapesPoolActive;

    public int CountCreate => _shapesPool.Count;
    public int CountActive => _shapesPool.Count - _shapesPoolActive.Count;
    public int CountGeneral { get; private set; }

    public event Action<Vector3> ReleasedNotBomb;
    public event Action UpdatedInfo;

    private void Awake()
    {
        Init();
    }

    public Shape Get(Transform transform)
    {
        if (_shapesPoolActive.Count > 0)
        {
            Shape shape = _shapesPoolActive.Pop();
            shape.gameObject.SetActive(true);
            shape.Init(this);
            shape.transform.SetParent(transform);
            CountGeneral++;
            UpdatedInfo?.Invoke();
            return shape;
        }

        return null;
    }

    public void Release(Shape shape)
    {
        if (shape.gameObject.TryGetComponent<Bomb>(out _) == false)
        {
            ReleasedNotBomb?.Invoke(shape.transform.position);
        }

        shape.gameObject.SetActive(false);
        _shapesPoolActive.Push(shape);
        UpdatedInfo?.Invoke();
    }

    private Shape Create()
    {
        Shape shape = Instantiate(_prefab);
        shape.gameObject.SetActive(false);
        _shapesPool.Add(shape);
        _shapesPoolActive.Push(shape);
        UpdatedInfo?.Invoke();
        return shape;
    }

    private void Init()
    {
        _shapesPoolActive = new Stack<Shape>();
        _shapesPool = new List<Shape>();

        for (int i = 0; i < _countObjects; i++)
            Create();
    }
}
