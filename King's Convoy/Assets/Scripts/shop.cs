using UnityEngine;

public class shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint machineTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
        buildManager.cannonRange.SetActive(true);
    }

    public void SelectMachineTurret()
    {
        Debug.Log("Machine Turret Selected");
        buildManager.SelectTurretToBuild(machineTurret);
        buildManager.machineRange.SetActive(true);
    }
}
