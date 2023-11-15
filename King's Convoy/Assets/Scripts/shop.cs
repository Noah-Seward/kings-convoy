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
    }

    public void SelectMachineTurret()
    {
        Debug.Log("Machine Turret Selected");
        buildManager.SelectTurretToBuild(machineTurret);
    }
}
