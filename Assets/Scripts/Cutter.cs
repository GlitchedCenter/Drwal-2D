using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cutter : MonoBehaviour
{
   //[Czy skrypt "Tree" nie powinien być ScriptableObjects
   [SerializeField] private int cuttingPower;
   private void Start()
   {
      Debug.Log("Cutter Start");
   }

   private void Update()
   {
      if (Mouse.current.leftButton.wasPressedThisFrame)
      {
         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
         RaycastHit2D hitResult = Physics2D.Raycast(mousePosition, Vector2.zero);
         if (!hitResult.collider)
            return;
         if (hitResult.collider.CompareTag("Cuttable"))
         {
            hitResult.collider.gameObject.GetComponent<Tree>().TakeDamage(cuttingPower); //TODO: tutaj będzie player.cutDmg
            
            Debug.Log("CHOP!");
         }
      }
         
   }
   
   private void OnMouseEnter()
   {
      Debug.Log("Mouse Enter");
   }

}
