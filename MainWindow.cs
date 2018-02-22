using System;
using Gtk;
using Projekat;
using System.Threading;

public partial class MainWindow: Gtk.Window {

	/*
	 * Rule of thumb - ako neki widget ne referenciramo iz koda
	 * onda ne vredi menjati mu default ime
	 */
	
	private EditableImage image; // trenutna slika
	private uint[,] imageMatrix = null; // matrica slike
	private Thread seamCarverThread = null;
	private Algorithms.SeamCarving seamCarver = null; // ubrzavac racunanja seam carvinga

	public enum ProgramState {
		None,
		SeamCarving,
		Steganography,
		Cryptography
	}

	private ProgramState state;

	private void DisableSeamCarving() {
		this.selektor.Sensitive = false;
		this.radioHor.Sensitive = false;
		this.radioVert.Sensitive = false;
	}

	private void EnableSeamCarving() {
		this.selektor.Sensitive = true;
		this.radioHor.Sensitive = true;
		this.radioVert.Sensitive = true;
	}

	private void DisableSteganography() {
		this.btnSteganoPostavi.Sensitive = false;
		this.btnSteganoPrikazi.Sensitive = false;
	}

	private void EnableSteganography() {
		this.btnSteganoPostavi.Sensitive = true;
		this.btnSteganoPrikazi.Sensitive = true;
	}

	private void DisableCryptography() {
		this.btnCryptoDesifruj.Sensitive = false;
		this.btnCryptoSifriraj.Sensitive = false;
		this.entryPassword.Sensitive = false;
	}

	private void EnableCryptography() {
		this.btnCryptoDesifruj.Sensitive = true;
		this.btnCryptoSifriraj.Sensitive = true;
		this.entryPassword.Sensitive = true;
	}

	public new ProgramState State {
		get { return state; }

		set {
			if (value == ProgramState.None) {
				if (seamCarverThread != null) {
					seamCarverThread.Abort();
					seamCarverThread.Join();
					seamCarverThread = null;
				}

				imageMatrix = null;
				seamCarver = null;
				DisableSeamCarving();
				DisableSteganography();
				DisableCryptography();
				state = value;
			} else if (imageMatrix != null) {
				if (value == ProgramState.SeamCarving) {
					DisableSteganography();
					DisableCryptography();
					if (seamCarver != null) {
						EnableSeamCarving();
						image.Pixels = seamCarver.Get(radioHor.Active, (int)selektor.Adjustment.Value);
					} else {
						DisableSeamCarving();
						image.Pixels = imageMatrix;
					}
				} else if (value == ProgramState.Steganography) {
					DisableSeamCarving();
					EnableSteganography();
					DisableCryptography();
					image.Pixels = imageMatrix;
				} else if (value == ProgramState.Cryptography) {
					DisableSeamCarving();
					DisableSteganography();
					EnableCryptography();
					image.Pixels = imageMatrix;
				}
				state = value;
			}
		}
	}

	private void ReloadImage() {
		this.imageMatrix = this.image.Pixels;
		this.seamCarver = null;
		this.Title = "Algoritmi za slike";
		if (seamCarverThread != null) {
			seamCarverThread.Abort();
			seamCarverThread.Join();
		}
		seamCarverThread = new Thread(runSeamCarvingThread);
		seamCarverThread.Start();

		if (radioSeam.Active) {
			State = ProgramState.SeamCarving;
		} else if (radioStegano.Active) {
			State = ProgramState.Steganography;
		} else if (radioSifra.Active) {
			State = ProgramState.Cryptography;
		}
	}

	public void ShowMessage(string msg) {
		MessageDialog md = new MessageDialog(this, DialogFlags.DestroyWithParent,
			MessageType.Info, ButtonsType.Close, msg);
		md.Title = "Informacija";
		md.Run();
		md.Destroy();
	}

	public MainWindow () : base (Gtk.WindowType.Toplevel) {
		Build ();

		this.image = new EditableImage ();
		this.image.Name = "image";
		this.alignment1.Add(this.image);
		this.hbox3.Add(this.alignment1);

		this.Child.ShowAll ();

		State = ProgramState.None;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
		if (seamCarverThread != null) {
			seamCarverThread.Abort();
			seamCarverThread.Join();
		}
		Application.Quit ();
		a.RetVal = true;
	}

