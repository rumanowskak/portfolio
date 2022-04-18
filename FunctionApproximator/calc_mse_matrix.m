function [m] = calc_mse_matrix(f, n_min, n_max, s_min, s_max)
if (nargin == 1)
   n_min = 1;
   n_max = 30;
   s_min = 1;
   s_max = 30;
end
m = zeros(n_max - n_min + 1, s_max - s_min + 1);
for n = n_min:n_max
   for s = s_min:s_max
      [tab, mse] = test05(f, n, s, 1000, false);
      m(n - n_min + 1, s - s_min + 1) = mse;
   end
end
end