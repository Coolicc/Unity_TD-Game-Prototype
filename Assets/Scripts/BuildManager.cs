using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    public TurretSelectUI turretSelectUI;

    private TurretModel turretToBuild;
    
    private Node selectedNode;

    private void Awake() {
        instance = this;
    }

    public void SetTurretToBuild(TurretModel turret) {
        turretToBuild = turret;
        selectedNode = null;

        DeselectNode();
    }

    public void selectNode(Node node) {
        if (selectedNode == node) {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        turretSelectUI.setSelectedNode(selectedNode);
    }

    public void DeselectNode() {
        selectedNode = null;
        turretSelectUI.Hide();
    }

    public bool CanBuild() {
        return turretToBuild != null;
    }

    public bool HasEnoughMoney() {
        return PlayerStats.Money >= turretToBuild.cost;
    }

    public TurretModel GetTurretToBuild() {
        return turretToBuild;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
