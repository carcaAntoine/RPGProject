using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
   int life {get;}
   int strength {get;}
    void Hit(Collision other);
    void TakeDamage(int damage);
}
