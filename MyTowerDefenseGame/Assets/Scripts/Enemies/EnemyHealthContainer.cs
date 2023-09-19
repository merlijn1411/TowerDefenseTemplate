using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthContainer : MonoBehaviour
{
    //dit script kom op de healthCanvas en de image moet geassigned worden op de Healthbar 
    [SerializeField] private Image fillAmountImage;
    public Image FillAmountImage => fillAmountImage;
}
