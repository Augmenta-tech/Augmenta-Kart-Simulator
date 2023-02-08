using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class KartController : MonoBehaviour
{
	public enum Controller { None, Primary, Secondary }

	public Controller controller {
		get => currentController;
		set { SetNewController(value); }
	}

	[Header("Controller Components")]
	public KeyboardInput keyboardInput;
	public List<Renderer> controllerRenderers;

	private Controller currentController = Controller.None;

	void OnEnable()
	{
		KartManager.instance.AddKart(this);
	}

	void OnDisable()
	{
		KartManager.instance.RemoveKart(this);
	}

	public void SetNewController(Controller newController) {

		currentController = newController;

		keyboardInput.controller = newController;

		foreach (var r in controllerRenderers)
		{
			switch (newController)
			{
				case Controller.None:
					r.material.SetColor("_Color", KartManager.instance.noControllerColor);
					break;

				case Controller.Primary:
					r.material.SetColor("_Color", KartManager.instance.primaryControllerColor);
					break;

				case Controller.Secondary:
					r.material.SetColor("_Color", KartManager.instance.secondaryControllerColor);
					break;
			}
			
		}
	}
}
