using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float _shieldAmount;

    public void OnCollected(GameObject player)
    {   
        player.GetComponent<ShieldController>().AddShield(_shieldAmount);
    }
}
