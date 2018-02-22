
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.HBox hbox3;
	
	private global::Gtk.VBox vbox1;
	
	private global::Gtk.Frame frame3;
	
	private global::Gtk.Alignment GtkAlignment2;
	
	private global::Gtk.VBox vbox4;
	
	private global::Gtk.RadioButton radioSeam;
	
	private global::Gtk.RadioButton radioStegano;
	
	private global::Gtk.RadioButton radioSifra;
	
	private global::Gtk.Label GtkLabel11;
	
	private global::Gtk.Frame frame1;
	
	private global::Gtk.Alignment GtkAlignment;
	
	private global::Gtk.VBox vbox2;
	
	private global::Gtk.RadioButton radioHor;
	
	private global::Gtk.RadioButton radioVert;
	
	private global::Gtk.HSeparator hseparator1;
	
	private global::Gtk.HBox hbox4;
	
	private global::Gtk.Label lblSeam;
	
	private global::Gtk.HScale selektor;
	
	private global::Gtk.Label GtkLabel5;
	
	private global::Gtk.Frame frame2;
	
	private global::Gtk.Alignment GtkAlignment1;
	
	private global::Gtk.VBox vbox3;
	
	private global::Gtk.Button btnSteganoPrikazi;
	
	private global::Gtk.Button btnSteganoPostavi;
	
	private global::Gtk.Label GtkLabel8;
	
	private global::Gtk.HSeparator hseparator2;
	
	private global::Gtk.Frame frame4;
	
	private global::Gtk.Alignment GtkAlignment3;
	
	private global::Gtk.VBox vbox5;
	
	private global::Gtk.Entry entryPassword;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.Button btnCryptoSifriraj;
	
	private global::Gtk.Button btnCryptoDesifruj;
	
	private global::Gtk.Label GtkLabel14;
	
	private global::Gtk.Button button1;
	
	private global::Gtk.Button button3;
	
	private global::Gtk.Button button4;
	
	private global::Gtk.VSeparator vseparator1;
	
	private global::Gtk.Alignment alignment1;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Algoritmi za slike");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.BorderWidth = ((uint)(6));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.hbox3 = new global::Gtk.HBox ();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.WidthRequest = 200;
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.frame3 = new global::Gtk.Frame ();
		this.frame3.Name = "frame3";
		this.frame3.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child frame3.Gtk.Container+ContainerChild
		this.GtkAlignment2 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment2.Name = "GtkAlignment2";
		this.GtkAlignment2.LeftPadding = ((uint)(12));
		// Container child GtkAlignment2.Gtk.Container+ContainerChild
		this.vbox4 = new global::Gtk.VBox ();
		this.vbox4.Name = "vbox4";
		this.vbox4.Spacing = 6;
		this.vbox4.BorderWidth = ((uint)(4));
		// Container child vbox4.Gtk.Box+BoxChild
		this.radioSeam = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Seam carving"));
		this.radioSeam.CanFocus = true;
		this.radioSeam.Name = "radioSeam";
		this.radioSeam.DrawIndicator = true;
		this.radioSeam.UseUnderline = true;
		this.radioSeam.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.vbox4.Add (this.radioSeam);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.radioSeam]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child vbox4.Gtk.Box+BoxChild
		this.radioStegano = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Steganografija"));
		this.radioStegano.CanFocus = true;
		this.radioStegano.Name = "radioStegano";
		this.radioStegano.DrawIndicator = true;
		this.radioStegano.UseUnderline = true;
		this.radioStegano.Group = this.radioSeam.Group;
		this.vbox4.Add (this.radioStegano);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.radioStegano]));
		w2.Position = 1;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox4.Gtk.Box+BoxChild
		this.radioSifra = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Šifriranje"));
		this.radioSifra.CanFocus = true;
		this.radioSifra.Name = "radioSifra";
		this.radioSifra.DrawIndicator = true;
		this.radioSifra.UseUnderline = true;
		this.radioSifra.Group = this.radioSeam.Group;
		this.vbox4.Add (this.radioSifra);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.radioSifra]));
		w3.Position = 2;
		w3.Expand = false;
		w3.Fill = false;
		this.GtkAlignment2.Add (this.vbox4);
		this.frame3.Add (this.GtkAlignment2);
		this.GtkLabel11 = new global::Gtk.Label ();
		this.GtkLabel11.Name = "GtkLabel11";
		this.GtkLabel11.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Izbor algoritma</b>");
		this.GtkLabel11.UseMarkup = true;
		this.frame3.LabelWidget = this.GtkLabel11;
		this.vbox1.Add (this.frame3);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame3]));
		w6.Position = 0;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.frame1 = new global::Gtk.Frame ();
		this.frame1.Name = "frame1";
		this.frame1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child frame1.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		this.vbox2.BorderWidth = ((uint)(4));
		// Container child vbox2.Gtk.Box+BoxChild
		this.radioHor = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Horizontalno"));
		this.radioHor.CanFocus = true;
		this.radioHor.Name = "radioHor";
		this.radioHor.DrawIndicator = true;
		this.radioHor.UseUnderline = true;
		this.radioHor.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.vbox2.Add (this.radioHor);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.radioHor]));
		w7.Position = 0;
		w7.Expand = false;
		w7.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.radioVert = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Vertikalno"));
		this.radioVert.CanFocus = true;
		this.radioVert.Name = "radioVert";
		this.radioVert.DrawIndicator = true;
		this.radioVert.UseUnderline = true;
		this.radioVert.Group = this.radioHor.Group;
		this.vbox2.Add (this.radioVert);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.radioVert]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hseparator1 = new global::Gtk.HSeparator ();
		this.hseparator1.Name = "hseparator1";
		this.vbox2.Add (this.hseparator1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hseparator1]));
		w9.Position = 2;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox ();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.lblSeam = new global::Gtk.Label ();
		this.lblSeam.Name = "lblSeam";
		this.lblSeam.Xalign = 0F;
		this.lblSeam.LabelProp = global::Mono.Unix.Catalog.GetString ("Širina:");
		this.lblSeam.WidthChars = 7;
		this.hbox4.Add (this.lblSeam);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.lblSeam]));
		w10.Position = 0;
		w10.Expand = false;
		w10.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.selektor = new global::Gtk.HScale (null);
		this.selektor.Sensitive = false;
		this.selektor.CanFocus = true;
		this.selektor.Name = "selektor";
		this.selektor.Adjustment.Lower = 1;
		this.selektor.Adjustment.Upper = 1;
		this.selektor.Adjustment.PageIncrement = 1;
		this.selektor.Adjustment.StepIncrement = 1;
		this.selektor.Adjustment.Value = 1;
		this.selektor.DrawValue = true;
		this.selektor.Digits = 0;
		this.selektor.ValuePos = ((global::Gtk.PositionType)(2));
		this.hbox4.Add (this.selektor);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.selektor]));
		w11.Position = 1;
		this.vbox2.Add (this.hbox4);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox4]));
		w12.PackType = ((global::Gtk.PackType)(1));
		w12.Position = 3;
		w12.Expand = false;
		w12.Fill = false;
		this.GtkAlignment.Add (this.vbox2);
		this.frame1.Add (this.GtkAlignment);
		this.GtkLabel5 = new global::Gtk.Label ();
		this.GtkLabel5.Name = "GtkLabel5";
		this.GtkLabel5.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Seam carving</b>");
		this.GtkLabel5.UseMarkup = true;
		this.frame1.LabelWidget = this.GtkLabel5;
		this.vbox1.Add (this.frame1);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame1]));
		w15.Position = 1;
		w15.Expand = false;
		w15.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.frame2 = new global::Gtk.Frame ();
		this.frame2.Name = "frame2";
		this.frame2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child frame2.Gtk.Container+ContainerChild
		this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment1.Name = "GtkAlignment1";
		this.GtkAlignment1.LeftPadding = ((uint)(12));
		// Container child GtkAlignment1.Gtk.Container+ContainerChild
		this.vbox3 = new global::Gtk.VBox ();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		this.vbox3.BorderWidth = ((uint)(4));
		// Container child vbox3.Gtk.Box+BoxChild
		this.btnSteganoPrikazi = new global::Gtk.Button ();
		this.btnSteganoPrikazi.CanFocus = true;
		this.btnSteganoPrikazi.Name = "btnSteganoPrikazi";
		this.btnSteganoPrikazi.UseUnderline = true;
		this.btnSteganoPrikazi.Label = global::Mono.Unix.Catalog.GetString ("Prikaži");
		this.vbox3.Add (this.btnSteganoPrikazi);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnSteganoPrikazi]));
		w16.Position = 0;
		w16.Expand = false;
		w16.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.btnSteganoPostavi = new global::Gtk.Button ();
		this.btnSteganoPostavi.CanFocus = true;
		this.btnSteganoPostavi.Name = "btnSteganoPostavi";
		this.btnSteganoPostavi.UseUnderline = true;
		this.btnSteganoPostavi.Label = global::Mono.Unix.Catalog.GetString ("Postavi");
		this.vbox3.Add (this.btnSteganoPostavi);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnSteganoPostavi]));
		w17.Position = 1;
		w17.Expand = false;
		w17.Fill = false;
		this.GtkAlignment1.Add (this.vbox3);
		this.frame2.Add (this.GtkAlignment1);
		this.GtkLabel8 = new global::Gtk.Label ();
		this.GtkLabel8.Name = "GtkLabel8";
		this.GtkLabel8.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Steganografija</b>");
		this.GtkLabel8.UseMarkup = true;
		this.frame2.LabelWidget = this.GtkLabel8;
		this.vbox1.Add (this.frame2);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame2]));
		w20.Position = 2;
		w20.Expand = false;
		w20.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hseparator2 = new global::Gtk.HSeparator ();
		this.hseparator2.Name = "hseparator2";
		this.vbox1.Add (this.hseparator2);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hseparator2]));
		w21.Position = 3;
		w21.Expand = false;
		w21.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.frame4 = new global::Gtk.Frame ();
		this.frame4.Name = "frame4";
		this.frame4.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child frame4.Gtk.Container+ContainerChild
		this.GtkAlignment3 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment3.Name = "GtkAlignment3";
		this.GtkAlignment3.LeftPadding = ((uint)(12));
		// Container child GtkAlignment3.Gtk.Container+ContainerChild
		this.vbox5 = new global::Gtk.VBox ();
		this.vbox5.Name = "vbox5";
		this.vbox5.Spacing = 6;
		this.vbox5.BorderWidth = ((uint)(4));
		// Container child vbox5.Gtk.Box+BoxChild
		this.entryPassword = new global::Gtk.Entry ();
		this.entryPassword.CanFocus = true;
		this.entryPassword.Name = "entryPassword";
		this.entryPassword.IsEditable = true;
		this.entryPassword.Visibility = false;
		this.entryPassword.InvisibleChar = '•';
		this.vbox5.Add (this.entryPassword);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.entryPassword]));
		w22.Position = 0;
		w22.Expand = false;
		w22.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.btnCryptoSifriraj = new global::Gtk.Button ();
		this.btnCryptoSifriraj.CanFocus = true;
		this.btnCryptoSifriraj.Name = "btnCryptoSifriraj";
		this.btnCryptoSifriraj.UseUnderline = true;
		this.btnCryptoSifriraj.Label = global::Mono.Unix.Catalog.GetString ("Šifruj");
		this.hbox1.Add (this.btnCryptoSifriraj);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnCryptoSifriraj]));
		w23.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.btnCryptoDesifruj = new global::Gtk.Button ();
		this.btnCryptoDesifruj.CanFocus = true;
		this.btnCryptoDesifruj.Name = "btnCryptoDesifruj";
		this.btnCryptoDesifruj.UseUnderline = true;
		this.btnCryptoDesifruj.Label = global::Mono.Unix.Catalog.GetString ("Dešifruj");
		this.hbox1.Add (this.btnCryptoDesifruj);
		global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnCryptoDesifruj]));
		w24.Position = 1;
		this.vbox5.Add (this.hbox1);
		global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox1]));
		w25.Position = 1;
		w25.Expand = false;
		w25.Fill = false;
		this.GtkAlignment3.Add (this.vbox5);
		this.frame4.Add (this.GtkAlignment3);
		this.GtkLabel14 = new global::Gtk.Label ();
		this.GtkLabel14.Name = "GtkLabel14";
		this.GtkLabel14.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Šifriranje</b>");
		this.GtkLabel14.UseMarkup = true;
		this.frame4.LabelWidget = this.GtkLabel14;
		this.vbox1.Add (this.frame4);
		global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame4]));
		w28.Position = 4;
		w28.Expand = false;
		w28.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.button1 = new global::Gtk.Button ();
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseUnderline = true;
		this.button1.Label = global::Mono.Unix.Catalog.GetString ("Otvori");
		this.vbox1.Add (this.button1);
		global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.button1]));
		w29.Position = 5;
		w29.Expand = false;
		w29.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.button3 = new global::Gtk.Button ();
		this.button3.CanFocus = true;
		this.button3.Name = "button3";
		this.button3.UseUnderline = true;
		this.button3.Label = global::Mono.Unix.Catalog.GetString ("Sačuvaj");
		this.vbox1.Add (this.button3);
		global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.button3]));
		w30.Position = 6;
		w30.Expand = false;
		w30.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.button4 = new global::Gtk.Button ();
		this.button4.CanFocus = true;
		this.button4.Name = "button4";
		this.button4.UseUnderline = true;
		this.button4.Label = global::Mono.Unix.Catalog.GetString ("Zatvori");
		this.vbox1.Add (this.button4);
		global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.button4]));
		w31.Position = 7;
		w31.Expand = false;
		w31.Fill = false;
		this.hbox3.Add (this.vbox1);
		global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.vbox1]));
		w32.Position = 0;
		w32.Expand = false;
		w32.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.vseparator1 = new global::Gtk.VSeparator ();
		this.vseparator1.Name = "vseparator1";
		this.hbox3.Add (this.vseparator1);
		global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.vseparator1]));
		w33.Position = 1;
		w33.Expand = false;
		w33.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment1.Name = "alignment1";
		this.hbox3.Add (this.alignment1);
		global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.alignment1]));
		w34.Position = 2;
		w34.Fill = false;
		this.Add (this.hbox3);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 597;
		this.DefaultHeight = 705;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.radioSeam.Toggled += new global::System.EventHandler (this.OnRadioSeamToggled);
		this.radioStegano.Toggled += new global::System.EventHandler (this.OnRadioSteganoToggled);
		this.radioSifra.Toggled += new global::System.EventHandler (this.OnRadioSifraToggled);
		this.radioHor.Toggled += new global::System.EventHandler (this.OnRadioHorToggled);
		this.radioVert.Toggled += new global::System.EventHandler (this.OnRadioVertToggled);
		this.selektor.ValueChanged += new global::System.EventHandler (this.OnSelektorValueChanged);
		this.btnSteganoPrikazi.Clicked += new global::System.EventHandler (this.OnBtnSteganoPrikaziClicked);
		this.btnSteganoPostavi.Clicked += new global::System.EventHandler (this.OnBtnSteganoPostaviClicked);
		this.btnCryptoSifriraj.Clicked += new global::System.EventHandler (this.OnBtnCryptoSifrirajClicked);
		this.btnCryptoDesifruj.Clicked += new global::System.EventHandler (this.OnBtnCryptoDesifrujClicked);
		this.button1.Clicked += new global::System.EventHandler (this.OnButton1Clicked);
		this.button3.Clicked += new global::System.EventHandler (this.OnButton3Clicked);
		this.button4.Clicked += new global::System.EventHandler (this.OnButton4Clicked);
	}
}
