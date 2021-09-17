using UnityEngine;

public static class Globals
{
    public static Camera MainCamera { get; private set; } = Camera.main;

    public const int MoneyAmountInOneStack = 1;
    
    #region Layer Masks

    public static LayerMask LayerMaskEnemy { get; private set; } = LayerMask.GetMask("Enemy");
    public static LayerMask LayerMaskPlayer { get; private set; } = LayerMask.GetMask("Player");
    
    public static LayerMask LayerMaskCharacter { get; private set; } = LayerMaskEnemy + LayerMaskPlayer;

    #endregion

    #region Animation States

    public static string TriggerOnDied { get; private set; } = "OnDied";
    public static string TriggerOnStartedMoving { get; private set; } = "OnStartedMoving";
    public static string TriggerOnStoppedMoving { get; private set; } = "OnStoppedMoving";
    
    public static string BoolIsShooting { get; private set; } = "IsShooting";
    
    public static string FloatMoveSpeed { get; private set; } = "MoveSpeed";
    public static string FloatMoveSpeedWithWeapon { get; private set; } = "MoveSpeedWithWeapon";
    
    #endregion

    #region Scene IDs
    
    public const int MainMenuSceneID = 0;
    public const int FirstLevelID = 1;

    #endregion
}
