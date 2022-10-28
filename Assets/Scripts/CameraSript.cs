using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Character;

    // Update is called once per frame
    void Update()
    {
        if(Character == null) return;
        Vector3 position = transform.position;
        position.x = Character.transform.position.x;
        position.y = Character.transform.position.y;
        transform.position = position;
    }
}
