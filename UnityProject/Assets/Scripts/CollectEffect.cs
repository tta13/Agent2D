using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Interactables.Collectible
{
    public class CollectEffect : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 0.5f);
        }
    }
}

