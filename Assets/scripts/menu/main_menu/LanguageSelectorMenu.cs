using UnityEngine;
using System.Collections;

public class LanguageSelectorMenu : MonoBehaviour
{

	public GameObject letterEn, letterRu, letterFr, letterTr, letterDe, letterPt, letterEs, letterIt;

	// Use this for initialization
	void Awake ()
	{
		if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian) {
			if (letterRu == null)
				letterEn.SetActive (true);
			else {
				letterRu.SetActive (true);
				letterEn.SetActive (false);
			}
//			letterEn.SetActive (false);
//			letterEs.SetActive (false);
//			letterPt.SetActive (false);
//			letterFr.SetActive (false);
//			letterTr.SetActive (false);
//			letterDe.SetActive (false);
//			letterIt.SetActive (false);
		} else if (Application.systemLanguage == SystemLanguage.French) {
//			letterEn.SetActive (false);
//			letterRu.SetActive (false);
//			letterTr.SetActive (false);
//			letterDe.SetActive (false);
//			letterPt.SetActive (false);
//			letterEs.SetActive (false);
//			letterIt.SetActive (false);
			if (letterFr == null)
				letterEn.SetActive (true);
			else {
				letterFr.SetActive (true); 
				letterEn.SetActive (false);
			}
		} else if (Application.systemLanguage == SystemLanguage.Turkish) {
//			letterEn.SetActive (false);
//			letterRu.SetActive (false);
//			letterFr.SetActive (false);
//			letterDe.SetActive (false);
//			letterPt.SetActive (false);
//			letterEs.SetActive (false);
//			letterIt.SetActive (false);
			if (letterTr == null)
				letterEn.SetActive (true);
			else {
				letterTr.SetActive (true);
				letterEn.SetActive (false);
			}
		} else if (Application.systemLanguage == SystemLanguage.German) {
//			letterEn.SetActive (false);
//			letterRu.SetActive (false);
//			letterFr.SetActive (false);
//			letterTr.SetActive (false);
//			letterPt.SetActive (false);
//			letterEs.SetActive (false);
//			letterIt.SetActive (false);
			if (letterDe == null)
				letterEn.SetActive (true);
			else {
				letterDe.SetActive (true);
				letterEn.SetActive (false);
			}
		} else if (Application.systemLanguage == SystemLanguage.Portuguese) {
//			letterEn.SetActive (false);
//			letterRu.SetActive (false);
//			letterFr.SetActive (false);
//			letterTr.SetActive (false);
//			letterDe.SetActive (false);
//			letterEs.SetActive (false);
//			letterIt.SetActive (false);
			if (letterPt == null)
				letterEn.SetActive (true);
			else {
				letterPt.SetActive (true);
				letterEn.SetActive (false);
			}
		} else if (Application.systemLanguage == SystemLanguage.Spanish) {
//			letterEn.SetActive (false);
//			letterRu.SetActive (false);
//			letterFr.SetActive (false);
//			letterTr.SetActive (false);
//			letterDe.SetActive (false);
//			letterPt.SetActive (false);
//			letterIt.SetActive (false);
			if (letterEs == null)
				letterEn.SetActive (true);
			else {
				letterEs.SetActive (true);
				letterEn.SetActive (false);
			}
		} else if (Application.systemLanguage == SystemLanguage.Italian) {
//			letterEn.SetActive (false);
//			letterRu.SetActive (false);
//			letterFr.SetActive (false);
//			letterTr.SetActive (false);
//			letterDe.SetActive (false);
//			letterPt.SetActive (false);
//			letterEs.SetActive (false);
			if (letterIt == null)
				letterEn.SetActive (true);
			else {
				letterIt.SetActive (true);
				letterEn.SetActive (false);
			}
		} else {
			letterEn.SetActive (true);
//			letterRu.SetActive (false);
//			letterFr.SetActive (false);
//			letterTr.SetActive (false);
//			letterDe.SetActive (false);
//			letterPt.SetActive (false);
//			letterEs.SetActive (false);
//			letterIt.SetActive (false);

		}

		//Invoke ("showLetter", 1f);

	}
	// Update is called once per frame
	void Update ()
	{

	}
}
