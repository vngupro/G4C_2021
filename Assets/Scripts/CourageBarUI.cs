using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CourageBarUI : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
   
   public void SetMaxCourage (float courage) 
   {
       slider.maxValue = courage;
   }

   public void SetCourage(float courage) 
   {
       slider.value = courage;
       fill.color = gradient.Evaluate(slider.normalizedValue);
   }
}
