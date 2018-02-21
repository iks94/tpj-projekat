using System;
using System.Collections.Generic;

namespace Projekat {
	
	public class Algorithms {

		public static uint[,] WriteBytes(uint[,] matrix, byte[] b) {
			int n = matrix.GetLength(0);
			int m = matrix.GetLength(1);

			if (b.Length*8 > n*m*3) {
				return null;
			}

			uint[,] a = new uint[n, m];
			for (int i=0; i<n; i++) {
				for (int j=0; j<m; j++) {
					a[i, j] = matrix[i, j];
				}
			}

			int r = 0, c = 0, y = 0;
			for (int i=0; i<b.Length; i++) {
				for (int j=0; j<8; j++) {
					a[r, c] = (uint)((a[r, c] & ~(1u << y)) | (((b[i] >> j) & 1u) << y));
					y += 8;
					if (y == 24) {
						y = 0;
						c++;
						if (c == m) {
							c = 0;
							r++;
						}
					}
				}
			}
				
			return a;
		}

		public static byte[] ReadBytes(uint[,] matrix) {
			int n = matrix.GetLength(0);
			int m = matrix.GetLength(1);
			int blen = (n * m * 3 + 7) / 8;
			byte[] b = new byte[blen];

			int u = 0, v = 0;

			for (int i=0; i<n; i++) {
				for (int j=0; j<m; j++) {
					for (int k=0; k<24; k+=8) {
						b[u] = (byte)((b[u] & ~(1u << v)) | (((matrix[i, j] >> k) & 1u) << v));
						v++;
						if (v == 8) {
							u++;
						}
					}
				}
			}

			return b;
		}

		public static uint[,] WriteSecret(uint[,] matrix, string b) {
			byte[] c = new byte[b.Length + 8];

			c[0] = (byte)'t';
			c[1] = (byte)'p';
			c[2] = (byte)'j';
			c[3] = (byte)'p';

			c[4] = (byte)(b.Length & 255);
			c[5] = (byte)((b.Length >> 8) & 255);
			c[6] = (byte)((b.Length >> 16) & 255);
			c[7] = (byte)((b.Length >> 24) & 255);

			for (int i=0; i<b.Length; i++) {
				c[i+8] = (byte)b[i];
			}

			return WriteBytes(matrix, c);
		}

		public static string ReadSecret(uint[,] matrix) {
			byte[] b = ReadBytes(matrix);
			if (b.Length < 8) {
				return null;
			}
			if (b[0] != 't' || b[1] != 'p' || b[2] != 'j' || b[3] != 'p') {
				return null;
			}

			int len = ((int)b[0] << 0) + ((int)b[1] << 8) + ((int)b[2] << 16) + ((int)b[3] << 24);
			if (len > b.Length - 8) {
				return null;
			}

			string s = "";

			for (int i=0; i<b.Length; i++) {
				s += b[i+8];
			}

			return s;
		}

		public static uint PixelDiff(uint pixel1, uint pixel2) {
			int r1 = (int)(0xff & (pixel1 >> 0));
			int r2 = (int)(0xff & (pixel2 >> 0));
			int g1 = (int)(0xff & (pixel1 >> 8));
			int g2 = (int)(0xff & (pixel2 >> 8));
			int b1 = (int)(0xff & (pixel1 >> 16));
			int b2 = (int)(0xff & (pixel2 >> 16));

			return (uint)(Math.Abs(r1-r2) + Math.Abs(g1-g2) + Math.Abs(b1-b2));
		}

		public static uint[,] Transpose(uint[,] matrix) {
			int n = matrix.GetLength(0);
			int m = matrix.GetLength(1);

			uint[,] transp = new uint[m, n];

			for (int i=0; i<m; i++) {
				for (int j=0; j<n; j++) {
					transp[i, j] = matrix[j, i];
				}
			}

			return transp;
		}
			
