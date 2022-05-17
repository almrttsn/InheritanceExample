using MangoramaStudio.Scripts.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum AreaType
//{
//    Collect,Market
//}

public enum ObjectType
{
    Sphere, Capsule
}

public class CollectorBehaviour : MonoBehaviour
{
    [SerializeField] private List<Transform> _objectSlots;  //Objelerin tutulmasını istediğimiz slot listesi


    [SerializeField] private CollectObject _spherePrefab;
    [SerializeField] private CollectObject _capsulePrefab;

    [SerializeField] private JoystickBehaviour _joystickBehaviour;  //Joystick behaviour özellikli
                                                                    //joystick'i buraya attık
    [SerializeField] private float _joystickSensivity;

    private List<CollectObject> _listOfObjectTypes; //Obje tiplerinı ayırma listesi

    private float _joystickXInput;  
    private float _joystickZInput;

    private int _counter;   //Tutulan dolu slot sayısı

    private void Start()
    {
        _listOfObjectTypes = new List<CollectObject>(); //Listeye element kaydı için gerekli
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
            var sphere = Instantiate(_spherePrefab);    //Yarat
            _listOfObjectTypes.Add(sphere);             //Listeye ekle
            FillSlot(sphere);                           //Slot transformuna yerleştir
        }
        else if (other.tag == "CapsuleCollectArea" && _counter < _objectSlots.Count)    //Boş slot var ise
        {
            var capsule = Instantiate(_capsulePrefab);  //Yarat
            _listOfObjectTypes.Add(capsule);            //Listeye ekle
            FillSlot(capsule);                          //Slot transformuna yerleştir
        }
        else if (other.tag == "MarketArea")
        {       //Market area scriptine sahip objelerde ayırdığımız iki obje türünden == Sphere ise
            if (other.gameObject.GetComponent<MarketArea>().DesiredObjectType == ObjectType.Sphere)
            {
                foreach (var item in _listOfObjectTypes) //Yaratıp içine obje attığımız listedeki,
                {
                    if(item.TypeOfObjects == ObjectType.Sphere) //Collect içinden Sphere ise,
                    {
                        _listOfObjectTypes.Remove(item);    //Bu itemi listeden sil,
                        Destroy(item.gameObject);   //Bu itemi yok et,
                        _counter--; //Ve 1 tane slotu uygun hale getir

                    }
                }
            }
            else     //ObjectType.Capsule
            {
                foreach (var item in _listOfObjectTypes)
                {
                    if (item.TypeOfObjects == ObjectType.Capsule)
                    {
                        _listOfObjectTypes.Remove(item);
                        Destroy(item.gameObject);
                        _counter--;
                    }
                }
            }
        }
    }
    private void FillSlot(CollectObject collectObject)
    {
        collectObject.transform.position = _objectSlots[_counter].transform.position;
        collectObject.transform.parent = _objectSlots[_counter].transform;
        _counter++;
    }

}