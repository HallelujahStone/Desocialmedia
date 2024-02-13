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
        [SerializeField] private CustomText spentHour;
        [SerializeField] private CustomText spentMinute;

        private void Start()
        {
            int testMinutes = 111;
            
            
        }

        public void SetSpentTime(string screenTime)
        {
            spentMinute.Text = screenTime;
        }
        
    }
}