function [] = test04_func_approx(draw_plot)
% Opis:
% test04_func_approx - funkcja testująca działanie funkcji func_approx_main
% Argumenty wejściowe:
%   draw_plot - wektor o długości 4 decydujący, które wykresy funkcja
%   powinna rysować
% Argumenty wyjściowe: Brak
if (nargin==0)
    draw_plot = false(1, 4);
end

fprintf("Test funkcji func_approx.\n");

% Test 1
f = @(x) sin(5*x)+cos(x);
[tab, mse] = test05(f, 10, 10, 10, draw_plot(1));
fprintf("Test 1\nf(x) = sin(5x)+cos(x), n = 10, s = 10\nMSE=");
disp(mse);
disp(tab);

% Test 2
f = @(x) 1./(x.^2+1);
[tab, mse] = test05(f, 10, 5, 10, draw_plot(2));
fprintf("Test 2\nf(x) = 1/(x^2+1), n = 10, s = 5\nMSE=");
disp(mse);
disp(tab);

% Test 3
f = @(x) log(x+2).*sin(x)-cos(x+pi);
[tab, mse] = test05(f, 5, 5, 10, draw_plot(3));
fprintf("Test 3\nf(x) = ln(x+2)*sin(x)-cos(x+pi), n = 5, s = 5\nMSE=");
disp(mse);
disp(tab);

% Test 3
f = @(x) sin(1./(abs(x)+0.2));
[tab, mse] = test05(f, 15, 10, 20, draw_plot(4));
fprintf("Test 4\nf(x) = sin(1/(|x|+0.2)), n = 15, s = 10\nMSE=");
disp(mse);
disp(tab);


end

