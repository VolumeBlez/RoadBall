using System;
using System.Collections.Generic;
using UnityEngine;

public class CorridorGenerator : MonoBehaviour
{
    [SerializeField] private List<Corridor> _corridorPrefabs; 
    private List<Corridor> _corridors;

    private Corridor corVar;
    private Vector3 posForNewCorridor;
    private DirectionType dirType;
    private List<Corridor> _corridorsWithNededDirectionType;

    public Action<Corridor> CurrentCorridorChanged;

    public void Init() 
    {
        _corridors = new();
        _corridorsWithNededDirectionType = new();
        SpawnCorridor();
    }

    private void SpawnCorridor()
    {
        if(_corridors.Count != 0)
        {
            _corridorsWithNededDirectionType.Clear();
            posForNewCorridor = _corridors[_corridors.Count-1].End.position;
            dirType = _corridors[_corridors.Count-1].EndDirection;

            foreach (var cor in _corridorPrefabs)
            {
                if(cor.BeginDirection == dirType)
                    _corridorsWithNededDirectionType.Add(cor);
            }
            
            corVar = Instantiate(_corridorsWithNededDirectionType[UnityEngine.Random.Range(0, _corridorsWithNededDirectionType.Count)],Vector3.zero, Quaternion.identity);
            corVar.transform.position = posForNewCorridor - corVar.Begin.position;
        }
        else 
        {
            corVar = Instantiate(_corridorPrefabs[0], Vector3.zero, Quaternion.identity);
            CurrentCorridorChanged?.Invoke(corVar);
        }
        corVar.Init();
        corVar.TurnTrigger.PlayerCheckTheTurn += DestroyCorridor;
        _corridors.Add(corVar);
    }

    private void DestroyCorridor(Corridor cor) 
    {
        SpawnCorridor();
        CurrentCorridorChanged?.Invoke(_corridors[_corridors.IndexOf(cor)+1]);

        if(_corridors.Count > 3)
        {   
            cor.TurnTrigger.PlayerCheckTheTurn -= DestroyCorridor;
            Destroy(_corridors[_corridors.IndexOf(cor)-2].gameObject);
            _corridors.Remove(_corridors[_corridors.IndexOf(cor)-2]);
        }
    }
}
