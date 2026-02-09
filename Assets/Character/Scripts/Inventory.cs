using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<IItem> items = new List<IItem>();

    public IItem CurrentItem { get; private set; } = null;

    private void Start()
    {
        CurrentItem = items[0];
    }
}
