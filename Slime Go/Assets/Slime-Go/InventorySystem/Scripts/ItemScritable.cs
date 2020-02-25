using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName ="SlimeGo.../Item")]
public class ItemScritable : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite sprite;

}
