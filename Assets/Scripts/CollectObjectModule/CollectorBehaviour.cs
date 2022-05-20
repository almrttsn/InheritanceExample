using MangoramaStudio.Scripts.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum AreaType
//{
//    Collect,Market
//}

public enum ObjectType //Bu enum'ı hem obje prefablarına CollectObject'ten hem de marketlere MarketArea'dan seçtirdik
{
    Sphere, Capsule
}

public class CollectorBehaviour : MonoBehaviour
{
    [SerializeField] private List<Transform> _objectSlots;  //Objelerin tutulmasını istediğimiz slot listesi


    [SerializeField] private CollectObject _spherePrefab;   //Spfere prefabı
    [SerializeField] private CollectObject _capsulePrefab;  //Capsule prefabı

    [SerializeField] private JoystickBehaviour _joystickBehaviour;  //Joystick behaviour özellikli
                                                                    //joystick'i buraya attık
    [SerializeField] private float _joystickSensivity;

    private List<CollectObject> _listOfObjectTypes; //Obje tiplerini ayırma listesi

    private float _joystickXInput;  //Player üstündeki X hareketi
    private float _joystickZInput;  //Player üstündeki Z hareketi

    private int _counter;   //Tutulan dolu slot sayısı, slot sayar

    private void Start()
    {
        _listOfObjectTypes = new List<CollectObject>(); //Listeye element kaydı için gerekli işlem
    }

    private void Update()
    {
        _joystickXInput = _joystickBehaviour.GetHorizontalInput();  //Joystickten gelen Horizontal değer
        _joystickZInput = _joystickBehaviour.GetVerticalInput();    //Joystickten gelen Vertical değer
        transform.position += new Vector3(_joystickXInput, 0, _joystickZInput) * _joystickSensivity;
        //Player'ın hareketini joystickten gelen verilere bağladık
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SphereCollectArea" && _counter < _objectSlots.Count)  //Boş slot var ise
        {
            var sphere = Instantiate(_spherePrefab);            //Yarat
            _listOfObjectTypes.Add(sphere);                     //Listeye ekle
            FillSlot(sphere);                                   //Slot transformuna yerleştir
        }
        else if (other.tag == "CapsuleCollectArea" && _counter < _objectSlots.Count)    //Boş slot var ise
        {
            var capsule = Instantiate(_capsulePrefab);          //Yarat
            _listOfObjectTypes.Add(capsule);                    //Listeye ekle
            FillSlot(capsule);                                  //Slot transformuna yerleştir
        }
        else if (other.tag == "MarketArea")
        {       //Market area scriptine sahip objelerde ayırdığımız iki obje türünden == Sphere ise
            if (other.gameObject.GetComponent<MarketArea>().DesiredObjectType == ObjectType.Sphere) //ObjectType.Sphere
            {
                foreach (var item in _listOfObjectTypes)        //Yaratıp içine obje attığımız listedeki,
                {
                    if(item.TypeOfObjects == ObjectType.Sphere) //Collect içinden Sphere ise,
                    {
                        _listOfObjectTypes.Remove(item);        //Bu itemi listeden sil,
                        Destroy(item.gameObject);               //Bu itemi yok et,
                        _counter--;                             //Ve slot sayar'ı 1 azalt

                    }
                }
            }
            else     //ObjectType.Capsule
            {
                foreach (var item in _listOfObjectTypes)        //Yaratıp içine obje attığımız listedeki,
                {
                    if (item.TypeOfObjects == ObjectType.Capsule)//Collect içinden Capsule ise,
                    {
                        _listOfObjectTypes.Remove(item);        //Bu itemi listeden sil,
                        Destroy(item.gameObject);               //Bu itemi yok et,
                        _counter--;                             //Ve slot sayar'ı 1 azalt
                    }
                }
            }
        }
    }
    private void FillSlot(CollectObject collectObject)  //İçine CollectObject özellikli obje aldı
    {
        collectObject.transform.position = _objectSlots[_counter].transform.position;   //ilk slota gönder(ilk slotun anlık posizyonu)
        collectObject.transform.parent = _objectSlots[_counter].transform;  //Slota child olarak ekle(ki beraber hareket etsin)
        _counter++; //Ve slot sayar'ı 1 arttır
    }

}