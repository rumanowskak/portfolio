function [] = test03_clenshaw_legendre()
% Opis:
% test03_clenshaw_legendre - funkcja testująca działanie funkcji clenshaw_legendre
% Argumenty wejściowe: Brak
% Argumenty wyjściowe: Brak

fprintf("Test funkcji clenshaw_legendre realizującej algorytm clenshawa dla wielomianów legendre'a.\n");
fprintf("Wartości x z przedziału [-1, 1] wyliczone algorytmem porównywane są do wartości wyliczonych wprost.\n");
fprintf("Funkcja P wykorzystuje funkcję clenshaw_legendre z odpowiednimi argumentami zatem także jest ona tutaj testowana.\n");

x = linspace(-1, 1, 100);
mse = zeros(4, 1);

% Test 1
A = [0, 0, 1];
y_clenshaw = clenshaw_legendre(length(A)-1, A, x);
y_heron = 0;
for i = 1:length(A)
    y_heron = y_heron + legendreP(i-1, x) * A(i);
end
mse(1) = mean((y_heron-y_clenshaw).^2);

% Test 1
A = [-1, 2, 1, 3];
y_clenshaw = clenshaw_legendre(length(A)-1, A, x);
y_heron = 0;
for i = 1:length(A)
    y_heron = y_heron + legendreP(i-1, x) * A(i);
end
mse(2) = mean((y_heron-y_clenshaw).^2);

% Test 3
A = [-1, 2, 0, 3, pi];
y_clenshaw = clenshaw_legendre(length(A)-1, A, x);
y_heron = 0;
for i = 1:length(A)
    y_heron = y_heron + legendreP(i-1, x) * A(i);
end
mse(3) = mean((y_heron-y_clenshaw).^2);

% Test 4
A = sin(1:2:12);
y_clenshaw = clenshaw_legendre(length(A)-1, A, x);
y_heron = 0;
for i = 1:length(A)
    y_heron = y_heron + legendreP(i-1, x) * A(i);
end
mse(4) = mean((y_heron-y_clenshaw).^2);

colnames = {'Współczynniki', 'MSE'};
coeffs = {'[0, 0, 1]'; '[-1, 2, 1, 3]'; '[-1, 2, 0, 3, pi'; 'sin(1:2:12)'};
tab = table(coeffs, mse, 'VariableNames', colnames);
disp(tab);

end

