function [y] = P(n, x)
% Opis:
% P - wyznacza wartość n-tego wielomianu Legendre'a dla argumentu x
% Argumenty wejściowe:
%   x - argument wielomianu
%   n - stopień wielomianu
% Argumenty wyjściowe:
%   y - wartość wielomianu w punkcie x
coeffs = zeros(1, n+1);
coeffs(n+1) = 1;
y = clenshaw_legendre(n, coeffs, x);
end

