using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		var dialog = new Gtk.FileChooserDialog("Otvori sliku", this,
			FileChooserAction.Open, "Open", ResponseType.Accept, "Cancel", ResponseType.Cancel);
		
		if (dialog.Run () == (int)ResponseType.Accept)
		{
			this.image2.File = dialog.Filename;
			String s = "";
			unsafe
			{
				uint* data = (uint*)this.image2.Pixbuf.Pixels.ToPointer ();
				for (int i=4; i<=40004; i++) data [i] = 0xff;
				s = data [5].ToString();
				this.Title = s;
			}
			dialog.Destroy ();
		}
	}

	protected void OnButton4Clicked (object sender, EventArgs e)
	{
		Application.Quit ();
	}
}
