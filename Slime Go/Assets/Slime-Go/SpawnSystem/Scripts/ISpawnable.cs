using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public interface ISpawnable
    {
        GameObject Spawn(float x, float z);
    }
}

