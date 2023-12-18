using UnityEngine;

public class Bomb : Trap
{

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _explosionForce;

    protected override void KillPlayer(IPlayer player)
    {
        MakeExplosion();

        base.KillPlayer(player);
    }

    public void MakeExplosion() 
    
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2);



        foreach (Collider2D collider in colliders)
        { 
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

            if (rb)
            {

                Vector2 direction = rb.position - (Vector2)transform.position; //направление взрыва в обратную сторону = все что рядом обьекты в радиусе 2м - позиция бомбы

                float distance = direction.magnitude; // возвращает длину нашего вектора
                float force = 1 - (distance / _explosionForce); //придание динамической силы
                rb.AddForce(direction.normalized * _explosionForce * force);
            }
        }

    }
    
   
}
