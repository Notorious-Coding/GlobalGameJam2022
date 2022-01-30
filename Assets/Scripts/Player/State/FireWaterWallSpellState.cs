using UnityEngine;

public class FireWaterWallSpellState : BasicSpellState
{

    [SerializeField] private ElementalBalanceSO _elementalBalanceSO;
    [SerializeField] private SpellSO _spellData;
    public override void OnStateEnter()
    {
        _elementalBalanceSO.OnSpellLaunch(_spellData);
        _animator.SetTrigger("Attack2");
        base.OnStateEnter();
    }
    
    public void FireWaterWall()
    {
        _basicSpell.Fire();
    }
}
