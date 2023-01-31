using System.Collections;
using UnityEngine;
using Zenject;

public class DefaultFx : MonoBehaviour
{
    [SerializeField] private float _despownTime = 2f;

    private DefaultFxPool _pool;

    [Inject]
    private void Construct(DefaultFxPool defaultFxPool)
    {
        _pool = defaultFxPool;
    }

    private void OnEnable()
    {
        DespawnUnit();
    }

    private void DespawnUnit()
    {
        StartCoroutine(DespawnCorutine());
    }

    private IEnumerator DespawnCorutine()
    {
        yield return new WaitForSeconds(_despownTime);
        _pool.Despawn(this);
    }


    public class DefaultFxPool : MemoryPool<DefaultFx>
    {
        protected override void OnCreated(DefaultFx unit)
        {
            unit.gameObject.SetActive(false);
        }

        protected override void OnSpawned(DefaultFx unit)
        {
            unit.gameObject.SetActive(true);
        }

        protected override void OnDespawned(DefaultFx unit)
        {
            unit.transform.position = Vector3.zero;
        }
    }
}
