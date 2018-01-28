using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour {

    public Vector2 Position;

    private void OnValidate()
    {
        transform.position = Position * 1.6f;
    }

    private void Update()
    {
        transform.position = Position * 1.6f;
    }
}
