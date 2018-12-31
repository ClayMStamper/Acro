using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance { get; private set; }

    private void Awake(){
        if (instance != null) {
            Destroy (this);
        } else {
            instance = this;
        }
			
    }

    #endregion
    
    public List <Item> items = new List <Item>(24);

    public int space = 24;

    public delegate void OnItemChanged ();
    public OnItemChanged onItemChangedCallback;

    private void Start(){

        for (int i = 0; i < space; i++) {
            items.Add (null);
        }
    }

    public bool Add (Item item){

        for (int i = 0; i < space; i++) {
            if (items [i] == null) {
                items [i] = item;
                break;
            } else if (i >= space){
                print ("INVENTORY FULL");
                return false;
            }
        }

        onItemChangedCallback?.Invoke ();

        return true;
    }

    //probably causing glitches: change to take in inventory slot instead of item
    public void Remove (Item item){
        for (int i = 0; i < space; i++) {
            if (items [i] == item) {
                items [i] = null;
                break;
            }

            onItemChangedCallback?.Invoke ();
        }
    }
}