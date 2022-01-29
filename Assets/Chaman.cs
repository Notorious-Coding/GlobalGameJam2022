using UnityEngine;

public class Chaman : StateMachine
{
    [SerializeField]
    ChamanDataSO _data;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if(Jappuie sur ma touche)
        //{
        //    this.SetState(GetState<AvancerState>())
        //}

        this.CurrentState.HandleLogic();
        TakeDamage(10);
    }

    private void FixedUpdate()
    {
        this.CurrentState.HandlePhysicsLogic();
    }

    public void TakeDamage(int damage) 
    {
        _data.UpdateLife(-damage);
    }
}
