using UnityEngine;

public interface IEquippable
{
    void OnEquip(Actor owner);
    void OnUnequip(Actor owner);
}
