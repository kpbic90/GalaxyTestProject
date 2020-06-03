using UnityEngine;

namespace Gameplay.Helpers
{
    public class BackgroundParallax : MonoBehaviour
    {
        private float length, startpos;

        [SerializeField] private float speed;

        private void Start()
        {
            startpos = transform.position.y;
            length = GetComponent<SpriteRenderer>().bounds.size.y;
        }

        private void FixedUpdate()
        {
            if (GameController.Instance.IsGamePaused)
                return;

            var dist = Time.deltaTime * speed;

            var newPosition = transform.position.y - dist;

            if (transform.position.y + dist > startpos + length)
                newPosition -= length;
            else if (transform.position.y + dist < startpos - length)
                newPosition += length;

            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
            ;
        }
    }
}