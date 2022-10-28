using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public GameObject Character;
    private Rigidbody2D Rigidbody2D;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(Character == null) return;
        
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        CharacterMovement character = collision.GetComponent<CharacterMovement>();
        if (character != null)
        {
            character.HitObject();
        }
    }
}
