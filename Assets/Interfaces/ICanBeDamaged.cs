using UnityEngine;
using System.Collections;

public interface ICanBeDamaged {

    void TakeDamage(int damageAmount);
    void Die();
}
