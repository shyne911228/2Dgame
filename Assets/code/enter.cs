
using UnityEngine;

public class enter : MonoBehaviour
{
   public GameObject enterdialog;
   private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.tag=="Player")
       {
           enterdialog.SetActive(true);
       }  
   }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag=="Player")
       {
           enterdialog.SetActive(false);
       } 
    }
   
}
