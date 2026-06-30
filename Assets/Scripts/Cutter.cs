using UnityEngine;
using UnityEngine.InputSystem;

public class Cutter : MonoBehaviour
{
   private void Start()
   {
      Debug.Log("Cutter Start");
   }

   private void Update()
   {
      if(GameManager.Instance.IsShopOpen) return;
      
      if (Mouse.current.leftButton.wasPressedThisFrame)
      {
         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
         RaycastHit2D hitResult = Physics2D.Raycast(mousePosition, Vector2.zero); //TODO: moze jeszcze dodać trafienia w kamień?
         if (!hitResult.collider)
            return;
         if (hitResult.collider.CompareTag("Cuttable"))
         {
            hitResult.collider.gameObject.GetComponent<Tree>().TakeDamage(GameManager.Instance.CurrentAxePower); //TODO: tutaj będzie player.cutDmg
            
            Debug.Log("CHOP!");
         }
      }
         
   }
   
   private void OnMouseEnter()
   {
      Debug.Log("Mouse Enter");
   }

}