	private void runSeamCarvingThread() {
		// assignment is atomic
		this.Title = "Algoritmi za slike (Seam carving precompute u toku...)";
		this.seamCarver = new Algorithms.SeamCarving(this.imageMatrix);
		this.Title = "Algoritmi za slike";

		if (radioHor.Active) {
			selektor.Adjustment.Upper = image.Pixbuf.Width;
			selektor.Adjustment.Value = image.Pixbuf.Width;
			lblSeam.Text = "Širina:";
		} else {
			selektor.Adjustment.Upper = image.Pixbuf.Height;
			selektor.Adjustment.Value = image.Pixbuf.Height;
			lblSeam.Text = "Visina:";
		}

		EnableSeamCarving();
	}

	/* Otvori sliku i ucitaj je u lokalni buffer */
	protected void OnButton1Clicked(object sender, EventArgs e) {
		var dialog = new Gtk.FileChooserDialog(
			"Otvori sliku", this, FileChooserAction.Open,
			"Open", ResponseType.Accept,
			"Cancel", ResponseType.Cancel);

		int dialogResponse = dialog.Run();
		string fn = dialog.Filename;
		dialog.Destroy();
		
		if (dialogResponse == (int)ResponseType.Accept) {
			this.image.File = fn;

			if (this.image.Pixbuf != null) {
				ReloadImage();
			} else {
				State = ProgramState.None;
				ShowMessage("Neuspelo otvaranje fajla");
			}
		}
	}

	protected void OnButton4Clicked(object sender, EventArgs e) {
		if (seamCarverThread != null) {
			seamCarverThread.Abort();
			seamCarverThread.Join();
		}
		Application.Quit ();
	}

	protected void OnButton3Clicked(object sender, EventArgs e) {
		if (State == ProgramState.None) {
			ShowMessage("Trenutni bafer je prazan");
			return;
		}

		var dialog = new Gtk.FileChooserDialog (
			"Sačuvaj sliku", this, FileChooserAction.Save, 
			"Save", ResponseType.Accept,
			"Cancel", ResponseType.Cancel);

		int dialogResponse = dialog.Run();
		string fn = dialog.Filename;
		dialog.Destroy();

		if (dialogResponse == (int)ResponseType.Accept) {
			if (!fn.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase))
				fn += ".png";

			if (!this.image.Pixbuf.Savev(fn, "png", null, null))
				ShowMessage("Greška u snimanju!");
		}
	}

	protected void OnSelektorValueChanged (object sender, EventArgs e) {
		if (seamCarver != null) {
			image.Pixels = seamCarver.Get(radioHor.Active, (int)selektor.Adjustment.Value);
		}
	}

	protected void OnRadioHorToggled (object sender, EventArgs e) {
		if (seamCarver != null) {
			selektor.Adjustment.Upper = image.Pixbuf.Width;
			selektor.Adjustment.Value = image.Pixbuf.Width;
		}
		lblSeam.Text = "Širina:";
	}

	protected void OnRadioVertToggled (object sender, EventArgs e) {
		if (seamCarver != null) {
			selektor.Adjustment.Upper = image.Pixbuf.Height;
			selektor.Adjustment.Value = image.Pixbuf.Height;
		}
		lblSeam.Text = "Visina:";
	}

	protected void OnRadioSeamToggled (object sender, EventArgs e) {
		State = ProgramState.SeamCarving;
	}

	protected void OnRadioSteganoToggled (object sender, EventArgs e) {
		State = ProgramState.Steganography;
	}

	protected void OnRadioSifraToggled (object sender, EventArgs e) {
		State = ProgramState.Cryptography;
	}

	protected void OnBtnSteganoPrikaziClicked (object sender, EventArgs e) {
		string msg = null;
		if (imageMatrix != null) {
			msg = Algorithms.ReadSecret(imageMatrix);
		}

		SteganoDialog dialog = new SteganoDialog(this, true, msg != null, msg);
		dialog.Run();
	}

	protected void OnBtnSteganoPostaviClicked (object sender, EventArgs e) {
		string msg = null;
		if (imageMatrix != null) {
			msg = Algorithms.ReadSecret(imageMatrix);
		}

		SteganoDialog dialog = new SteganoDialog(this, false, false, msg == null ? "" : msg);
		dialog.Run();

		msg = dialog.Message;

		uint[,] result = Algorithms.WriteSecret(imageMatrix, msg);
		if (result != null) {
			image.Pixels = result;
			ReloadImage();
		}
	}

	protected void OnBtnCryptoSifrirajClicked (object sender, EventArgs e)
	{
		image.Pixels = Algorithms.Encrypt(imageMatrix, entryPassword.Text);
		ReloadImage();
	}

	protected void OnBtnCryptoDesifrujClicked (object sender, EventArgs e)
	{
		image.Pixels = Algorithms.Decrypt(imageMatrix, entryPassword.Text);
		ReloadImage();
	}

}
