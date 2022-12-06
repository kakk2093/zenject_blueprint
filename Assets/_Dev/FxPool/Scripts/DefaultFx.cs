using UnityEngine;
using Zenject;

public class DefaultFx : MonoBehaviour
{
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
