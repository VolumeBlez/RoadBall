
using UnityEngine;

public class ParallaxSystem : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    [SerializeField, Range(0f, 1f)] private float _parralaxStrength = 0.1f;
    [SerializeField]  private bool _disableVerticalParallax;

    
    private Vector3 _tartgetPreviousPosition;
    void Start()
    {
        if(!_followingTarget)
            _followingTarget = Camera.main.transform;

        _tartgetPreviousPosition = _followingTarget.position;
    }

    void Update()
    {
        var delta = _followingTarget.position - _tartgetPreviousPosition;

        if(_disableVerticalParallax)
            delta.y = 0;

        _tartgetPreviousPosition = _followingTarget.position;
        transform.position += delta * _parralaxStrength;
        
    }
}
