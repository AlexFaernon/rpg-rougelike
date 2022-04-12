using UnityEngine.Events;
public class ModifyReceivedDamage
{
    public int Damage { get; set; }
    public IUnit Source;
    public readonly UnityEvent Event = new UnityEvent();
}

public abstract class Character : ICharacter
{
    private int _hp = 10;
    private int _mp = 10;

    public virtual int HP
    {
        get => _hp;
        private set
        {
            _hp = value;
            EventAggregator.UpdateHP.Publish(this);
        }
    }
    
    public virtual int MP
    {
        get => _mp;
        private set => _mp = value;
    }
    
    public bool CanMove { get; set; }
    public ModifyReceivedDamage ModifyReceivedDamage { get; set; } = new ModifyReceivedDamage();
    public virtual void TakeDamage(int damage, IUnit source)
    {
        ModifyReceivedDamage.Source = source;
        ModifyReceivedDamage.Damage = damage;
        ModifyReceivedDamage.Event.Invoke();
        HP -= ModifyReceivedDamage.Damage;
    }

    public virtual void Heal(int heal)
    {
        HP += heal;
    }
    
    public IAbility[] Abilities
    {
        get
        {
            return new[] { BasicAbility, FirstAbility, SecondAbility, Ultimate };
        }
    }
    public virtual IAbility BasicAbility { get; set; }
    public virtual IAbility FirstAbility { get; set; }
    public virtual IAbility SecondAbility { get; set; }
    public virtual IAbility Ultimate { get; set; }
}