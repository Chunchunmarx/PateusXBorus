using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnMapNew : MonoBehaviour
{
    private TeleportableSection currentSection;
    public TeleportableSection startingSection;
    

    void Update()
    {
        
        if (currentSection == null) return;
       
       
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            currentSection.TeleportPlayer(transform, Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            currentSection.TeleportPlayer(transform, Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            currentSection.TeleportPlayer(transform, Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            currentSection.TeleportPlayer(transform, Vector3.right);
        }
        if (UnityEngine.Input.GetKey(KeyCode.Return))
        {
            EnterNewLevel();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("am intrat in trigger");
        TeleportableSection section = other.GetComponent<TeleportableSection>();
        if (section != null)
        {
            currentSection = section;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("am iesit  din trigger");
        TeleportableSection section = other.GetComponent<TeleportableSection>();
        if (section == currentSection)
        {
            currentSection = null;
        }
    }
    public void EnterNewLevel()
    {
        
            SceneManager.LoadScene(currentSection.enterLevel.name);
        

    }
}