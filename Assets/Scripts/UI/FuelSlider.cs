using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FuelSlider : MonoBehaviour
{
    private Image sliderImage;

    [SerializeField] private FuelController fuelController;

    private float maxFuel
    {
        get {
            return FuelController.FUEL_MAX;
        }
    }

    private float fillAmount;

    private enum UIStatus { good, medium, bad };
    private UIStatus status;

    private Color goodStatusColor
    {
        get
        {
            return new Color(83, 115, 16);
        }
    }
    private Color mediumStatusColor {
        get {
            return new Color(242, 164, 68);
        }
    }
    private Color badStatusColor
    {
        get
        {
            return new Color(217, 79, 48);
        }
    }

    [SerializeField] float colorTransitionTime;

    private void Awake()
    {
        if (fuelController == null)
        {
            print("ERROR: Fuel Controller null. Exiting");
            return;
        }

        sliderImage = GetComponent<Image>();
    }

    void Update()
    {
        print(sliderImage.material.color);
        SetFillAmount();
        SetFuelStatus();
        UpdateSliderUI();

        // sliderMat = sliderImage.material;
        switch (status)
        {
            case UIStatus.good:
                //sliderMaterial.DOColor(goodStatusColor, colorTransitionTime);
                sliderImage.material.color = goodStatusColor;
                break;
            case UIStatus.medium:
                //sliderMaterial.DOColor(mediumStatusColor, colorTransitionTime);
                sliderImage.material.color = mediumStatusColor;
                break;
            case UIStatus.bad:
                //sliderMaterial.DOColor(badStatusColor, colorTransitionTime);
                sliderImage.material.color = badStatusColor;
                break;
        }
    }

    // Sets local status property for color update
    private void SetFuelStatus()
    {
        // TODO: I prefer not to constantly update this. Maybe a computed property would solve?
        float currentFuel = fuelController.GetFuel();

        if (currentFuel > maxFuel * 2/3) { status = UIStatus.good; }
        else if ( (currentFuel > maxFuel * 1/3) && (currentFuel < maxFuel * 2/3) ) { status = UIStatus.medium; }
        else { status = UIStatus.bad; }
    }

    // Sets local property value, not UI value
    private void SetFillAmount()
    {
        float currentFuel = fuelController.GetFuel();
        fillAmount = currentFuel / maxFuel;
    }

    // Sets UI fillAmount value
    private void UpdateSliderUI()
    {
        sliderImage.fillAmount = fillAmount;
    }
}
