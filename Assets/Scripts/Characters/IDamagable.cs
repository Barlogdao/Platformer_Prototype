public interface IDamagable
{
    void TakeDamage(int damage);

    bool IsAlive {  get; }
}