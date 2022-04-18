function [] = test02_legendre_dot()
% Opis:
% test02_legendre_dot - funkcja testująca działanie funkcji legendre_dot
% Argumenty wejściowe: Brak
% Argumenty wyjściowe: Brak

% wzór iloczynu: integral(f(x)*p(x)) from -1 to 1
fprintf("Test funkcji legendre_dot liczącej iloczyn skalarny <f, P_n>, gdzie n to stopień wielomianu Legendre'a.\n");

dot_real = zeros(4, 1);
dot_approx = zeros(4, 1);
errors = zeros(4, 1);

% Test 1
f = @(x) x.^2 + x;
dot_real(1) = integral(@(x) f(x) .* legendreP(3, x), -1, 1);
dot_approx(1) = legendre_dot(f, 3, 1);
errors(1) = abs(dot_real(1) - dot_approx(1))./dot_real(1);

% Test 2
f = @(x) cos(x+pi/2);
dot_real(2) = integral(@(x) f(x) .* legendreP(5, x), -1, 1);
dot_approx(2) = legendre_dot(f, 5, 5);
errors(2) = abs(dot_real(2) - dot_approx(2))./dot_real(2);

% Test 3
f = @(x) legendreP(4, x);
dot_real(3) = integral(@(x) f(x) .* legendreP(4, x), -1, 1);
dot_approx(3) = legendre_dot(f, 4, 5);
errors(3) = abs(dot_real(3) - dot_approx(3))./dot_real(3);

% Test 4
f = @(x) x.^5-x.^4+x.^3;
dot_real(4) = integral(@(x) f(x) .* legendreP(4, x), -1, 1);
dot_approx(4) = legendre_dot(f, 4, 10);
errors(4) = abs(dot_real(4) - dot_approx(4))./dot_real(4);

func = {'x^2 + x'; 'cos(x+pi/2)'; 'legendreP(4, x)'; 'x^5-x^4+x^3'};
degree = [3, 5, 4, 4];
seg_count = [1, 5, 1, 10];

colnames = ["Funkcja", "n", "Ilość podziałów [-1, 1]", "Prawdziwa wartość", "Przybliżona wartość", "Błąd względny"];
tab = table(func, degree', seg_count', dot_real, dot_approx, errors, 'VariableNames', colnames);
disp(tab);

end

