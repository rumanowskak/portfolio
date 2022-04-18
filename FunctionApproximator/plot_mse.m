function [] = plot_mse(f, t, n_min, n_max, s_min, s_max)
if (nargin == 1)
   t = ""; 
end
if (nargin == 2)
   n_min = 1;
   n_max = 30;
   s_min = 1;
   s_max = 30;
end


figure('Position', [100 100 600 500]);
m_1 = calc_mse_matrix(f, n_min, n_max, s_min, s_max);
imagesc(log10(m_1));
colormap('turbo');
set(gca,'YDir','normal')
title(sprintf("%s: Zależność rzędu wielkości MSE od parametrów n i s", t));
xlabel("s");
ylabel("n");
colorbar
end

