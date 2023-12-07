using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in Scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject machineTurretPrefab;

    public GameObject buildEffect;

    public NodeUI nodeUI;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetKey("r"))
        {
            turretToBuild = null;
        }

        //FollowMouse();
    }

    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }

    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
        // machineRange = Instantiate(machineRange, Input.mousePosition, Quaternion.identity);
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
