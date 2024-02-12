using UnityEngine;

namespace Desocialmedia
{
    public enum SpentTimeType
    {
        Yours,
        Others,
        Advantage
    }
    
    public class SpentTimeController : MonoBehaviour
    {
        [SerializeField] private SpentTimeType spentTimeType;
        
        
    }
}