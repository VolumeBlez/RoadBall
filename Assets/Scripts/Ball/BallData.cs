using UnityEngine;

[CreateAssetMenu(fileName = "Ball Settings")]
public class BallData : ScriptableObject
{
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private AnimationCurve _speedModifyFromTurns;
    [SerializeField] private float _modifyMultipler = 0.002f;

    public float DefaultSpeed => _defaultSpeed;
    public AnimationCurve SpeedModifyFromTurns => _speedModifyFromTurns;
    public float ModifyMultiplier => _modifyMultipler;
}
