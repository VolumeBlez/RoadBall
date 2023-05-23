using System;
using System.Collections.Generic;
using UnityEngine;

public class CorridorGenerator : MonoBehaviour
{
    [SerializeField] private List<Corridor> _corridorPrefabs; 
    private List<Corridor> _corridors;

    public Action<Corridor> CurrentCorridorChanged;

    public void Init() 
    {
        _corridors = new();
        SpawnCorridor();
    }

    private void SpawnCorridor()
    {
        Corridor corVar;
        
        if(_corridors.Count != 0)
        {
            List<Corridor> _corridorsWithNededDirectionType = new();
            Vector3 posForNewCorridor = _corridors[_corridors.Count-1].End.position;
            DirectionType dirType = _corridors[_corridors.Count-1].EndDirection;

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
