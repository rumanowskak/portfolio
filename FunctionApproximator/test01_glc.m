function [] = test01_glc()
% Opis:
% test01_glc - funkcja testująca działanie funkcji
% gauss_legendre_quadrature
% Argumenty wejściowe: Brak
% Argumenty wyjściowe: Brak

fprintf("Test funkcji gauss_legendre_quadrature liczącej 3-węzłową kwadraturę Gaussa-Legendre'a\n");
I_real = zeros(4, 1);
I_approx = zeros(4, 1);
errors = zeros(4, 1);

% Test 1
f = @(x) x.^5 - 4.*x.^3 + 2.*x.^2 + 10.*x - 7;
a = -1;
b = 1;
I_real(1) = integral(f, a, b);
I_approx(1) = gauss_legendre_quadrature(f, a, b);
errors(1) = abs(I_real(1)-I_approx(1))./I_real(1);

% Test 2
f = @(x) sin(x);
a = -pi;
b = pi/2;
I_real(2) = integral(f, a, b);
I_approx(2) = gauss_legendre_quadrature(f, a, b);
errors(2) = abs(I_real(2)-I_approx(2))./I_real(2);

% Test 3
f = @(x) exp(x).*1./x;
a = 1;
b = 2;
I_real(3) = integral(f, a, b);
I_approx(3) = gauss_legendre_quadrature(f, a, b);
errors(3) = abs(I_real(3)-I_approx(3))./I_real(3);

% Test 4
f = @(x) x.^6;
a = -1;
b = 1;
I_real(4) = integral(f, a, b);
I_approx(4) = gauss_legendre_quadrature(f, a, b);
errors(4) = abs(I_real(4)-I_approx(4))./I_real(4);

func = {'x^5 - 4x^3 + 2x^2 + 10x - 7'; 'sin(x)'; 'e^x * 1/x'; 'x^6'};
func_ranges = {'[-1, 1]'; '[-pi, pi/2]'; '[1, 2]'; '[-1, 1]'};

colnames = {'Funckja', 'Przedzał', 'Prawdziwa wartość', 'Przybliżona wartość', 'Błąd'};
tab = table(func, func_ranges, I_real, I_approx, errors, 'VariableNames', colnames);
disp(tab);
end

