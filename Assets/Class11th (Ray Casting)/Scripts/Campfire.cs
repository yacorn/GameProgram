using UnityEngine;


class Campfire : Equipment
{
    public override void OnHit()
    {
        Debug.Log("Campfire Hit");
        transform.Rotate(0, 15, 0);
    }
}