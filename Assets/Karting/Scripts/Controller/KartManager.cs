using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartManager : MonoBehaviour
{
	public static KartManager instance;

	[Header("Colors")] 
	public Color primaryControllerColor = Color.red;
	public Color secondaryControllerColor = Color.green;
	public Color noControllerColor = Color.blue;

	[Header("Debug")]
	public int primaryControllerIndex = -1;
	public int secondaryControllerIndex = -1;

	private List<KartController> karts;

    void Awake()
    {
	    instance = this;

	    karts = new List<KartController>();
    }

    void Update()
    {

	    ProcessInputs();
    }

    void ProcessInputs()
    {
	    if (Input.GetKeyDown(KeyCode.Tab))
	    {
            SwitchPrimaryController();
	    }

	    if (Input.GetKeyDown(KeyCode.Backspace)) 
	    {
		    SwitchSecondaryController();
	    }
	}

    void SwitchPrimaryController()
    {
	    int newIndex = primaryControllerIndex;

	    //Get first available index
		for (int i = 0; i < karts.Count; i++)
		{
			newIndex++;

			if (newIndex >= karts.Count)
			{
				newIndex = 0;
			}

			if (newIndex != secondaryControllerIndex && newIndex != primaryControllerIndex)
			{
				karts[newIndex].SetNewController(KartController.Controller.Primary);

				if (primaryControllerIndex >= 0)
				{
					karts[primaryControllerIndex].SetNewController(KartController.Controller.None);
				}

				primaryControllerIndex = newIndex;

				return;
			}
		}
    }

    void SwitchSecondaryController()
    {
	    int newIndex = secondaryControllerIndex;

		//Get first available index
		for (int i = 0; i < karts.Count; i++) 
		{
			newIndex++;

			if (newIndex >= karts.Count) {
				newIndex = 0;
			}

			if (newIndex != primaryControllerIndex && newIndex != secondaryControllerIndex) {
				karts[newIndex].SetNewController(KartController.Controller.Secondary);

				if (secondaryControllerIndex >= 0) {
					karts[secondaryControllerIndex].SetNewController(KartController.Controller.None);
				}

				secondaryControllerIndex = newIndex;

				return;
			}
		}
    }

    public void AddKart(KartController kart)
    {
	    if (karts.Contains(kart))
		    return;

		karts.Add(kart);

		AssignAvailableKarts();
    }

    public void RemoveKart(KartController kart)
    {
	    if (!karts.Contains(kart))
		    return;

	    int removedIndex = karts.IndexOf(kart);
	    karts.Remove(kart);

	    if (removedIndex == primaryControllerIndex)
	    {
		    primaryControllerIndex = -1;
	    } else if (primaryControllerIndex > removedIndex)
	    {
		    primaryControllerIndex--;
	    }

	    if (removedIndex == secondaryControllerIndex)
	    {
		    secondaryControllerIndex = -1;
	    } else if (secondaryControllerIndex > removedIndex)
	    {
		    secondaryControllerIndex--;
	    }

	    AssignAvailableKarts();
    }

    void AssignAvailableKarts()
    {
	    if (primaryControllerIndex == -1) {
		    SwitchPrimaryController();
	    } 
	    
	    if (secondaryControllerIndex == -1) {
		    SwitchSecondaryController();
	    }
	}

    public int GetIndex(KartController kart)
    {
	    return karts.IndexOf(kart);
    }
}
