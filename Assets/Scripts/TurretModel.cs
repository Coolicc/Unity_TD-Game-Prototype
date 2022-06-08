using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretModel {

    public GameObject prefab;
    public int cost;
    public Vector3 positionOffset;
    public GameObject upgradePrefab;
    public int upgradeCost;
    public Vector3 upgradePositionOffset;

    public int getRefundAmount() {
        return cost / 2;
    }
}
