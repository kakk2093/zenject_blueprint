using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    [SerializeField] private float _destroyTime = 2f;

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
}
