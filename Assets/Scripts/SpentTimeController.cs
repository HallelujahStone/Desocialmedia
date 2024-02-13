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

        public void SetSpentTime(int spentTime)
        {
            int hours = spentTime / 3600;
            int minutes = (spentTime % 3600) / 60;
            spentHour.Text = hours.ToString();
            spentMinute.Text = minutes.ToString();
            spentHour.UpdateCustomText();
            spentMinute.UpdateCustomText();
        }
        
    }
}