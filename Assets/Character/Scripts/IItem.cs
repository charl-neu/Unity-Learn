using UnityEngine;

public interface IItem
{
    void OnPickip(Actor owner);
    void OnDrop(Actor owner);
}
