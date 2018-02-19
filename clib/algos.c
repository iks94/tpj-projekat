#include <stdlib.h>

static inline int aps(int x) {
	return x < 0 ? -x : x;
}

int pixel_diff(unsigned pixel1, unsigned pixel2) {
	int r1 = 0xff & (pixel1 >> 0);
	int r2 = 0xff & (pixel2 >> 0);
	int g1 = 0xff & (pixel1 >> 8);
	int g2 = 0xff & (pixel2 >> 8);
	int b1 = 0xff & (pixel1 >> 16);
	int b2 = 0xff & (pixel2 >> 16);

	return abs(r1-r2) + abs(g1-g2) + abs(b1-b2);
}

int seam_carving_step(int n, int m, uint* a, uint* b) {
	int i, j, k, x, y, y0;
	unsigned l, r;

	unsigned* dp;
	short* dir;
	int* removed;

	dp = (unsigned*) malloc(n * m * sizeof(unsigned));

	if (dp == NULL) 
		return 1;

	dir = (short*) malloc(n * m * sizeof(short));

	if (dir == NULL) {
		free(dp);
		return 1;
	}

	removed = (int*) malloc(n * sizeof(int));

	if (removed == NULL) {
		free(dir);
		free(dp);
		return 1;
	}

	for (int j=0; j<m; j++) {
		dp[j] = 0;
	}

	for (int i=1; i<n; i++) {
		for (int j=0; j<m; j++) {
			
			dp[i*m + j] = dp[(i-1)*m + j] + pixel_diff(a[i*m + j], a[(i-1)*m + j]);
			dir[i*m + j] = 0;

			l = 0xffffffff;
			r = 0xffffffff;

			if (j > 0)
				l = dp[(i-1)*m + j-1] + pixel_diff(a[i*m + j], a[(i-1)*m + j-1]);

			if (j < m-1)
				r = dp[(i-1)*m + j+1] + pixel_diff(a[i*m + j], a[(i-1)*m + j+1]);

			if (l < dp[i*m + j]) {
				dp[i*m + j] = l;
				dir[i*m + j] = -1;
			}

			if (r < dp[i*m + j]) {
				dp[i*m + j] = r;
				dir[i*m + j] = +1;
			}
		}
	}

	y0 = 0;
	for (j=1; j<m; j++) {
		if (dp[(n-1)*m + j] < dp[(n-1)*m + y0])
			y0 = j;
	}

	x = n-1;
	y = y0;
	removed[x] = y;
	while (x > 0) {
		y += dir[x*m + y];
		x -= 1;

		removed[x] = y;
	}

	for (i=0; i<n; i++) {
		k = 0;
		for (j=0; j<m; j++) {
			if (j != removed[i]) {
				b[i*(m-1) + k] = a[i*m + j];
				k++;
			}
		}
	}

	return 0;


}
