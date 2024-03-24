using UnityEngine;

namespace UserInterface
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIInput input;
        
        public UIInput Input => input;
    }
}