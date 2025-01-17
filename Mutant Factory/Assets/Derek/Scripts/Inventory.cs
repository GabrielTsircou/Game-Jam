using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Settings")]

    [SerializeField] private int _inventorySize;
    [SerializeField] private bool _openByDefault;
    [SerializeField] private KeyCode _toggleInventoryButton;
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private Sprite _defaultEmptySlot;

    [Header("Pick Up/Drop Settings")]

    [SerializeField] private LayerMask _itemLayer;
    [SerializeField] private KeyCode _pickupButton;
    [SerializeField] private KeyCode _dropButton;
    [SerializeField] private float _pickupRadius;
    [SerializeField] private bool _autoSwitchSlotOnGrab;
    [SerializeField] private int goalCount;

    [Header("Use Settings")]

    [SerializeField] private KeyCode _useButton;

    private LayoutGroup _slotParent;
    private TMPro.TMP_Text _pickupPrompt;

    private GameObject _player;
    
    private Item[] _inventory;
    private Image[] _slots;

    private int itemCount;

    private int _currentlySelected;
    public Item CurrentItem => GetItemFromSlot(_currentlySelected);

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _inventory = new Item[_inventorySize];
        _slots = new Image[_inventorySize];

        _slotParent = transform.GetComponentInChildren<LayoutGroup>();
        _pickupPrompt = transform.GetComponentInChildren<TMPro.TMP_Text>();

        for (int i = 0; i < _inventorySize; ++i)
        {
            GameObject newSlot = Instantiate(_slotPrefab);
            newSlot.transform.SetParent(_slotParent.transform);
            newSlot.name = $"Slot {i + 1}";

            _slots[i] = newSlot.GetComponent<Image>();

            if (i > 0)
                _slots[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        _slotParent.transform.parent.gameObject.SetActive(_openByDefault);
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
        _pickupPrompt.gameObject.SetActive(hit && (!CurrentItem || hit.collider.gameObject != CurrentItem.gameObject));

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
        if (itemCount >= goalCount)
        {
            SceneManager.LoadScene("congrats");
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

        itemCount++;

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

        itemCount--;

        item.OnDrop(_player);
    }

    public Item PopItemFromFirstAvailableSlot()
    {
        for (int i = 0; i < _inventory.Length; ++i)
        {
            if (_inventory[i] != null)
                return PopItemFromSlot(i);
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
                return GetItemFromSlot(i);
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
