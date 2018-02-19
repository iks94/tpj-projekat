using System;
using Gtk;
using Projekat;

public partial class MainWindow: Gtk.Window {
	
	private EditableImage image; // trenutna slika
	private Algorithms.SeamCarving seamCarver; // podaci originalne slike i ubrzavac racunanja

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

		this.seamCarver = null;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
		Application.Quit ();
		a.RetVal = true;
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
				this.seamCarver = new Algorithms.SeamCarving(this.image.Pixels);
				this.radioHor.Active = true;
				this.selektor.Adjustment.Lower = 1;
				this.selektor.Adjustment.Upper = this.image.Pixbuf.Width;
				this.selektor.Adjustment.Value = this.image.Pixbuf.Width;
			} else {
				ShowMessage("Neuspelo otvaranje fajla");
			}
		}
	}

	protected void OnButton4Clicked(object sender, EventArgs e) {
		Application.Quit ();
	}

	protected void OnButton3Clicked(object sender, EventArgs e) {
		if (this.image.Pixbuf == null) {
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

	private void UpdateDisplayedImage() {
		image.Pixels = seamCarver.Get(radioHor.Active, (int)selektor.Adjustment.Value);
	}

	protected void OnSelektorValueChanged (object sender, EventArgs e) {
		UpdateDisplayedImage();
	}

	protected void OnRadioHorToggled (object sender, EventArgs e)
	{
		selektor.Adjustment.Upper = image.Pixbuf.Width;
		selektor.Adjustment.Value = image.Pixbuf.Width;
	}

	protected void OnRadioVertToggled (object sender, EventArgs e)
	{
		selektor.Adjustment.Upper = image.Pixbuf.Height;
		selektor.Adjustment.Value = image.Pixbuf.Height;
	}
}
