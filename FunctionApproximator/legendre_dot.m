function [y] = legendre_dot(f, n, s)
% Opis:
% legendre_dot - funkcja wyznaczająca wartość iloczynu skalarnego w
% przestrzeni L_w^2(-1, 1) dla funkcji f oraz n-tego wielomianu legendre'a.
% Całka liczona jest złożoną kwadraturą Gaussa-Legendre'a dla 3 węzłów.
%
% Argumenty wejściowe:
%   f - uchwyt do funkcji f
%   n - stopień wielomianu 
%   s - liczba odcinków na które zostanie podzielony przedział [-1, 1] w
% trakcie stosowania kwadratury Gaussa-Legendre'a
% Argumenty wyjściowe:
%   y - wartość iloczynu skalarnego <f, P_n>

if (nargin == 2)
    s = 1;
end

sep = linspace(-1, 1, s+1);
h = @(x) f(x).*P(n, x);
y = 0;
for i = 1:s
    y = y + gauss_legendre_quadrature(h, sep(i), sep(i+1));
end
end

