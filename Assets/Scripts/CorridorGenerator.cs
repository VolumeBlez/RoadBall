using System;
using System.Collections.Generic;
using UnityEngine;

public class CorridorGenerator : MonoBehaviour
{
    [SerializeField] private List<Corridor> _corridorPrefabs; 
    private List<Corridor> corridors;

    public Action<Corridor> CurrentCorridorChanged;

    public void Init() 
    {
        corridors = new();
        SpawnCorridor();
    }

    private void SpawnCorridor()
    {
        Corridor corVar;
        
        if(corridors.Count != 0)
        {
            List<Corridor> corridorsWithNededDirectionType = new();
            Vector3 posForNewCorridor = corridors[corridors.Count-1].End.position;
            DirectionType dirType = corridors[corridors.Count-1].EndDirection;

            foreach (var cor in _corridorPrefabs)
            {
                if(cor.BeginDirection == dirType)
                    corridorsWithNededDirectionType.Add(cor);
            }
            
            corVar = Instantiate(corridorsWithNededDirectionType[UnityEngine.Random.Range(0, corridorsWithNededDirectionType.Count)],Vector3.zero, Quaternion.identity);
            corVar.transform.position = posForNewCorridor - corVar.Begin.position;
        }
        else 
        {
            corVar = Instantiate(_corridorPrefabs[0], Vector3.zero, Quaternion.identity);
            CurrentCorridorChanged?.Invoke(corVar);
        }
        corVar.PlayerCheckTheTurn += DestroyCorridor;
        corridors.Add(corVar);
    }

    private void DestroyCorridor(Corridor cor) 
    {
        SpawnCorridor();
        CurrentCorridorChanged?.Invoke(corridors[corridors.IndexOf(cor)+1]);

        if(corridors.Count > 3)
        {   
            Destroy(corridors[corridors.IndexOf(cor)-2].gameObject);
            corridors.Remove(corridors[corridors.IndexOf(cor)-2]);
        }
    }
}
