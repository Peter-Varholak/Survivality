using UnityEngine;
using System.Collections;

public abstract class Spell : MonoBehaviour {

    BulletDestroy bulletDestroyer;

    public int Damage { get; set; }

    public virtual void Start ()
    {
        bulletDestroyer = gameObject.GetComponent<BulletDestroy>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ICanBeDamaged obj = col.collider.GetComponent<ICanBeDamaged>();
        if (obj != null)
        {
            obj.TakeDamage(Damage);
        }
        bulletDestroyer.Destroy();
    }
}
