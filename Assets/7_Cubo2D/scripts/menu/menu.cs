using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CanvasGroup))]

public class menu : MonoBehaviour {

	private Animator animator;
	private CanvasGroup canvasGrup;

	public bool isOpen;
	public bool noMoverAlInicio = false;

	public bool IsOpen {
		get { return animator.GetBool("isOpen");}
		set { animator.SetBool("isOpen",value);}
	}
  

	public void Awake(){
		animator = GetComponent<Animator> ();
		canvasGrup = GetComponent<CanvasGroup> ();

		var rect = GetComponent<RectTransform> ();
		if (noMoverAlInicio) {
		
		} else {
			rect.offsetMax = rect.offsetMin = new Vector2 (0,0);
		}

		//actualizarTexto ();
	}

	public void Start(){
		//actualizarMenu ();
		InvokeRepeating ("actualizarMenu", 0, 0.05f);

	}

	public void Update(){

		//actualizarMenu ();
	}

	public void actualizarMenu(){
		if (animator != null) {
			animator.SetBool("isOpen",isOpen);

			if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
				canvasGrup.blocksRaycasts = canvasGrup.interactable = false;
			} else {
				canvasGrup.blocksRaycasts = canvasGrup.interactable = true;

			}
		}
	}

	public void actualizarTexto(){

		foreach( textoIdiomaV2 t in GetComponentsInChildren<textoIdiomaV2>() ){
			t.actualizarTexto();
		}
	}

	public void actualizarDatos(){
	}

	public void showMenu(){
		isOpen = true;
		actualizarTexto ();
		actualizarMenu ();
		SendMessage ("show");
	}

	public void hideMenu(){
		isOpen = false;
		actualizarMenu ();
		SendMessage ("hide");
	}

	public void show(){
		//avisa a los hermanos
	}

	public void hide(){
		//avisa a los hermanos
	}
}
