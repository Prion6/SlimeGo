using UnityEngine;

namespace Slime
{
    [CreateAssetMenu(fileName = "New Slime", menuName = "SlimeGo.../Slime")]
    public class SlimeScriptable : ScriptableObject
    {
        public string slimeName;
        public SlimeType type;
        public Sprite InventoryImage;
        public GameObject prefab;
    }
}

