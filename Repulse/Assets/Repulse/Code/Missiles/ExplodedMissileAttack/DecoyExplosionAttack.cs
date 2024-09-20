using UnityEngine;

public class DecoyExplosionAttack : MonoBehaviour, IDecoy
{
    [SerializeField, Min(0f)] private float _damage;

    [SerializeField] private OverlapSettings _overlapSettings;

    private OverlapTargetFinder _targetFinder;

    private void Start()
    {
        _targetFinder = new OverlapTargetFinder(_overlapSettings);
    }

    public void DecoyExploed()
    {
        if(_targetFinder.TryFind(out IDamageable damageable))
        {
            Debug.Log("� �� � ��");

            damageable.ApplyDamage(_damage);
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        Debug.Log("����������");
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
