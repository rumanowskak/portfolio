function [error_tab, mse] = test05(f, n, s, m, draw_plot)
% Opis
% test05 - funkcja pomocniczna do funkcji test04_func_approx
% Tworzy tabelę, oraz liczy MSE dla podanej funkcji i parametrów
% Argumenty wejściowe:
%   f - uchwyt do przybliżanej funkcji
%   n - liczba wielomianów z bazy Legendre'a, wykorzystywanych do
%   aproksymowania funkcji f 
%   s - liczba odcinków, na które zostanie podzielony przedział [-1,1]
%   podczas złożonej kwadratury
%   m - liczba punktów, dla których porównywane będą wartości funkcji i jej
%   aproksymacji
%   draw_plot - decyduje czy funkcja powinna narysować wykres
% Argumenty wyjściowe:
%   error_tab - tablica przybliżeń i błędów w m punktach przedziału [-1,1]
%   mse - błąd średniokwadratowy oparty na m punktach
% Przykładowe wywołanie:
% [t, mse] = test05(@(x) sin(4*x)+1./(x.^2+0.2), 10, 5, 15, true);
% [t, mse] = test05(@(x) P(2, x), 3, 1, 100, true);
if (nargin == 0)
    f = @(x) x.^2 - 1;
    n = 3;
    s = 1;
    m = 10;
    draw_plot = false;
end
    
x = linspace(-1, 1, m);
A = func_approx_main(f, n, s);
y_approx = clenshaw_legendre(n, A, x);
y_real = f(x);
diff = abs(y_real - y_approx);
error = diff./y_real;

colnames = {'x', 'f(x)', 'f_approx(x)', 'error'};
error_tab = table(x', y_real', y_approx', error', 'VariableNames', colnames);

mse = mean(diff.^2);

if (nargin == 5 && draw_plot)
    figure()
    hold on
    plot(x, y_real, 'g');
    plot(x, y_approx, 'r');
    hold off
    grid on
    xlabel("x");
    ylabel("f(x)");
    legend("f(x)", "f_{approx}(x)");
    title(sprintf("Porównanie: n=%d s=%d", n, s));
end
end

