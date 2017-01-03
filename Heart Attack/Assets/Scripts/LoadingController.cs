using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
	// Override variables
	public bool forceQuotation = false;
	public int forceQuotationIndex = 0;

	// Reference to scene component variables
	public Image logoImage;
	public Text quoteText;
	public Text authorText;

	// Quote text variables
	private string _selectedQuotation = "";
	private string _selectedAuthor = "";
	private List<string> _quotations;
	private List<string> _authors;

	// Image and text fade variables
	public float fadeDuration = 3.0f;
	public float waitDuration = 3.0f;
	private Color _invisible;
	private Color _visible;
	private bool _startFadeIn = false;
	private bool _startFadeOut = false;
	private bool _fadedIn = false;
	private bool _fadedOut = false;
	private float _startTime;

	// Initialize quotation and author pair to use and begin fade-in sequence
	void Start ()
	{
		// Populate and check that all variables are valid and accounted for
		this.PopulateQuotations ();
		this.PopulateAuthors ();
		Debug.Assert (_quotations.Count == _authors.Count);
		Debug.Assert (quoteText != null);
		Debug.Assert (authorText != null);
		Debug.Assert (logoImage != null);

		// If there are no quotes or authors, use empty, otherwise check if there's an override, otherwise randomly choose one
		if (_quotations.Count <= 0 || _authors.Count <= 0) {
			_selectedQuotation = _selectedAuthor = "";
		} else if (forceQuotation && forceQuotationIndex >= 0 && forceQuotationIndex < _quotations.Count) {
			_selectedQuotation = _quotations [forceQuotationIndex];
			_selectedAuthor = _authors [forceQuotationIndex];
		} else {
			int selectedIndex = Random.Range (0, _quotations.Count);
			_selectedQuotation = _quotations [selectedIndex];
			_selectedAuthor = _authors [selectedIndex];
		}

		// Select this quote and author to show to the user
		quoteText.text = string.Concat ("\"", _selectedQuotation, "\"");
		authorText.text = string.Concat ("~ ", _selectedAuthor);

		// Start each item as invisible and setup fading to begin with each new frame update
		_invisible = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		_visible = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		logoImage.color = quoteText.color = authorText.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		StartCoroutine (WaitForFadeIn ());
		
	}

	// Populate all the quotations to choose from
	private void PopulateQuotations ()
	{
		_quotations = new List<string> ();
		_quotations.Add ("But I say unto you who will listen: \n Love your enemy.");
		_quotations.Add ("What lies behind us and what lies before us are tiny matters compared to what lies within us.");
		_quotations.Add ("The daily effort comes from no deliberate intention or program, but straight from the heart.");
		_quotations.Add (" 'Tis better to have loved and lost \n than never to have loved at all.");
		_quotations.Add ("The course of true love \n never did run smooth.");
		_quotations.Add ("A warrior can change his metal, but not his heart.");
		_quotations.Add ("Returning violence for violence multiplies violence, adding deeper darkness to a night already devoid of stars.");
		_quotations.Add ("If you can do no good, \n at least do no harm.");
		_quotations.Add ("You have only to persevere to save yourselves, and to save all those who rely upon you.");
		_quotations.Add ("Victory attained by violence is tantamount to a defeat, for it is momentary.");
	}

	// Populate all the authors of the quotations in respective order so that the quotation matches with the author
	private void PopulateAuthors ()
	{
		_authors = new List<string> ();
		_authors.Add ("Luke 6:27");
		_authors.Add ("Henry S. Haskins");
		_authors.Add ("Albert Einstein");
		_authors.Add ("Alfred Lord Tennyson");
		_authors.Add ("William Shakespeare");
		_authors.Add ("Edgar Rice Burroughs");
		_authors.Add ("Martin Luther King, Jr.");
		_authors.Add ("Kurt Vonnegut");
		_authors.Add ("Winston Churchill");
		_authors.Add ("Mahatma Gandhi");
	}

	IEnumerator WaitForFadeIn ()
	{
		yield return new WaitForSeconds (waitDuration);
		_startFadeIn = true;
		_startTime = Time.time;
	}

	// After fading in, wait some duration until starting to fade out
	IEnumerator WaitForFadeOut ()
	{
		yield return new WaitForSeconds (waitDuration);
		_startFadeOut = true;
		_startTime = Time.time;
	}

	// Update is called every frame, controlling the fading of the text and images on the screen
	void Update ()
	{

		if (_startFadeIn && !_fadedIn) {
			float timeStep = (Time.time - _startTime) / fadeDuration;
			Color fadingColor = new Color (1.0f, 1.0f, 1.0f, Mathf.SmoothStep (0.0f, 1.0f, timeStep));
			logoImage.color = quoteText.color = authorText.color = fadingColor;
			if (fadingColor == _visible) {
				_fadedIn = true;
				StartCoroutine (WaitForFadeOut ());
			}
		}

		if (_fadedIn && _startFadeOut && !_fadedOut) {
			float timeStep = (Time.time - _startTime) / fadeDuration;
			Color fadingColor = new Color (1.0f, 1.0f, 1.0f, Mathf.SmoothStep (1.0f, 0.0f, timeStep));
			logoImage.color = quoteText.color = authorText.color = fadingColor;
			if (fadingColor == _invisible) {
				_fadedOut = true;
			}
		}
	}

}
