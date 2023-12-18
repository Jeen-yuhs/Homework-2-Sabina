using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    protected virtual void KillPlayer(IPlayer player)    
    {
       player.MakeDamage();
    }

    public virtual void PlayAnimation(string name) // проигрывает анимацию for all traps 
    {
        if (_animator)
        {
            _animator.Play(name, 0, 0);
        }
        else 
        {
            Debug.LogError($"{this} Animator is null"); // проверяет назначен ли аниматор в скрипте инспектора
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        if (collision.gameObject.GetComponent<IPlayer>() is IPlayer player) 
        {
            KillPlayer(player);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IPlayer>() is IPlayer player)
        {
            KillPlayer(player);
        }
    }
}
 