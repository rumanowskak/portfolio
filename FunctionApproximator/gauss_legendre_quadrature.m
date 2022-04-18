function [y] = gauss_legendre_quadrature(f, a, b)
% Opis:
% gauss_legendre_quadrature - 3 węzłowa złożona kwadratura Gaussa-Legendre'a
% funkcji f na przedziale [a, b]. Do wyznaczenia wartości całki przedział 
% skalowany jest liniowo do standardowego [-1, 1]
% Argumenty wejściowe:
%   f - uchwyt do funkcji f
%   a - początek przedziału
%   b - koniec przedziału
% Argumenty wyjściowe:
%   y - przybliżona wartość całki z funkcji f na przedziale [a, b]

% Współczynniki i węzły wyznaczone analitycznie
A = [5/9, 8/9, 5/9];
X = [sqrt(3/5), 0, -sqrt(3/5)];
S = A .* f(((b-a)/2).*X+(a+b)/2);
y = (b-a)/2 * sum(S);
end

