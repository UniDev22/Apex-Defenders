using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint standardBot;
    public TowerBlueprint missileBot;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectShooterBot(){
        print("ShooterBot has been selected!");
        buildManager.SelectTowerToBuild(standardBot);
    }
    public void SelectMissileBot(){
        print("MissileBot has been selected!");
        buildManager.SelectTowerToBuild(missileBot);
    }
}
