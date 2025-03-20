using UnityEngine;

namespace Objects
{
    public class Platform : MonoBehaviour
    {
        #region Getters and setters
        public BoxCollider2D CollisionBox { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }
        #endregion
        
        #region Private properties
        private bool _active = true;
        private float _timer;
        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            CollisionBox = GetComponent<BoxCollider2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void Update()
        {
            if (_active) return;
            _timer -= Time.deltaTime;
            if (_timer <= 0)
                Activate();
        }
        #endregion
        
        #region Private methods
        private void SetAlpha(float alpha)
        {
            SpriteRenderer.color = new Color(
                SpriteRenderer.color.r,
                SpriteRenderer.color.g,
                SpriteRenderer.color.b,
                alpha
            );
        }
        #endregion

        #region Public methods
        public void Activate() 
        {
            CollisionBox.enabled = _active = true;
            SetAlpha(1f);
        }
        
        public void Deactivate(float time)
        {
            _timer = time;
            CollisionBox.enabled = _active = false;
            SetAlpha(.5f);
        }
        #endregion
    }
}
