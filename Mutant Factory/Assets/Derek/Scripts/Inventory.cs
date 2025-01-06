using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _inventorySize;
    [SerializeField] private KeyCode _toggleInventoryButton;

    [SerializeField] private LayerMask _itemLayer;
    [SerializeField] private KeyCode _pickupButton;
    [SerializeField] private KeyCode _dropButton;
    [SerializeField] private float _pickupRadius;

    [SerializeField] private KeyCode _useButton;

    [SerializeField] private Transform _slotParent;
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private Sprite _defaultEmptySlot;

    [SerializeField] private GameObject _pickupPrompt;
    [SerializeField] private bool _autoSwitchSlotOnGrab;

    private GameObject _player;
    
    private Item[] _inventory;
    private Image[] _slots;

    private int _currentlySelected;
    public Item CurrentItem => GetItemFromSlot(_currentlySelected);

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _inventory = new Item[_inventorySize];
        _slots = new Image[_inventorySize];

        for (int i = 0; i < _inventorySize; ++i)
        {
            GameObject newSlot = Instantiate(_slotPrefab);
            newSlot.transform.SetParent(_slotParent);
            newSlot.name = $"Slot {i + 1}";

            _slots[i] = newSlot.GetComponent<Image>();

            if (i > 0)
                _slots[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        for (int i = 0; i < _inventorySize; ++i)
        {
            if (Input.GetKeyDown((KeyCode.Alpha1 + i)))
            {
                if (CurrentItem)
                    CurrentItem.OnUnequip(_player);

                _slots[_currentlySelected].transform.GetChild(0).gameObject.SetActive(false);
                _currentlySelected = i;
                _slots[_currentlySelected].transform.GetChild(0).gameObject.SetActive(true);

                if (CurrentItem)
                    CurrentItem.OnEquip(_player);
            }
        }

        var hit = Physics2D.CircleCast(_player.transform.position, _pickupRadius, Vector2.zero, 0, _itemLayer);
        _pickupPrompt.SetActive(hit);

        if (Input.GetKeyDown(_toggleInventoryButton))
        {
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
        }
        else if (hit && hit.transform.gameObject.TryGetComponent(out Item item))
        {
            if (Input.GetKeyDown(_pickupButton))
            {
                AddItemToSlot(item, _currentlySelected);
            }
        }
        else if (CurrentItem)
        {
            if (Input.GetKeyDown(_useButton))
            {
                CurrentItem.OnUse(_player);
            }
            else if (Input.GetKeyDown(_dropButton))
            {
                RemoveItemFromSlot(_currentlySelected);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (_player)
            Gizmos.DrawWireSphere(_player.transform.position, _pickupRadius);
    }

    public void AddItemToFirstAvailableSlot(Item item)
    {
        for (int i = 0; i < _inventory.Length; ++i)
        {
            if (_inventory[i] == null)
            {
                AddItemToSlot(item, i);
                break;
            }
        }
    }

    public void AddItemToSlot(Item item, int slotNumber)
    {
        if (slotNumber < 0 || slotNumber >= _inventory.Length)
            return;

        _inventory[slotNumber] = item;
        _slots[slotNumber].sprite = item.GetComponent<SpriteRenderer>().sprite;
        _slots[slotNumber].color = Color.white;

        item.OnPickup(_player);

        if (_autoSwitchSlotOnGrab)
            _currentlySelected = slotNumber;
    }

    public void RemoveItemFromFirstAvailableSlot()
    {
        for (int i = 0; i < _inventory.Length; ++i)
        {
            if (_inventory[i] != null)
            {
                RemoveItemFromSlot(i);
            }
        }
    }

    public void RemoveItemFromSlot(int slotNumber)
    {
        if (slotNumber < 0 || slotNumber >= _inventory.Length)
            return;

        Item item = _inventory[slotNumber];
        _inventory[slotNumber] = null;
        _slots[slotNumber].sprite = _defaultEmptySlot;
        _slots[slotNumber].color = Color.black;

        item.OnDrop(_player);
    }

    public Item PopItemFromFirstAvailableSlot()
    {
        for (int i = 0; i < _inventory.Length; ++i)
        {
            if (_inventory[i] != null)
            {
                return PopItemFromSlot(i);
            }
        }

        return null;
    }

    public Item PopItemFromSlot(int slotNumber)
    {
        if (slotNumber < 0 || slotNumber >= _inventory.Length)
            return null;

        Item item = _inventory[slotNumber];
        _inventory[slotNumber] = null;

        item.OnDrop(_player);

        return item;
    }

    public Item GetFirstAvailableItem()
    {
        for (int i = 0; i < _inventory.Length; ++i)
        {
            if (_inventory[i] != null)
            {
                return GetItemFromSlot(i);
            }
        }

        return null;
    }

    public Item GetItemFromSlot(int slotNumber)
    {
        if (slotNumber < 0 || slotNumber >= _inventory.Length)
            return null;

        return _inventory[slotNumber];
    }
}
