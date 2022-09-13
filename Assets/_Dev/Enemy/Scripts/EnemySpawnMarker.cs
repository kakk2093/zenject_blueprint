using UnityEngine;

public class EnemySpawnMarker : MonoBehaviour
{
    public EnemyType EnemyType;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1);
        Gizmos.color = Color.white;
    }
}
