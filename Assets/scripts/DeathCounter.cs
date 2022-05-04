using System.Linq;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    [SerializeField] private GameObject ShadingDefeat;
    [SerializeField] private GameObject ShadingWin;

    private void Awake()
    {
        EventAggregator.CharacterDied.Subscribe(CharacterDied);
        EventAggregator.EnemyDied.Subscribe(EnemyDied);
    }

    private void CharacterDied(ICharacter character)
    {
        if (!Units.Characters.Values.All(character1 => character1.IsDead)) return;
        
        ShadingDefeat.SetActive(true);
        Debug.Log("Game Over");
    }
    
    private void EnemyDied(IEnemy enemy)
    {
        Units.Enemies.Remove(enemy);
        if (Units.Enemies.Count == 0)
        {
            ShadingWin.SetActive(true);
            Debug.Log("Victory");
        }
    }

    private void OnDestroy()
    {
        EventAggregator.CharacterDied.Unsubscribe(CharacterDied);
        EventAggregator.EnemyDied.Unsubscribe(EnemyDied);
    }
}
