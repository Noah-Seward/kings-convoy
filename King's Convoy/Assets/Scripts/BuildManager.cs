using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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

    public GameObject machineRange;
    public GameObject cannonRange;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetKey("r"))
        {
            turretToBuild = null;
        }

        FollowMouse();
    }

    private void FollowMouse()
    {
        if(turretToBuild != null)
        {
            Vector3 mousePos;
            // Translates the mouse on screen to world position
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0.7f, Input.mousePosition.z));
            machineRange.transform.position = mousePos;
            cannonRange.transform.position = mousePos;
        }
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

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money waaa waaa.");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret built! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        machineRange = Instantiate(machineRange, Input.mousePosition, Quaternion.identity);
    }
}
