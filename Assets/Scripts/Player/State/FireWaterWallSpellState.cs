using UnityEngine;

public class FireWaterWallSpellState : BasicSpellState
{
    public override void OnStateEnter()
    {
        _animator.SetTrigger("Attack2");
        base.OnStateEnter();
    }
    
    public void FireWaterWall()
    {
        _basicSpell.Fire();
    }
}
