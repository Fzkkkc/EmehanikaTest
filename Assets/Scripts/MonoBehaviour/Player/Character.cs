using UnityEngine;

namespace Player
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterSplineMovement movement;
        [SerializeField] private CharacterCollision collision;
        
        public CharacterSplineMovement Movement => movement;
        public CharacterCollision Collision => collision;
    }
}