		// horizontalni algoritam
		private static uint[,] SeamCarvingStep(uint[,] a, ref int[] removed) {

			int n = a.GetLength(0);
			int m = a.GetLength(1);

			uint[,] dp = new uint[n, m];
			short[,] dir = new short[n, m];
			uint[,] b = new uint[n, m-1];

			for (int j=0; j<m; j++) {
				dp[0, j] = 0;
			}

			for (int i=1; i<n; i++) {
				for (int j=0; j<m; j++) {
					
					dp[i, j] = dp[i-1, j] + PixelDiff(a[i, j], a[i-1, j]);
					dir[i, j] = 0;

					uint l = 0xffffffff, r = 0xffffffff;

					if (j > 0)
						l = dp[i-1, j-1] + PixelDiff(a[i, j], a[i-1, j-1]);

					if (j < m-1)
						r = dp[i-1, j+1] + PixelDiff(a[i, j], a[i-1, j+1]);

					if (l < dp[i, j]) {
						dp[i, j] = l;
						dir[i, j] = -1;
					}

					if (r < dp[i, j]) {
						dp[i, j] = r;
						dir[i, j] = +1;
					}
				}
			}

			removed = new int[n];

			int y0 = 0;
			for (int j=1; j<m; j++) {
				if (dp[n-1, j] < dp[n-1, y0])
					y0 = j;
			}

			int x = n-1, y = y0;
			removed[x] = y;
			while (x > 0) {
				y += dir[x, y];
				x -= 1;

				removed[x] = y;
			}

			for (int i=0; i<n; i++) {
				int k = 0;
				for (int j=0; j<m; j++) {
					if (j != removed[i]) {
						b[i, k] = a[i, j];
						k++;
					}
				}
			}

			return b;
		}

		public class SeamCarving {
			private int[,] removedH, removedV;
			private uint[,] data;
			private int n, m;

			public SeamCarving(uint[,] pixels) {
				data = pixels;
				n = pixels.GetLength(0);
				m = pixels.GetLength(1);

				removedH = new int[n, m];
				removedV = new int[m, n];

				uint[,] tmp = pixels;

				// uradi sva horizontalna skaliranja

				for (int i=1; i<m; i++) {
					int[] removed = null;
					tmp = SeamCarvingStep(tmp, ref removed);
					for (int j=0; j<n; j++) {
						// nadji k-to prazno mesto
						int k = removed[j];
						for (int l=0; l<m; l++) {
							if (removedH[j, l] == 0) {
								if (k == 0) {
									removedH[j, l] = i;
									break;
								} else {
									k--;
								}
							}
						}
					}
				}

				// uradi sva vertikalna skaliranja (samo transponuj i zameni n, m)

				tmp = Transpose(pixels);

				for (int i=1; i<n; i++) {
					int[] removed = null;
					tmp = SeamCarvingStep(tmp, ref removed);
					for (int j=0; j<m; j++) {
						// nadji k-to prazno mesto
						int k = removed[j];
						for (int l=0; l<n; l++) {
							if (removedV[j, l] == 0) {
								if (k == 0) {
									removedV[j, l] = i;
									break;
								} else {
									k--;
								}
							}
						}
					}
				}

				for (int i=0; i<n; i++) {
					for (int j=0; j<m; j++) {
						if (removedH[i, j] == 0)
							removedH[i, j] = m;
						if (removedV[j, i] == 0)
							removedV[j, i] = n;
					}
				}
			}

			public uint[,] Get(bool horizontal, int newSize) {
				if (horizontal) {
					uint[,] b = new uint[n, newSize];

					for (int i=0; i<n; i++) {
						int y = 0;
						for (int j=0; j<m; j++) {
							if (removedH[i, j] > (m - newSize)) {
								b[i, y] = data[i, j];
								y++;
							}
						}
					}

					return b;
				} else {

					uint[,] b = new uint[m, newSize];

					for (int i=0; i<m; i++) {
						int y = 0;
						for (int j=0; j<n; j++) {
							if (removedV[i, j] > (n - newSize)) {
								b[i, y] = data[j, i];
								y++;
							}
						}
					}

					return Transpose(b);
				}
			}
		}
	}
}

