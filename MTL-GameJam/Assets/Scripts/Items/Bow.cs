using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Item {

    public Arrow arrow;
    public override void Use()
    {
        PlayableCharacter CurrentCharacter = WorldManager.instance.GetCurrentCharacter();

        Arrow copy = GameObject.Instantiate(arrow.gameObject).GetComponent<Arrow>();
        copy.direction = CurrentCharacter.GetDirection();
        copy.Position = CurrentCharacter.Position;
        copy.transform.parent = WorldManager.instance.GetCurrentWorld().gameObject.transform;
    }
}
