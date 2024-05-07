
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelCars : MonoBehaviour {
    [Header("Sunny Sedan or Car jeeep")]
    [SerializeField] private GameObject _carJeeep;
    [SerializeField] private GameObject _carJeepButton;
    [SerializeField] private GameObject _jeepDisablerParent;
    [SerializeField] private GameObject _jeepInScene;
    [SerializeField] private Transform _jeepPathForSalesAgent;
    [SerializeField] private Image _jeepImage;
    [SerializeField] private GameObject _jeepGameObject;
    
    
    
    [Header("Black Panter car")]
    [SerializeField] private GameObject _blackPanter;
    [SerializeField] private GameObject _blackPanterButon;
    [SerializeField] private GameObject _blackDisablerParent;
    [SerializeField] private Transform _blackPanterPath;
    [SerializeField] private GameObject _blackPanterInScene;
    [SerializeField] private Transform _blackPanterPathForSalesAgent;
    [SerializeField] private Image _blackPantermage;
    [SerializeField] private GameObject _blackPanterImageGameObject;
    [SerializeField] private ParticleSystem _blackPanterParticle;

    private int _carblackPanterPrice;

    [Header("Gary Ghost car")]
    [SerializeField] private GameObject _grayGhost;
    [SerializeField] private GameObject _grayGhostButton;
    [SerializeField] private GameObject _grayGhostDisablerParent;
    [SerializeField] private Transform _grayGhostPath;
    [SerializeField] private GameObject _grayGhostInScene;
    [SerializeField] private Transform _grayGrostPathForSalesAgent;
    [SerializeField] private Image _grayGrostImage;
    [SerializeField] private GameObject _grayghostImageGameObject;
    [SerializeField] private ParticleSystem _grayGhostParticle;
    private int _carGaryGhostPrice;

    [Header("Royal azure car")]
    [SerializeField] private GameObject _royalAzure;
    [SerializeField] private GameObject _royalAzureButton;
    [SerializeField] private GameObject _royalAzureDisablerParent;
    [SerializeField] private Transform _royalAzurePath;
    [SerializeField] private GameObject _royalAzureInScene;
    [SerializeField] private Transform _royalAzurePathForSalesAgent;
    [SerializeField] private Image _royalAzureImage;
    [SerializeField] private GameObject _royalAzureImageGameobject;
    [SerializeField] private ParticleSystem _royalAzureParticle;
    private int _carPoyalAzurePrice;

    [Header("Orange fure")]
    [SerializeField] private GameObject _orangeFure;
    [SerializeField] private GameObject _orangeFureButton;
    [SerializeField] private GameObject _orangeFureDisablerParent;
    [SerializeField] private GameObject _orangeFureInScene;
    [SerializeField] private Transform _orangeFurePath;
    [SerializeField] private Transform _orangeFurPathForSalesAgent;
    [SerializeField] private Image _orangeFurImage;
    [SerializeField] private GameObject _orangeFureImageGameObject;
    [SerializeField] private ParticleSystem _orangeFureParticle;
    private int _carOrangeFurePrice;


    [Header("OrangeFure black Jeep")]
    [SerializeField] private GameObject _orangeFureBlack;
    [SerializeField] private GameObject _orangeFureBlackButton;
    [SerializeField] private GameObject _orangeFureBlackDisablerParent;
    [SerializeField] private Transform _orangeFureBlackPath;
    [SerializeField] private GameObject _orangeFureBlackInScene;
    [SerializeField] private Transform _orangeFureBlackPathForSalesAgent;
    [SerializeField] private Image _orangeFureBlackImage;    
    [SerializeField] private GameObject _orangeFureBlackImageGameObject;
    [SerializeField] private ParticleSystem _orangeFureBlackParicle;
    private int _carOrangeFureBlackPrice;
    [Header("Locks")]
    [SerializeField] private GameObject _secondBlackPanterLock;
    [SerializeField] private GameObject _thirdGrayGhostLock;
    [SerializeField] private GameObject _fourthRoyalAzureLock;
    [SerializeField] private GameObject _fivethOrangeFureLock;
    [SerializeField] private GameObject _sixOrangeFureBlackLock;
    [Header("ClassController")]
    [SerializeField] private UiCanvas _canvasClass;
    [SerializeField] private Transporter _transporter;
    [SerializeField] private CarsParentPoint _carsParentPoint;
    [SerializeField] private SalesAgentCellCar _salesAgentCellCar;
    

    public void JeepOrSunnySedan() {
        _carJeeep.SetActive(true);
        _carJeepButton.SetActive(false);
        _jeepDisablerParent.SetActive(false);
    }

    public void BlackPanter() {
        _secondBlackPanterLock.SetActive(false);
        _thirdGrayGhostLock.SetActive(true);
        _blackPanter.SetActive(true);
        _blackPanterButon.SetActive(false);
        _carblackPanterPrice = 7500;
        _transporter.AddNewCarObject(_blackPanterInScene);
        _carsParentPoint.AddCarPath(_blackPanterPath);
        _blackDisablerParent.SetActive(false);
        _canvasClass.DecrementScore(_carblackPanterPrice);
        _salesAgentCellCar.AddCarPath( _blackPanterPathForSalesAgent);
        _salesAgentCellCar.AddImage(_blackPantermage, _blackPanterImageGameObject);
        _blackPanterParticle.Play();
    }

    public void GrayGhost() {
        _thirdGrayGhostLock.SetActive(false);
        _fourthRoyalAzureLock.SetActive(true);
        _grayGhost.SetActive(true);
        _grayGhostButton.SetActive(false);
        _carGaryGhostPrice = 9000;
        _transporter.AddNewCarObject(_grayGhostInScene);
        _carsParentPoint.AddCarPath(_grayGhostPath);
        _grayGhostDisablerParent.SetActive(false);
        _canvasClass.DecrementScore(_carGaryGhostPrice);
        _salesAgentCellCar.AddCarPath( _grayGrostPathForSalesAgent);
        _salesAgentCellCar.AddImage( _grayGrostImage, _grayghostImageGameObject);
        _grayGhostParticle.Play();
    }
    public void RoyalAzure() {
        _fourthRoyalAzureLock.SetActive(false);
        _fivethOrangeFureLock.SetActive(true);
        _royalAzure.SetActive(true);
        _royalAzureButton.SetActive(false);
        _carPoyalAzurePrice = 12000;
        _carsParentPoint.AddCarPath(_royalAzurePath);
        _transporter.AddNewCarObject(_royalAzureInScene);
        _royalAzureDisablerParent.SetActive(false);
        _canvasClass.DecrementScore(_carPoyalAzurePrice);
        _salesAgentCellCar.AddCarPath( _royalAzurePathForSalesAgent);
        _salesAgentCellCar.AddImage(_royalAzureImage, _royalAzureImageGameobject);
        _royalAzureParticle.Play();
    }

    public void OrangeFure() {
        _fivethOrangeFureLock.SetActive(false);
        _sixOrangeFureBlackLock.SetActive(true);
        _orangeFure.SetActive(true);
        _orangeFureButton.SetActive(false);
        _carOrangeFurePrice = 16000;
        _transporter.AddNewCarObject(_orangeFureInScene);
        _carsParentPoint.AddCarPath(_orangeFurePath);
        _orangeFureDisablerParent.SetActive(false);
        _canvasClass.DecrementScore(_carOrangeFurePrice);
        _salesAgentCellCar.AddCarPath( _orangeFurPathForSalesAgent);
        _salesAgentCellCar.AddImage( _orangeFurImage, _orangeFureImageGameObject);
        _orangeFureParticle.Play();
    }
    public void OrangeFureBlackJeep() {

        _sixOrangeFureBlackLock.SetActive(false);
        _orangeFureBlack.SetActive(true);
        _orangeFureBlackButton.SetActive(false);
        _carOrangeFureBlackPrice = 20000;
        _transporter.AddNewCarObject(_orangeFureBlackInScene);
        _carsParentPoint.AddCarPath(_orangeFureBlackPath);
        _orangeFureBlackDisablerParent.SetActive(false);
        _canvasClass.DecrementScore (_carOrangeFureBlackPrice);
        _salesAgentCellCar.AddCarPath(_orangeFureBlackPathForSalesAgent);
        _salesAgentCellCar.AddImage(_orangeFureBlackImage, _orangeFureBlackImageGameObject);
        _orangeFureBlackParicle.Play();
    }
}