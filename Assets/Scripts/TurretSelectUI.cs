using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretSelectUI : MonoBehaviour {

    private Node selectedNode;
    public GameObject ui;
    public Text upgradeText;
    public Text sellText;
    public Button upgradeButton;

    public void setSelectedNode(Node node) {
        selectedNode = node;

        transform.position = selectedNode.turret.transform.position;

        if (!node.isUpgraded) {
            upgradeText.text = "UPGRADE\n$" + node.turretModel.upgradeCost;
            upgradeButton.interactable = true;
        } else {
            upgradeText.text = "MAX LEVEL";
            upgradeButton.interactable = false;
        }

        sellText.text = "SELL\n$" + node.turretModel.getRefundAmount();

        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade() {
        selectedNode.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell() {
        selectedNode.SellTurret();
        BuildManager.instance.DeselectNode();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
