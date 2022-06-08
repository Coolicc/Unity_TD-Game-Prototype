using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;
    public TurretModel machineGunTurret;
    public TurretModel missileTurret;
    public TurretModel laserTurret;
    public TurretModel generatorTurret;

    public void SelectMachineGunTurret() {
        buildManager.SetTurretToBuild(machineGunTurret);
    }

    public void SelectMissileTurret() {
        buildManager.SetTurretToBuild(missileTurret);
    }

    public void SelectLaserTurret() {
        buildManager.SetTurretToBuild(laserTurret);
    }

    public void SelectGeneratorTurret() {
        buildManager.SetTurretToBuild(generatorTurret);
    }

	// Use this for initialization
	void Start () {
        buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
