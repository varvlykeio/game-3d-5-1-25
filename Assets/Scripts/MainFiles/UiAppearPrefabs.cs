using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
//using TMPro;

//εμφανιση του i στον ΑΤΜ 
//το ιδιο αρχειο και για πορτες
public class UiAppearPrefab : MonoBehaviour
    {
        //[SerializeField] private TMP_Text customText;
        [SerializeField] private GameObject customText;   
        [SerializeField] private new string name;  
        private bool s;
        public void Start(){
            StartCoroutine(DelayedAwake());

            IEnumerator DelayedAwake()
            {
                yield return new WaitForSeconds(2f);
                customText = GameObject.FindGameObjectWithTag(name).transform.GetChild(0).gameObject;
                customText.SetActive(false);
            }
        }
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                customText.SetActive(true);
            }  
        }

        public void Update(){
            
            if(Input.GetKeyDown("i")){
                customText.SetActive(false);
                
            }
                


        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                customText.SetActive(false);
            }
        }
    }
