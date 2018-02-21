using System;
using Gtk;
using Projekat;

namespace Projekat
{
	public class SteganoDialog : Gtk.Dialog
	{
		private bool read; // da li sluzi sa citanje poruke ili setovanje
		private bool has; // ako se poruka cita, da li uopste postoji?
		private string message;

		public string Message {	
			get { return message; }
		}

		private VBox vbox;
		private Label label;
		private ScrolledWindow scrollw;
		private TextView textView;
		private Button button;

		private void BuildUI() {
			this.WindowPosition = WindowPosition.CenterOnParent;

			foreach(Widget w in Children) {
				w.Destroy();
				this.Remove(w);
			}

			this.BorderWidth = 6;

			this.vbox = new VBox();
			this.vbox.Spacing = 6;

			this.label = new Label(read ? (has ? "Tajna poruka:" : "Nema tajne poruke!") : "Unesi tajnu poruku:");
			this.scrollw = new ScrolledWindow();
			this.textView = new TextView();
			this.button = new Button("OK");

			if (read) {
				this.textView.Editable = false;
				if (has) {
					this.textView.Buffer.Text = message;
				}
			} else {
				this.textView.Buffer.Text = message;
			}

			Box.BoxChild bchld;

			scrollw.Add(textView);

			this.vbox.Add(label);
			bchld = (Box.BoxChild)vbox[label];
			bchld.Position = 0;
			bchld.Expand = true;
			bchld.Fill = true;

			this.vbox.Add(scrollw);
			bchld = (Box.BoxChild)vbox[scrollw];
			bchld.Position = 1;
			bchld.Expand = true;
			bchld.Fill = true;

			this.vbox.Add(button);
			bchld = (Box.BoxChild)vbox[button];
			bchld.Position = 2;
			bchld.Expand = true;
			bchld.Fill = true;

			button.Clicked += (object sender, EventArgs e) => {
				this.message = this.textView.Buffer.Text;
				this.Destroy();
			};

			this.Add(vbox);
			this.DefaultWidth = 480;
			this.ShowAll();
		}

		public SteganoDialog (Window parent, bool read, bool has, string message)
			: base("Steganografija", parent, DialogFlags.Modal)
		{
			this.read = read;
			this.has = has;
			this.message = message;
			BuildUI();
		}
	}
}

