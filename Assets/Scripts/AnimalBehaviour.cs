using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimalBehaviour : MonoBehaviour, IDamage
{
    int IDamage.life{get {return AnimalLife;}}
    int IDamage.strength{get {return AnimalStrength;}}
    public int AnimalLife;
    public int AnimalStrength;

    public void Hit(Collision other)
    {
        other.transform.GetComponent<AnimalBehaviour>().TakeDamage(AnimalStrength);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        AnimalLife -= damage; 
        if (AnimalLife <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Animal is dead");
        }
        else
        {
            Debug.Log("Il reste à l'animal " + AnimalLife + " points de vie.");
        }
    }
}