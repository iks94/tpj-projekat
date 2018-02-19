using System;

namespace Projekat {
	
	public class EditableImage : Gtk.Image {

		public uint[,] Pixels {
			get {
				if (this.Pixbuf == null)
					return null;

				int n = this.Pixbuf.Height;
				int m = this.Pixbuf.Width;
				uint[,] a = new uint[n, m];

				unsafe {

					// sta da mu radim... mora ovako

					byte* raw = (byte*)this.Pixbuf.Pixels;

					int rowSize = this.Pixbuf.Rowstride;
					int colors = 4;

					if (!this.Pixbuf.HasAlpha) {
						colors = 3;
					}

					for (int i = 0; i < n; i++) {

						int rowStart = i * rowSize;

						for (int j = 0; j < m; j++) {

							uint r = raw[rowStart + colors*j + 0];
							uint g = raw[rowStart + colors*j + 1];
							uint b = raw[rowStart + colors*j + 2];

							a [i, j] = r + 256 * g + 65536 * b;
						}
					}
				}

				return a;
			}

			set {
				var a = value;

				int h = a.GetLength(0);
				int w = a.GetLength(1);

				int rowSize = (w * 3 + 3) / 4 * 4;

				byte[] buff = new byte[rowSize * h];

				for (int i = 0; i < h; i++) {
					int rowStart = rowSize * i;
					for (int j = 0; j < w; j++) {
						buff[rowStart + 3*j + 0] = (byte)(0xff & (a[i, j] >> 0));
						buff[rowStart + 3*j + 1] = (byte)(0xff & (a[i, j] >> 8));
						buff[rowStart + 3*j + 2] = (byte)(0xff & (a[i, j] >> 16));
					}
				}

				this.Pixbuf = new Gdk.Pixbuf(buff, false, 8, w, h, rowSize);

				var x = this.Pixbuf;
			}
		}
	}
}

