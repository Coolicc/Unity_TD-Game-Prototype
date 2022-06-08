using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color cantBuildColor;
    public GameObject buildEffect;
    public GameObject sellEffect;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretModel turretModel;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer r;
    private Color defaultColor;

    BuildManager buildManager;

	// Use this for initialization
	void Start () {
        r = GetComponent<Renderer>();
        defaultColor = r.material.color;
        buildManager = BuildManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (turret != null) {
            buildManager.selectNode(this);
            return;
        }

        if (!buildManager.CanBuild()) {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretModel model) {
        if (PlayerStats.Money < model.cost) {
            return;
        }

        PlayerStats.Money -= model.cost;
        
        turret = (GameObject)Instantiate(model.prefab, transform.position + model.positionOffset, Quaternion.identity);
        turretModel = model;
        GameObject effect = (GameObject)Instantiate(buildEffect, transform.position + model.positionOffset, Quaternion.identity);
        Destroy(effect, 2f);
    }

    public void UpgradeTurret() {
        if (PlayerStats.Money < turretModel.upgradeCost) {
            return;
        }

        PlayerStats.Money -= turretModel.upgradeCost;

        Destroy(turret);

        turret = (GameObject)Instantiate(turretModel.upgradePrefab, transform.position + turretModel.upgradePositionOffset, Quaternion.identity);
        GameObject effect = (GameObject)Instantiate(buildEffect, transform.position + turretModel.upgradePositionOffset, Quaternion.identity);
        Destroy(effect, 2f);
        isUpgraded = true;
    }

    public void SellTurret() {

        PlayerStats.Money += turretModel.getRefundAmount();

        GameObject effect = (GameObject)Instantiate(sellEffect, transform.position + turretModel.upgradePositionOffset, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(turret);
        turretModel = null;
    }

    private void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (!buildManager.CanBuild()) {
            return;
        }

        if (buildManager.HasEnoughMoney()) {
            r.material.color = hoverColor;
        } else {
            r.material.color = cantBuildColor;
        }

        
    }

    private void OnMouseExit() {
        r.material.color = defaultColor;
    }
}
