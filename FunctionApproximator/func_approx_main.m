function [A] = func_approx_main(f, n, s)
% Autorka: Katarzyna Rumanowska 313439
%
% Opis:
% func_approx - funkcja przybliżająca aproksymacją średniokwadratową ciągłą
% funkcję f podawaną w argumencie wejściowym na przedziale [-1,1].
% Do aproksymacji przyjmowana jest funkcja wagowa w(x)=1 oraz baza 
% wielomianów Legendre'a. Iloczyn skalarny we wzorze obliczamy całkując 
% 3-punktową złożoną kwadraturą Gaussa-Legendre'a. Funkcja zwraca tablicę
% współczynników wielomianów Legendre'a.
%
% Argumenty wejściowe:
%       f - uchwyt do przybliżanej funkcji
%       n - liczba wielomianów z bazy Legendre'a, wykorzystywanych do
%       aproksymowania funkcji f 
%       s - liczba odcinków, na które zostanie podzielony przedział [-1,1]
%       podczas złożonej kwadratury
% Argumenty wyjściowe:
%       A - tablica współczynników wielomianów Legendre'a
if (nargin == 2)
   s = 1; 
end

i = 0:n;
numerator = zeros(1, n+1);
denominator = 2./(2.*i+1);
for j = 0:n
    numerator(j+1) = legendre_dot(f, j, s);
end
A = numerator./denominator;

end

