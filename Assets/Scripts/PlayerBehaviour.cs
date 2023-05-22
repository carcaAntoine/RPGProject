using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour, IDamage
{
    int IDamage.life{get {return life;}}
    int IDamage.strength{get {return strength;}}

    public int life;
    public int strength;


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Je touche un animal/objet");
        if(collision.transform.tag == "Animal")
        {
            Hit(collision);
        }
    }

    public void Hit(Collision other)
    {
        //other.transform.GetComponent<AnimalBehaviour>().TakeDamage(strength);
        other.transform.GetComponent<IDamage>().TakeDamage(strength);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        life -= damage;
        if (life <= 0)
        {
            Debug.Log("Game Over");
        }
        else
        {
            Debug.Log("Il reste au joueur " + life + " points de vie.");
        }
    }
}