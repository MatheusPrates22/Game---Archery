using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private float speed = 2;
    [SerializeField] private SpriteRenderer lifeSpriteRenderer; 

    private List<Transform> pathTransform;

    [SerializeField] private int life;
    private int indexPath = 0;

    public int WaveIndex {get; set; }
    
    private void Awake() {
        life = maxLife;
        pathTransform = new List<Transform>();
    }

    private void Update() {
        Move();
    }

    public void TakeDamage(int damage) {
        life -= damage;
        Vector2 lifeVector = new Vector2((float)life/(float)maxLife, lifeSpriteRenderer.size.y);
        lifeSpriteRenderer.size = lifeVector;
        CheckForDeath();
    }
    public void SetPath(List<Transform> path) {
        this.pathTransform = path;
    }
    private void CheckForDeath() {
        if (life <= 0) {
            Destroy(gameObject);
        }
    }
    private void Move(){
        if (pathTransform.Count <= 0) return; 
        Vector3 destination = pathTransform[indexPath].transform.position;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPosition;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05f) {
            if (indexPath < pathTransform.Count - 1) {
                indexPath++;
            } else {
                //menos vida
                Destroy(gameObject);
            }
        }
    }

}
