using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    [SerializeField] protected MeshRenderer MeshRenderer;
    
    protected Pooler Pooler;
    protected Coroutine CoroutineSave;
    protected Rigidbody RigidbodyObject;

    private void Awake()
    {
        if (gameObject.TryGetComponent(out Rigidbody rigidbody) == false)
            gameObject.AddComponent<Rigidbody>();
        else
            RigidbodyObject = rigidbody;
    }

    public virtual void Init(Pooler pooler)
    {
        Pooler = pooler;
    }
}
