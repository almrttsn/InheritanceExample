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
    [SerializeField] private List<Transform> _objectSlots;


    [SerializeField] private CollectObject _spherePrefab;
    [SerializeField] private CollectObject _capsulePrefab;

    [SerializeField] private JoystickBehaviour _joystickBehaviour;

    private List<CollectObject> _listOfObjectTypes;

    private float _joystickXInput;
    private float _joystickZInput;

    private GameObject _collectedCapsules;
    private GameObject _collectedSpheres;

    private Vector3 _firstPossibleSpot;
    private int _counter;

    //public AreaType AreaType;
    //public ObjectType ObjectType;

    private void Start()
    {
        _listOfObjectTypes = new List<CollectObject>();
    }

    private void Update()
    {
        _joystickXInput = _joystickBehaviour.GetHorizontalInput();
        _joystickZInput = _joystickBehaviour.GetVerticalInput();
        transform.position += new Vector3(_joystickXInput, 0, _joystickZInput) * 0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SphereCollectArea")
        {
            Debug.Log("You logged in Sphere Collect Area");
            var sphere = Instantiate(_spherePrefab);
            _listOfObjectTypes.Add(sphere);
            FillSlot(sphere);
        }
        else if (other.tag == "CapsuleCollectArea")
        {
            Debug.Log("You logged in Capsule Collect Area");
            var capsule = Instantiate(_capsulePrefab);
            _listOfObjectTypes.Add(capsule);
            FillSlot(capsule);
        }
        else if (other.tag == "MarketArea")
        {
            Debug.Log("You logged in Market Area");
            if (other.gameObject.GetComponent<MarketArea>().DesiredObjectType == ObjectType.Sphere)
            {
                foreach (var item in _listOfObjectTypes)
                {
                    if(item.TypeOfObjects == ObjectType.Sphere)
                    {
                        _listOfObjectTypes.Remove(item);
                        Destroy(item.gameObject);
                        _counter--;
                    }                    
                }
            }
            else
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