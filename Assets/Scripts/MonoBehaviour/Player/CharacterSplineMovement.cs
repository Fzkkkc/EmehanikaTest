using System.Collections;
using Dreamteck.Splines;
using UnityEngine;

namespace Player
{
    public class CharacterSplineMovement : MonoBehaviour
    {
        [SerializeField] private SplineComputer _spline;
        
        private bool _hasSpline;
        public SplineSample Sample = default;
        private float _splinePathPercent, _splineSideOffset;
        public float _splineSpeedScale = 1f;

        public float Percent => _splinePathPercent;
        
        [SerializeField] private float _speed = 1f; 

        private float _totalBoostDuration = 0f; 
        private bool speedBoosted = false;
        private float _boostDuration = 0.5f;

        public void SetSpline(SplineComputer spline)
        {
            this._spline = spline;
            _hasSpline = this._spline != null;
            if (_hasSpline)
            {
                Sample = new SplineSample();
                
                _splinePathPercent = (float) Sample.percent;
                _splineSpeedScale = 1f / spline.CalculateLength();

                transform.position = Sample.position + Sample.right;
            }
        }
        
        private void FixedUpdate()
        {
            if (_hasSpline)
            {
                ProcessMovement();
            }
        }

        private void ProcessMovement()
        {
            _splinePathPercent += _speed * Time.fixedDeltaTime;
                
            if (_splinePathPercent >= 1f)
                _splinePathPercent = 0f;
                
            Vector3 newPosition = _spline.EvaluatePosition(_splinePathPercent);
            transform.position = newPosition;
        }
        
        public void BoostSpeedForDuration()
        {
            if (!speedBoosted) 
            {
                StartCoroutine(SpeedBoostCoroutine());
                speedBoosted = true;
            }
        }
        
        private IEnumerator SpeedBoostCoroutine()
        {
            float originalSpeed = _speed;
            _speed *= 1.5f; 

            yield return new WaitForSeconds(_boostDuration);

            _speed = originalSpeed;
            speedBoosted = false; 
        }
    }
}