using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CourageBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
   
   public void SetMaxCourage (int courage) 
   {
       slider.maxValue = courage;
       slider.value = courage;

       fill.color = gradient.Evaluate(1f);
   }
   public void SetCourage(int courage) 
   {
       slider.value = courage;

       fill.color = gradient.Evaluate(slider.normalizedValue);
   }
}
