function [y] = clenshaw_legendre(n, a, x)
% Opis
% clenshaw_legendre - funkcja realizująca algorytm clenshawa dla
% wielomianów Legednre'a i argumentu x
% Argumenty wejściowe:
%   n - stopień ostatniego wielomianu
%   a - współczynniki przy wielomianach (length(a) == n+1)
%   x - argumenty wielomianu
% Argumenty wyjściowe:
%   y - wartość układu liniowego wielomianów Legendre'a dla argumentu x
k = 0:n;
alpha = (2.*k+1)./(k+1);    % alpha_k+1 
gamma = -(k+1)./(k+2);      % gamma_k+2
B = zeros(n+3, length(x));
for i = n:-1:0
    idx = i + 1;
    B(idx,:) = a(idx) + alpha(idx).*x.*B(idx+1,:)+gamma(idx).*B(idx+2,:);
end
y = B(1,:);
end

